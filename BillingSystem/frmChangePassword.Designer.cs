namespace BillingSystem
{
    partial class frmChangePassword
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
            lblTitle = new Label();
            lblCurrent = new Label();
            txtCurrentPassword = new TextBox();
            lblNew = new Label();
            lblRetype = new Label();
            txtNewPassword = new TextBox();
            txtRetypePassword = new TextBox();
            btnSavePassword = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(115, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(177, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Change Password";
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(38, 69);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(125, 20);
            lblCurrent.TabIndex = 1;
            lblCurrent.Text = "Current Password:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(167, 66);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(182, 27);
            txtCurrentPassword.TabIndex = 2;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.TextChanged += txtCurrentPassword_TextChanged;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(38, 120);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(107, 20);
            lblNew.TabIndex = 3;
            lblNew.Text = "New Password:";
            // 
            // lblRetype
            // 
            lblRetype.AutoSize = true;
            lblRetype.Location = new Point(38, 170);
            lblRetype.Name = "lblRetype";
            lblRetype.Size = new Size(123, 20);
            lblRetype.TabIndex = 4;
            lblRetype.Text = "Retype Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(167, 117);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(182, 27);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(167, 167);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.PasswordChar = '*';
            txtRetypePassword.Size = new Size(182, 27);
            txtRetypePassword.TabIndex = 6;
            txtRetypePassword.UseSystemPasswordChar = true;
            txtRetypePassword.TextChanged += textBox2_TextChanged;
            // 
            // btnSavePassword
            // 
            btnSavePassword.Location = new Point(48, 212);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.Size = new Size(115, 29);
            btnSavePassword.TabIndex = 7;
            btnSavePassword.Text = "Save Password";
            btnSavePassword.UseVisualStyleBackColor = true;
            btnSavePassword.Click += btnSavePassword_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.GradientActiveCaption;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(248, 212);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmChangePassword
            // 
            AcceptButton = btnSavePassword;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(402, 253);
            Controls.Add(btnCancel);
            Controls.Add(btnSavePassword);
            Controls.Add(txtRetypePassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblRetype);
            Controls.Add(lblNew);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrent);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            Load += frmChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrent;
        private TextBox txtCurrentPassword;
        private Label lblNew;
        private Label lblRetype;
        private TextBox txtNewPassword;
        private TextBox txtRetypePassword;
        private Button btnSavePassword;
        private Button btnCancel;
    }
}