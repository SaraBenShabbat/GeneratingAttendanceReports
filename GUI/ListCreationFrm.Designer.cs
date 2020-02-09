namespace GUI
{
    partial class ListCreationFrm
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
            this.createFaceLstLbl = new System.Windows.Forms.Label();
            this.faceListTxtBox = new System.Windows.Forms.TextBox();
            this.createFaceListBtn = new System.Windows.Forms.Button();
            this.nextFrmBtn = new System.Windows.Forms.Button();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // createFaceLstLbl
            // 
            this.createFaceLstLbl.Location = new System.Drawing.Point(131, 23);
            this.createFaceLstLbl.Name = "createFaceLstLbl";
            this.createFaceLstLbl.Size = new System.Drawing.Size(198, 23);
            this.createFaceLstLbl.TabIndex = 7;
            this.createFaceLstLbl.Text = "Create Face list region";
            this.createFaceLstLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // faceListTxtBox
            // 
            this.faceListTxtBox.Location = new System.Drawing.Point(131, 70);
            this.faceListTxtBox.Name = "faceListTxtBox";
            this.faceListTxtBox.Size = new System.Drawing.Size(198, 20);
            this.faceListTxtBox.TabIndex = 1;
            this.faceListTxtBox.Text = "Insert your company name";
            // 
            // createFaceListBtn
            // 
            this.createFaceListBtn.Location = new System.Drawing.Point(131, 111);
            this.createFaceListBtn.Name = "createFaceListBtn";
            this.createFaceListBtn.Size = new System.Drawing.Size(198, 23);
            this.createFaceListBtn.TabIndex = 0;
            this.createFaceListBtn.Text = "Create Face list";
            this.createFaceListBtn.UseVisualStyleBackColor = true;
            this.createFaceListBtn.Click += new System.EventHandler(this.createFaceListBtn_Click);
            // 
            // nextFrmBtn
            // 
            this.nextFrmBtn.Location = new System.Drawing.Point(175, 433);
            this.nextFrmBtn.Name = "nextFrmBtn";
            this.nextFrmBtn.Size = new System.Drawing.Size(104, 23);
            this.nextFrmBtn.TabIndex = 9;
            this.nextFrmBtn.Text = "Next";
            this.nextFrmBtn.UseVisualStyleBackColor = true;
            this.nextFrmBtn.Click += new System.EventHandler(this.nextFrmBtn_Click);
            // 
            // logoPicBox
            // 
            this.logoPicBox.InitialImage = null;
            this.logoPicBox.Location = new System.Drawing.Point(95, 150);
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.Size = new System.Drawing.Size(265, 195);
            this.logoPicBox.TabIndex = 10;
            this.logoPicBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(62, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 23);
            this.label1.TabIndex = 8;
            // 
            // ListCreationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 468);
            this.Controls.Add(this.logoPicBox);
            this.Controls.Add(this.nextFrmBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createFaceLstLbl);
            this.Controls.Add(this.faceListTxtBox);
            this.Controls.Add(this.createFaceListBtn);
            this.Name = "ListCreationFrm";
            this.Text = "ListCreationFrm";
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createFaceLstLbl;
        public System.Windows.Forms.TextBox faceListTxtBox;
        public System.Windows.Forms.Button createFaceListBtn;
        private System.Windows.Forms.Button nextFrmBtn;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.Label label1;
    }
}