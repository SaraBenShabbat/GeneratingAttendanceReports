using System;
using System.Drawing;
using System.Windows.Forms;
using BL;

namespace GUI
{
    public partial class MenuFrm : Form
    {

        #region Variable Declarations

        public ImageTesting imageTesting;
        public ProfileUploading profileUploading;
        private AddingEmployeeFrm addingEmployeefrm;
        private CapturingImageFrm capturingImagefrm;
        private Panel currentlyEnabled = null;
        private ExportingFrm expoertingFrm;

        #endregion

        #region Constructor

        public MenuFrm()
        {
            InitializeComponent();
            label1.Location = new Point(0, 150);
        }

        #endregion

        #region Methods - Triggers For Actions 

        private void AddEmpBtn_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            addingEmployeefrm = new AddingEmployeeFrm(this);
            addingEmployeefrm.Show();
        }

        private void ConfirmIdBtn_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            profileUploading = new ProfileUploading();
            if (profileUploading.IsExist(currentEmpIdTxtBox.Text.ToString()) == true)
                takingProfileBtn.Enabled = true;
            else
            {
                currentEmpIdTxtBox.Text = "Insert correct Id Number!";
                if (takingProfileBtn.Enabled == true)
                    takingProfileBtn.Enabled = false;
            }
            (sender as Button).Enabled = true;
        }

        private void TakingProfileBtn_Click(object sender, EventArgs e)
        {
            capturingImagefrm = new CapturingImageFrm(this, false);
            profileUploading.CaptureImage(capturingImagefrm, capturingImagefrm.pictureBox, this.takingProfileBtn, this.label1);
        }

        private void SavingImgBtn_Click(object sender, EventArgs e)
        {
            profileUploading.SaveImage(this.savingImgBtn, this.confirmIdBtn);
        }

        private void FaceListTxtBox_Click(object sender, EventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        private void EnabledAddEmpBtn_Click(object sender, EventArgs e)
        {
            DisabledCurrentlyEnabledPanel();
            currentlyEnabled = addEmpPanel;
            addEmpPanel.Enabled = true;
        }

        private void EnableAddProfileBtn_Click(object sender, EventArgs e)
        {
            DisabledCurrentlyEnabledPanel();
            currentlyEnabled = addProfilePanel;
            addProfilePanel.Enabled = true;
        }

        private void EnableTestImageBtn_Click(object sender, EventArgs e)
        {
            DisabledCurrentlyEnabledPanel();
            currentlyEnabled = testImagePanel;
            testImagePanel.Enabled = true;
        }

        private void TakingPicBtn_Click(object sender, EventArgs e)
        {
            capturingImagefrm = new CapturingImageFrm(this, true);
            imageTesting = new ImageTesting();
            imageTesting.CaptureImage(capturingImagefrm, capturingImagefrm.pictureBox, this.takingPicBtn, this.label1);
        }

        private void FileExplorerBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose the image to test it";
            fileDialog.Filter = "Image Files|*.jpg";
            fileDialog.InitialDirectory = @"C:\Pictures";
            fileDialog.Multiselect = false;

            fileDialog.ShowDialog();
            while (fileDialog.FileName == null) ;

            string path = fileDialog.FileName;

            imageTesting = new ImageTesting(path);

            this.ImageTestingBtn.Enabled = true;
        }

        private void ImageTestingBtn_Click(object sender, EventArgs e)
        {
            imageTesting.CropFacesAsync(label1, takingPicBtn, fileExplorerBtn, ImageTestingBtn);
        }

        #endregion

        #region Functions

        private void DisabledCurrentlyEnabledPanel()
        {
            if (currentlyEnabled != null)
                currentlyEnabled.Enabled = false;
        }

        #endregion

        #region  I have to delete this function, after using it for testing the project;

        private void button1_Click(object sender, EventArgs e)
        {
            //af1b 03f2
            // imageTesting = new ImageTesting();
            // imageTesting.xxx(label1);

            //    profileUploading = new ProfileUploading();
            //  profileUploading.xAsync("987654321.jpg", label1);

            //    createList.MakeRequest(this.button1);

            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Title = "Choose an image to test it";
            //fileDialog.Filter = "Image Files|*.jpg";
            //fileDialog.InitialDirectory = @"C:\Pictures";
            //fileDialog.Multiselect = false;

            //fileDialog.ShowDialog();
            //while (fileDialog.FileName == null) ;

            //string path = fileDialog.FileName;

            //imageTesting = new ImageTesting(path);

            //    imageTesting.DeleteTrial();

            //  createList.MakeRequest(this.createFaceListBtn);
        }

        #endregion

        private void exportBtn_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            expoertingFrm = new ExportingFrm(sender as Button);
            expoertingFrm.Show();
        }

        //private async void button1_Click_1Async(object sender, EventArgs e)
        //{
        //    // Both toggle and specifiec number of testings - the first from 2 of them.
        //    if (testingImgTimer.Enabled == true)
        //    {
        //        testingImgTimer.Start();
        //        ProcessScheduler processScheduler = new ProcessScheduler(label1);
        //        processScheduler.MainAsync();
        //    }
        //}
    }
}
