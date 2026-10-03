namespace BillingSystem
{
    partial class AddCustomerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblBalance = new Label();
            txtBalance = new TextBox();
            btnSave = new Button();
            btnClear = new Button();
            btnBack = new Button();
            cmbStatus = new ComboBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(143, 7);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(236, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Customer";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(14, 91);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(95, 25);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name:";
            lblFullName.Click += lblFullName_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(171, 82);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(155, 31);
            txtFullName.TabIndex = 2;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(14, 140);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(81, 25);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "Address:";
            lblAddress.Click += lblAddress_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(173, 131);
            txtAddress.Margin = new Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(155, 31);
            txtAddress.TabIndex = 4;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(14, 188);
            lblContact.Margin = new Padding(4, 0, 4, 0);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(147, 25);
            lblContact.TabIndex = 5;
            lblContact.Text = "Contact Number:";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(173, 179);
            txtContact.Margin = new Padding(4);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(155, 31);
            txtContact.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 238);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(174, 229);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(155, 31);
            txtEmail.TabIndex = 8;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(14, 287);
            lblBalance.Margin = new Padding(4, 0, 4, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(122, 25);
            lblBalance.TabIndex = 9;
            lblBalance.Text = "Initial Balance:";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(174, 278);
            txtBalance.Margin = new Padding(4);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(155, 31);
            txtBalance.TabIndex = 10;
            txtBalance.Text = "0.00";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(49, 400);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 37);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(213, 400);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 37);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(377, 400);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(117, 37);
            btnBack.TabIndex = 13;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(14, 327);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(182, 33);
            cmbStatus.TabIndex = 14;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 466);
            Controls.Add(cmbStatus);
            Controls.Add(btnBack);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(txtBalance);
            Controls.Add(lblBalance);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtContact);
            Controls.Add(lblContact);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MinimizeBox = false;
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System v1.0 – Add Customer (C.M.)";
            Load += AddCustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblContact;
        private TextBox txtContact;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblBalance;
        private TextBox txtBalance;
        private Button btnSave;
        private Button btnClear;
        private Button btnBack;
        private ComboBox cmbStatus;
    }
}
