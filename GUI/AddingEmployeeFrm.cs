using System;
using System.Windows.Forms;
using BL;

namespace GUI
{
    public partial class AddingEmployeeFrm : Form
    {

        #region Variable Declarations

        private EmployeeAdding employeeadding;
        private MenuFrm menuFrm;

        #endregion

        #region Constructor

        public AddingEmployeeFrm(Form menu)
        {
            menuFrm = (MenuFrm)menu;
            employeeadding = new EmployeeAdding();
            InitializeComponent();
        }

        #endregion

        #region Methods - Triggers For Actions

        private void AddEmpBtn_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            employeeadding.AddEmployee(this, (sender as Button), this.resultsLbl, menuFrm.addEmpBtn, this.empIdTxtBox.Text.ToString(), this.empfNameTxtBox.Text.ToString(), this.emplNameTxtBox.Text.ToString());
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            menuFrm.addEmpBtn.Enabled = true;
        }

        #endregion

    }
}
