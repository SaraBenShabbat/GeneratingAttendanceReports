using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DLL;

namespace BL
{
    public class EmployeeAdding
    {

        #region Methods & Functions

        public void AddEmployee(Form addingEmployeefrm, Button addingBtn, Label resultsLbl, Button addEmployeeBtn, string empId, string empfName, string emplName)
        {
            if (empId != "" && empfName != "" && emplName != "")
                if (ValidateTxtBox(empId, empfName, emplName) == true)
                {
                    resultsLbl.Text = "";

                    using (var DB = new FinalProjectEntities())
                    {
                        try
                        {
                            DB.employees.Add(new employee()
                            {
                                employeeId = empId,
                                firstName = empfName.TrimEnd(' '),
                                lastName = emplName.TrimEnd(' '),
                                dateAdded = DateTime.Now,
                                numUploadedProfiles = 0
                            });
                            DB.SaveChanges();
                            addingEmployeefrm.Close();
                            addEmployeeBtn.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            //Handle generic ones here.  
                            if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY") == true)
                                resultsLbl.Text = "There's already such an Identity Number in the system.";
                            else
                                resultsLbl.Text = "Sorry, we ran into a problem; Try again to take your profile and upload the image.";
                        }
                        addingBtn.Enabled = true;
                        return;
                    }
                }
            addingBtn.Enabled = true;
            resultsLbl.Text = "Fill the fields correctly!";
        }

        private bool ValidateTxtBox(string empId, string empfName, string emplName)
        {
            // Validation tests on employeeId txtBox: 
            // If the the length of the id is normal and the id contains only digits.
            if (empId.Length < 6 || empId.Length > 9 || Regex.IsMatch(empId, @"^[0-9]+$") == false)
                return false;

            // Validation tests on employeeFirstName txtBox: 
            // If the the length of the firstName is normal and it contains only english letters.
            if (empfName.TrimEnd(' ').Length < 2 || empfName.TrimEnd(' ').Length > 15 || Regex.IsMatch(empfName, @"^[a-zA-Z ]+$") == false)
                return false;

            // Validation tests on employeeLasttName txtBox: 
            // If the the length of the lastName is normal and it contains only english letters.
            if (emplName.TrimEnd(' ').Length < 2 || emplName.TrimEnd(' ').Length > 25 || Regex.IsMatch(emplName, @"^[a-zA-Z ]+$") == false)
                return false;

            // If all the validation test passed successfully - return true.
            return true;
        }

        #endregion

    }
}
