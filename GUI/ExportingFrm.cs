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

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            this.reportExporting.ExportActivities(idTxtBox.Text.ToString(), monthNumeric, yearNumeric, resultLbl);
        }

        private void ExportingFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.openExportBtn.Enabled = true;
        }

        #endregion

    }
}
