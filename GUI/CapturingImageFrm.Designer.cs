namespace GUI
{
    partial class CapturingImageFrm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.CapturingBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 15);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(524, 385);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // CapturingBtn
            // 
            this.CapturingBtn.Location = new System.Drawing.Point(185, 426);
            this.CapturingBtn.Name = "CapturingBtn";
            this.CapturingBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CapturingBtn.Size = new System.Drawing.Size(160, 23);
            this.CapturingBtn.TabIndex = 1;
            this.CapturingBtn.Text = "Capturing Image";
            this.CapturingBtn.UseVisualStyleBackColor = true;
            this.CapturingBtn.Click += new System.EventHandler(this.CapturingBtn_Click);
            // 
            // CapturingImageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 461);
            this.Controls.Add(this.CapturingBtn);
            this.Controls.Add(this.pictureBox);
            this.Name = "CapturingImageFrm";
            this.Text = "Capturing Image Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CapturingImageFrm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button CapturingBtn;
    }
}