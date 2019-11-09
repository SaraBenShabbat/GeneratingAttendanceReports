namespace GUI
{
    partial class AddingEmployeeFrm
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
            this.empIdLbl = new System.Windows.Forms.Label();
            this.empfNameLbl = new System.Windows.Forms.Label();
            this.emplNameLbl = new System.Windows.Forms.Label();
            this.empIdTxtBox = new System.Windows.Forms.TextBox();
            this.empfNameTxtBox = new System.Windows.Forms.TextBox();
            this.emplNameTxtBox = new System.Windows.Forms.TextBox();
            this.addEmpBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.resultsLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // empIdLbl
            // 
            this.empIdLbl.Location = new System.Drawing.Point(67, 37);
            this.empIdLbl.Name = "empIdLbl";
            this.empIdLbl.Size = new System.Drawing.Size(100, 23);
            this.empIdLbl.TabIndex = 0;
            this.empIdLbl.Text = "Employee ID:";
            // 
            // empfNameLbl
            // 
            this.empfNameLbl.Location = new System.Drawing.Point(67, 65);
            this.empfNameLbl.Name = "empfNameLbl";
            this.empfNameLbl.Size = new System.Drawing.Size(60, 13);
            this.empfNameLbl.TabIndex = 1;
            this.empfNameLbl.Text = "First Name:";
            // 
            // emplNameLbl
            // 
            this.emplNameLbl.Location = new System.Drawing.Point(67, 98);
            this.emplNameLbl.Name = "emplNameLbl";
            this.emplNameLbl.Size = new System.Drawing.Size(61, 13);
            this.emplNameLbl.TabIndex = 2;
            this.emplNameLbl.Text = "Last Name:";
            // 
            // empIdTxtBox
            // 
            this.empIdTxtBox.Location = new System.Drawing.Point(156, 34);
            this.empIdTxtBox.Name = "empIdTxtBox";
            this.empIdTxtBox.Size = new System.Drawing.Size(136, 20);
            this.empIdTxtBox.TabIndex = 3;
            // 
            // empfNameTxtBox
            // 
            this.empfNameTxtBox.Location = new System.Drawing.Point(156, 62);
            this.empfNameTxtBox.Name = "empfNameTxtBox";
            this.empfNameTxtBox.Size = new System.Drawing.Size(136, 20);
            this.empfNameTxtBox.TabIndex = 4;
            // 
            // emplNameTxtBox
            // 
            this.emplNameTxtBox.Location = new System.Drawing.Point(156, 91);
            this.emplNameTxtBox.Name = "emplNameTxtBox";
            this.emplNameTxtBox.Size = new System.Drawing.Size(136, 20);
            this.emplNameTxtBox.TabIndex = 5;
            // 
            // addEmpBtn
            // 
            this.addEmpBtn.Location = new System.Drawing.Point(42, 164);
            this.addEmpBtn.Name = "addEmpBtn";
            this.addEmpBtn.Size = new System.Drawing.Size(143, 23);
            this.addEmpBtn.TabIndex = 6;
            this.addEmpBtn.Text = "Add Employee ";
            this.addEmpBtn.UseVisualStyleBackColor = true;
            this.addEmpBtn.Click += new System.EventHandler(this.AddEmpBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(241, 164);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // resultsLbl
            // 
            this.resultsLbl.Location = new System.Drawing.Point(12, 126);
            this.resultsLbl.Name = "resultsLbl";
            this.resultsLbl.Size = new System.Drawing.Size(353, 23);
            this.resultsLbl.TabIndex = 8;
            // 
            // AddingEmployeeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 212);
            this.Controls.Add(this.resultsLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addEmpBtn);
            this.Controls.Add(this.emplNameTxtBox);
            this.Controls.Add(this.empfNameTxtBox);
            this.Controls.Add(this.empIdTxtBox);
            this.Controls.Add(this.emplNameLbl);
            this.Controls.Add(this.empfNameLbl);
            this.Controls.Add(this.empIdLbl);
            this.Name = "AddingEmployeeFrm";
            this.Text = "AddingEmployeeFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label empIdLbl;
        private System.Windows.Forms.Label empfNameLbl;
        private System.Windows.Forms.Label emplNameLbl;
        private System.Windows.Forms.Button addEmpBtn;
        public System.Windows.Forms.TextBox empIdTxtBox;
        public System.Windows.Forms.TextBox empfNameTxtBox;
        public System.Windows.Forms.TextBox emplNameTxtBox;
        private System.Windows.Forms.Button cancelBtn;
        public System.Windows.Forms.Label resultsLbl;
    }
}