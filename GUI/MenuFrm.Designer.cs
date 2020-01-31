namespace GUI
{
    partial class MenuFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addEmpBtn = new System.Windows.Forms.Button();
            this.takingProfileBtn = new System.Windows.Forms.Button();
            this.ImageTestingBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.savingImgBtn = new System.Windows.Forms.Button();
            this.addEmpRegionlbl = new System.Windows.Forms.Label();
            this.newProfileRegionLbl = new System.Windows.Forms.Label();
            this.currentEmpIdTxtBox = new System.Windows.Forms.TextBox();
            this.confirmIdBtn = new System.Windows.Forms.Button();
            this.imageTestingRegionLbl = new System.Windows.Forms.Label();
            this.addEmpPanel = new System.Windows.Forms.Panel();
            this.testImagePanel = new System.Windows.Forms.Panel();
            this.fileExplorerBtn = new System.Windows.Forms.Button();
            this.takingPicBtn = new System.Windows.Forms.Button();
            this.addProfilePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.enableTestImageBtn = new System.Windows.Forms.Button();
            this.managementLbl = new System.Windows.Forms.Label();
            this.enableAddProfileBtn = new System.Windows.Forms.Button();
            this.enabledAddEmpBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.testingImgTimer = new System.Windows.Forms.Timer(this.components);
            this.addEmpPanel.SuspendLayout();
            this.testImagePanel.SuspendLayout();
            this.addProfilePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addEmpBtn
            // 
            this.addEmpBtn.Location = new System.Drawing.Point(53, 68);
            this.addEmpBtn.Name = "addEmpBtn";
            this.addEmpBtn.Size = new System.Drawing.Size(198, 27);
            this.addEmpBtn.TabIndex = 2;
            this.addEmpBtn.Text = "Add Employee";
            this.addEmpBtn.UseVisualStyleBackColor = true;
            this.addEmpBtn.Click += new System.EventHandler(this.AddEmpBtn_Click);
            // 
            // takingProfileBtn
            // 
            this.takingProfileBtn.Enabled = false;
            this.takingProfileBtn.Location = new System.Drawing.Point(40, 84);
            this.takingProfileBtn.Name = "takingProfileBtn";
            this.takingProfileBtn.Size = new System.Drawing.Size(198, 23);
            this.takingProfileBtn.TabIndex = 3;
            this.takingProfileBtn.Text = "Take your profile";
            this.takingProfileBtn.UseVisualStyleBackColor = true;
            this.takingProfileBtn.Click += new System.EventHandler(this.TakingProfileBtn_Click);
            // 
            // ImageTestingBtn
            // 
            this.ImageTestingBtn.Enabled = false;
            this.ImageTestingBtn.Location = new System.Drawing.Point(69, 113);
            this.ImageTestingBtn.Name = "ImageTestingBtn";
            this.ImageTestingBtn.Size = new System.Drawing.Size(170, 23);
            this.ImageTestingBtn.TabIndex = 4;
            this.ImageTestingBtn.Text = "ImageTesting";
            this.ImageTestingBtn.UseVisualStyleBackColor = true;
            this.ImageTestingBtn.Click += new System.EventHandler(this.ImageTestingBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // savingImgBtn
            // 
            this.savingImgBtn.Enabled = false;
            this.savingImgBtn.Location = new System.Drawing.Point(40, 113);
            this.savingImgBtn.Name = "savingImgBtn";
            this.savingImgBtn.Size = new System.Drawing.Size(198, 23);
            this.savingImgBtn.TabIndex = 6;
            this.savingImgBtn.Text = "Save image as your profile";
            this.savingImgBtn.UseVisualStyleBackColor = true;
            this.savingImgBtn.Click += new System.EventHandler(this.SavingImgBtn_Click);
            // 
            // addEmpRegionlbl
            // 
            this.addEmpRegionlbl.Location = new System.Drawing.Point(53, 12);
            this.addEmpRegionlbl.Name = "addEmpRegionlbl";
            this.addEmpRegionlbl.Size = new System.Drawing.Size(198, 23);
            this.addEmpRegionlbl.TabIndex = 8;
            this.addEmpRegionlbl.Text = "Add Employee region";
            this.addEmpRegionlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newProfileRegionLbl
            // 
            this.newProfileRegionLbl.Location = new System.Drawing.Point(37, 3);
            this.newProfileRegionLbl.Name = "newProfileRegionLbl";
            this.newProfileRegionLbl.Size = new System.Drawing.Size(198, 23);
            this.newProfileRegionLbl.TabIndex = 9;
            this.newProfileRegionLbl.Text = "New Profile region";
            this.newProfileRegionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentEmpIdTxtBox
            // 
            this.currentEmpIdTxtBox.Location = new System.Drawing.Point(37, 29);
            this.currentEmpIdTxtBox.Name = "currentEmpIdTxtBox";
            this.currentEmpIdTxtBox.Size = new System.Drawing.Size(198, 20);
            this.currentEmpIdTxtBox.TabIndex = 10;
            // 
            // confirmIdBtn
            // 
            this.confirmIdBtn.Location = new System.Drawing.Point(99, 55);
            this.confirmIdBtn.Name = "confirmIdBtn";
            this.confirmIdBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmIdBtn.TabIndex = 11;
            this.confirmIdBtn.Text = "OK";
            this.confirmIdBtn.UseVisualStyleBackColor = true;
            this.confirmIdBtn.Click += new System.EventHandler(this.ConfirmIdBtn_Click);
            // 
            // imageTestingRegionLbl
            // 
            this.imageTestingRegionLbl.Location = new System.Drawing.Point(51, 11);
            this.imageTestingRegionLbl.Name = "imageTestingRegionLbl";
            this.imageTestingRegionLbl.Size = new System.Drawing.Size(198, 23);
            this.imageTestingRegionLbl.TabIndex = 12;
            this.imageTestingRegionLbl.Text = "Image testing region";
            this.imageTestingRegionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addEmpPanel
            // 
            this.addEmpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addEmpPanel.Controls.Add(this.addEmpBtn);
            this.addEmpPanel.Controls.Add(this.addEmpRegionlbl);
            this.addEmpPanel.Enabled = false;
            this.addEmpPanel.Location = new System.Drawing.Point(12, 9);
            this.addEmpPanel.Name = "addEmpPanel";
            this.addEmpPanel.Size = new System.Drawing.Size(281, 149);
            this.addEmpPanel.TabIndex = 14;
            // 
            // testImagePanel
            // 
            this.testImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testImagePanel.Controls.Add(this.fileExplorerBtn);
            this.testImagePanel.Controls.Add(this.takingPicBtn);
            this.testImagePanel.Controls.Add(this.imageTestingRegionLbl);
            this.testImagePanel.Controls.Add(this.ImageTestingBtn);
            this.testImagePanel.Enabled = false;
            this.testImagePanel.Location = new System.Drawing.Point(617, 9);
            this.testImagePanel.Name = "testImagePanel";
            this.testImagePanel.Size = new System.Drawing.Size(281, 149);
            this.testImagePanel.TabIndex = 15;
            // 
            // fileExplorerBtn
            // 
            this.fileExplorerBtn.Location = new System.Drawing.Point(69, 75);
            this.fileExplorerBtn.Name = "fileExplorerBtn";
            this.fileExplorerBtn.Size = new System.Drawing.Size(170, 23);
            this.fileExplorerBtn.TabIndex = 14;
            this.fileExplorerBtn.Text = "Open the file explorer";
            this.fileExplorerBtn.UseVisualStyleBackColor = true;
            this.fileExplorerBtn.Click += new System.EventHandler(this.FileExplorerBtn_Click);
            // 
            // takingPicBtn
            // 
            this.takingPicBtn.Location = new System.Drawing.Point(69, 37);
            this.takingPicBtn.Name = "takingPicBtn";
            this.takingPicBtn.Size = new System.Drawing.Size(170, 23);
            this.takingPicBtn.TabIndex = 13;
            this.takingPicBtn.Text = "Take a picture for testing";
            this.takingPicBtn.UseVisualStyleBackColor = true;
            this.takingPicBtn.Click += new System.EventHandler(this.TakingPicBtn_Click);
            // 
            // addProfilePanel
            // 
            this.addProfilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addProfilePanel.Controls.Add(this.savingImgBtn);
            this.addProfilePanel.Controls.Add(this.takingProfileBtn);
            this.addProfilePanel.Controls.Add(this.confirmIdBtn);
            this.addProfilePanel.Controls.Add(this.currentEmpIdTxtBox);
            this.addProfilePanel.Controls.Add(this.newProfileRegionLbl);
            this.addProfilePanel.Enabled = false;
            this.addProfilePanel.Location = new System.Drawing.Point(317, 9);
            this.addProfilePanel.Name = "addProfilePanel";
            this.addProfilePanel.Size = new System.Drawing.Size(281, 149);
            this.addProfilePanel.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.enableTestImageBtn);
            this.panel1.Controls.Add(this.managementLbl);
            this.panel1.Controls.Add(this.enableAddProfileBtn);
            this.panel1.Controls.Add(this.enabledAddEmpBtn);
            this.panel1.Location = new System.Drawing.Point(268, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 193);
            this.panel1.TabIndex = 16;
            // 
            // enableTestImageBtn
            // 
            this.enableTestImageBtn.Location = new System.Drawing.Point(89, 142);
            this.enableTestImageBtn.Name = "enableTestImageBtn";
            this.enableTestImageBtn.Size = new System.Drawing.Size(198, 23);
            this.enableTestImageBtn.TabIndex = 20;
            this.enableTestImageBtn.Text = "Enable Test Image region";
            this.enableTestImageBtn.UseVisualStyleBackColor = true;
            this.enableTestImageBtn.Click += new System.EventHandler(this.EnableTestImageBtn_Click);
            // 
            // managementLbl
            // 
            this.managementLbl.Location = new System.Drawing.Point(140, 10);
            this.managementLbl.Name = "managementLbl";
            this.managementLbl.Size = new System.Drawing.Size(100, 23);
            this.managementLbl.TabIndex = 0;
            this.managementLbl.Text = "Management";
            this.managementLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enableAddProfileBtn
            // 
            this.enableAddProfileBtn.Location = new System.Drawing.Point(89, 98);
            this.enableAddProfileBtn.Name = "enableAddProfileBtn";
            this.enableAddProfileBtn.Size = new System.Drawing.Size(198, 23);
            this.enableAddProfileBtn.TabIndex = 19;
            this.enableAddProfileBtn.Text = "Enable Add Profile region";
            this.enableAddProfileBtn.UseVisualStyleBackColor = true;
            this.enableAddProfileBtn.Click += new System.EventHandler(this.EnableAddProfileBtn_Click);
            // 
            // enabledAddEmpBtn
            // 
            this.enabledAddEmpBtn.Location = new System.Drawing.Point(89, 57);
            this.enabledAddEmpBtn.Name = "enabledAddEmpBtn";
            this.enabledAddEmpBtn.Size = new System.Drawing.Size(198, 23);
            this.enabledAddEmpBtn.TabIndex = 18;
            this.enabledAddEmpBtn.Text = "Enabled Add Employee region";
            this.enabledAddEmpBtn.UseVisualStyleBackColor = true;
            this.enabledAddEmpBtn.Click += new System.EventHandler(this.EnabledAddEmpBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(727, 265);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(140, 43);
            this.exportBtn.TabIndex = 17;
            this.exportBtn.Text = "Export attendance reports to Excel";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // MenuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(913, 412);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addProfilePanel);
            this.Controls.Add(this.testImagePanel);
            this.Controls.Add(this.addEmpPanel);
            this.Controls.Add(this.label1);
            this.Name = "MenuFrm";
            this.Text = "Menu Form";
            this.addEmpPanel.ResumeLayout(false);
            this.testImagePanel.ResumeLayout(false);
            this.addProfilePanel.ResumeLayout(false);
            this.addProfilePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button ImageTestingBtn;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button savingImgBtn;
        public System.Windows.Forms.Button takingProfileBtn;
        public System.Windows.Forms.Button addEmpBtn;
        private System.Windows.Forms.Label addEmpRegionlbl;
        private System.Windows.Forms.Label newProfileRegionLbl;
        private System.Windows.Forms.TextBox currentEmpIdTxtBox;
        private System.Windows.Forms.Button confirmIdBtn;
        private System.Windows.Forms.Label imageTestingRegionLbl;
        private System.Windows.Forms.Panel addEmpPanel;
        private System.Windows.Forms.Panel testImagePanel;
        private System.Windows.Forms.Panel addProfilePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label managementLbl;
        private System.Windows.Forms.Button enabledAddEmpBtn;
        private System.Windows.Forms.Button enableAddProfileBtn;
        private System.Windows.Forms.Button enableTestImageBtn;
        public System.Windows.Forms.Button takingPicBtn;
        public System.Windows.Forms.Button fileExplorerBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Timer testingImgTimer;
    }
}

