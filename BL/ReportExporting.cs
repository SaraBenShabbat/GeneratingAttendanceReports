﻿using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using GemBox.Spreadsheet;
using System.Linq;
using DLL;

namespace BL
{
    public class ReportExporting
    {

        #region Variable Declarations

        private SqlCommand sqlCmd;

        #endregion

        #region Methods

        public void ExportActivities(string idNumber, NumericUpDown month, NumericUpDown year, Button results)
        {
            DataTable dataTable = GetDataFromDB(idNumber, month, year, results);
            ExportData(dataTable, results);
        }

        private DataTable GetDataFromDB(string idNumber, NumericUpDown month, NumericUpDown year, Button results)
        {
            bool isCondition = false;
            DataTable dataTable = new DataTable();

            string command = "select * from activities";

            if (idNumber != "")
                command = AddFilterOfIdNumber(command, idNumber, out isCondition);
            if (isCondition == false)
                return dataTable;

            if (month.Controls[1].Text != "")
            {
                command += isCondition == true ? " and" : " where";
                command = AddFilterOfMonth(command, decimal.ToInt32(month.Value));
                isCondition = true;
            }

            if (year.Controls[1].Text != "")
            {
                command += isCondition == true ? " and" : " where";
                command = AddFilterOfYear(command, decimal.ToInt32(year.Value));
            }

            SqlDataAdapter sqlAdapter;

            using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                sqlCon.Open();

                sqlCmd = new SqlCommand(command, sqlCon);

                sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlAdapter.Fill(dataTable);

                sqlCon.Close();
            }

            return dataTable;
        }

        private string AddFilterOfIdNumber(string command, string idNumber, out bool isCondition)
        {
            employee currentEmployee;
            int employeeNumber;

            if (idNumber.Length < 6 || idNumber.Length > 9 || Regex.IsMatch(idNumber, @"^[0-9]+$") == false)
            {
                isCondition = false;
                return command;
            }

            using (var DB = new FinalProjectEntities())
            {
                currentEmployee = DB.employees.Where(x => x.employeeId == idNumber).FirstOrDefault();
                if (currentEmployee is employee)
                    employeeNumber = currentEmployee.employeeNumber;
                else
                {
                    isCondition = false;
                    return command;
                }
            }

            command += " where employeeNumber = " + employeeNumber;
            isCondition = true;
            return command;
        }

        private string AddFilterOfMonth(string command, int month)
        {
            command += " MONTH(activityDate) = " + month;
            return command;
        }

        private string AddFilterOfYear(string command, int year)
        {
            command += " YEAR(activityDate) = " + year;
            return command;
        }

        private void ExportData(DataTable dataTable, Button results)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("Activities");

            string companyName = File.ReadAllText(@"..\..\..\..\companyName.txt", Encoding.UTF8);
            worksheet.Cells[0, 0].Value = "The attendance Report in " + companyName + "(- according to your filter selection):";

            // Insert DataTable to an Excel worksheet.
            worksheet.InsertDataTable(dataTable,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 2
                });

            workbook.Save(@"..\..\..\..\Attendance Report.xlsx");

            results.Text = "R=" + dataTable.Rows.Count.ToString() + "__C=" + dataTable.Columns.Count.ToString();
        }

    }

    #endregion

}
