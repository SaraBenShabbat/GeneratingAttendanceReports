using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class CapturingImageFrm : Form
    {

        #region Variable Decalarations

        private MenuFrm menuFrm;
        private bool isTestingMode;

        #endregion

        #region Constructor

        public CapturingImageFrm(Form menu, bool isInTest)
        {
            menuFrm = (MenuFrm)menu;
            isTestingMode = isInTest;
            InitializeComponent();
        }

        #endregion

        #region Methods - Triggers For Actions 

        private void CapturingBtn_Click(object sender, EventArgs e)
        {
            if (isTestingMode == false)
                menuFrm.profileUploading.Capture(false, menuFrm.takingProfileBtn, CapturingBtn, menuFrm.savingImgBtn);
            else
                menuFrm.imageTesting.Capture(true, menuFrm.takingPicBtn, CapturingBtn, menuFrm.ImageTestingBtn);
        }

        private void CapturingImageFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The function manages the existance from this form.
            if (isTestingMode == false)
                menuFrm.profileUploading.ManageExist(menuFrm.takingProfileBtn);
            else
                menuFrm.imageTesting.ManageExist(menuFrm.takingPicBtn);
        }

        #endregion

    }
}
