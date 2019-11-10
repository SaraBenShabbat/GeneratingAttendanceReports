namespace GUI
{
    partial class ExportingFrm
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
            this.navigateBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.idTxtBox = new System.Windows.Forms.TextBox();
            this.monthNumeric = new System.Windows.Forms.NumericUpDown();
            this.yearNumeric = new System.Windows.Forms.NumericUpDown();
            this.resultLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.monthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // navigateBtn
            // 
            this.navigateBtn.Location = new System.Drawing.Point(132, 130);
            this.navigateBtn.Name = "navigateBtn";
            this.navigateBtn.Size = new System.Drawing.Size(75, 23);
            this.navigateBtn.TabIndex = 0;
            this.navigateBtn.Text = "Navigate";
            this.navigateBtn.UseVisualStyleBackColor = true;
            this.navigateBtn.Click += new System.EventHandler(this.navigateBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(329, 130);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 23);
            this.exportBtn.TabIndex = 1;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // idTxtBox
            // 
            this.idTxtBox.Location = new System.Drawing.Point(28, 42);
            this.idTxtBox.Name = "idTxtBox";
            this.idTxtBox.Size = new System.Drawing.Size(100, 20);
            this.idTxtBox.TabIndex = 2;
            // 
            // monthNumeric
            // 
            this.monthNumeric.Location = new System.Drawing.Point(208, 42);
            this.monthNumeric.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.monthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthNumeric.Name = "monthNumeric";
            this.monthNumeric.Size = new System.Drawing.Size(120, 20);
            this.monthNumeric.TabIndex = 5;
            this.monthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yearNumeric
            // 
            this.yearNumeric.Location = new System.Drawing.Point(403, 43);
            this.yearNumeric.Maximum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.yearNumeric.Minimum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.yearNumeric.Name = "yearNumeric";
            this.yearNumeric.Size = new System.Drawing.Size(120, 20);
            this.yearNumeric.TabIndex = 6;
            this.yearNumeric.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // resultLbl
            // 
            this.resultLbl.Location = new System.Drawing.Point(28, 172);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(495, 23);
            this.resultLbl.TabIndex = 7;
            // 
            // ExportingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 210);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.yearNumeric);
            this.Controls.Add(this.monthNumeric);
            this.Controls.Add(this.idTxtBox);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.navigateBtn);
            this.Name = "ExportingFrm";
            this.Text = "ExportingFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportingFrm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.monthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button navigateBtn;
        private System.Windows.Forms.Button exportBtn;
        public System.Windows.Forms.TextBox idTxtBox;
        public System.Windows.Forms.NumericUpDown monthNumeric;
        public System.Windows.Forms.NumericUpDown yearNumeric;
        public System.Windows.Forms.Label resultLbl;
    }
}