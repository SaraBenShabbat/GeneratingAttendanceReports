﻿using System;
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

            logoPicBox.ImageLocation = @"https://sarabenshabbatproject.blob.core.windows.net/newcontainer/logo.png";
            logoPicBox.SizeMode = PictureBoxSizeMode.AutoSize;

            managePanel.Left = (this.ClientSize.Width - managePanel.Width) / 2;

            label1.Left = (this.ClientSize.Width - label1.Width) / 3 + 42;
            label1.Top = managePanel.Top + label1.Height - 55;
            //   label1.AutoSize = true;
            //label1.BackColor = Color.Blue;
            // label1.TextAlign = ContentAlignment.MiddleRight;

            testingImgTimer.Interval = 30000;
            testingImgTimer.Tick += new EventHandler(EnvokeProcessScheduler);
            testingImgTimer.Enabled = false;
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
            label1.Text = "";

            capturingImagefrm = new CapturingImageFrm(this, true);
            imageTesting = new ImageTesting();
            imageTesting.CaptureImage(capturingImagefrm, capturingImagefrm.pictureBox, this.takingPicBtn, this.label1);
        }

        private void FileExplorerBtn_Click(object sender, EventArgs e)
        {
            label1.Text = "";

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

        private void exportBtn_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            expoertingFrm = new ExportingFrm(sender as Button);
            expoertingFrm.Show();
        }

        private void newFeatureBtn_Click(object sender, EventArgs e)
        {
            //ProcessScheduler processScheduler = new ProcessScheduler(label1);
            //processScheduler.MainAsync();

            if (newFeatureBtn.Text == "Start simulate camera")
            {
                testingImgTimer.Enabled = true;
                testingImgTimer.Start();

                newFeatureBtn.Text = "Stop simulate camera";
            }
            else
            {
                testingImgTimer.Enabled = false;
                testingImgTimer.Stop();

                newFeatureBtn.Text = "Start simulate camera";
            }
        }

        #endregion

        #region Functions

        private void DisabledCurrentlyEnabledPanel()
        {
            if (currentlyEnabled != null)
                currentlyEnabled.Enabled = false;
        }

        private void EnvokeProcessScheduler(Object sender, EventArgs e)
        {
            ProcessScheduler processScheduler = new ProcessScheduler(label1);
            processScheduler.MainAsync();
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

    }
}
