using System;
using System.Windows.Forms;
using BL;

namespace GUI
{
    public partial class ListCreationFrm : Form
    {

        #region Variable Declaration

        ListCreation listCreation;

        #endregion

        #region Constructor

        public ListCreationFrm()
        {
            InitializeComponent();
            listCreation = new ListCreation();
        }

        #endregion

        #region Methods - Triggers For Actions 

        private void createFaceListBtn_Click(object sender, EventArgs e)
        {
            listCreation.CreateFaceListAsync(this.faceListTxtBox, this.label1, this.createFaceListBtn);
        }

        #endregion

        private void nextFrmBtn_Click(object sender, EventArgs e)
        {
            MenuFrm menuFrm = new MenuFrm();
            menuFrm.Show();

            this.Hide();
        }
    }
}
