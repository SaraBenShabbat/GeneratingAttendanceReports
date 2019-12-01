using System;
using System.Windows.Forms;
using BL;

namespace GUI
{
    public partial class ExportingFrm : Form
    {

        #region Variable Declarations

        private Button openExportBtn = null;
        private ReportExporting reportExporting;
        private string selectedFolder = null;

        #endregion

        #region Constructor

        public ExportingFrm(Button openExrtFrm)
        {
            InitializeComponent();

            this.openExportBtn = openExrtFrm;
            this.reportExporting = new ReportExporting();
            this.yearNumeric.Maximum = DateTime.Now.Year + 1;

            this.yearNumeric.Controls[1].Text = "";
            this.monthNumeric.Controls[1].Text = "";
        }

        #endregion

        #region Methods - Triggers For Actions 

        private void navigateBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the folder to which the reports will be exported.";

            if (fbd.ShowDialog() == DialogResult.OK)
                selectedFolder = fbd.SelectedPath;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            this.reportExporting.ExportActivities(idTxtBox.Text.ToString(), monthNumeric, yearNumeric, resultLbl,selectedFolder);
        }

        private void ExportingFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.openExportBtn.Enabled = true;
        }

        #endregion

    }
}
