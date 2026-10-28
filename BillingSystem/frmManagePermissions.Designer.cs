namespace BillingSystem
{
    partial class frmManagePermissions
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
            lblRole = new Label();
            cmbRole = new ComboBox();
            chkAddCustomer = new CheckBox();
            chkEditCustomer = new CheckBox();
            chkDeleteCustomer = new CheckBox();
            chkAnalytics = new CheckBox();
            chkExportExcel = new CheckBox();
            chkExportPdf = new CheckBox();
            chkAuditLogs = new CheckBox();
            btnSave = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(114, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Permissions";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(76, 47);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(86, 20);
            lblRole.TabIndex = 1;
            lblRole.Text = "Select Role:";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Cashier" });
            cmbRole.Location = new Point(168, 44);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(151, 28);
            cmbRole.TabIndex = 2;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // chkAddCustomer
            // 
            chkAddCustomer.AutoSize = true;
            chkAddCustomer.Location = new Point(99, 108);
            chkAddCustomer.Name = "chkAddCustomer";
            chkAddCustomer.Size = new Size(126, 24);
            chkAddCustomer.TabIndex = 3;
            chkAddCustomer.Text = "Add Customer";
            chkAddCustomer.UseVisualStyleBackColor = true;
            // 
            // chkEditCustomer
            // 
            chkEditCustomer.AutoSize = true;
            chkEditCustomer.Location = new Point(99, 142);
            chkEditCustomer.Name = "chkEditCustomer";
            chkEditCustomer.Size = new Size(124, 24);
            chkEditCustomer.TabIndex = 4;
            chkEditCustomer.Text = "Edit Customer";
            chkEditCustomer.UseVisualStyleBackColor = true;
            // 
            // chkDeleteCustomer
            // 
            chkDeleteCustomer.AutoSize = true;
            chkDeleteCustomer.Location = new Point(99, 172);
            chkDeleteCustomer.Name = "chkDeleteCustomer";
            chkDeleteCustomer.Size = new Size(142, 24);
            chkDeleteCustomer.TabIndex = 5;
            chkDeleteCustomer.Text = "Delete Customer";
            chkDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // chkAnalytics
            // 
            chkAnalytics.AutoSize = true;
            chkAnalytics.Location = new Point(99, 202);
            chkAnalytics.Name = "chkAnalytics";
            chkAnalytics.Size = new Size(90, 24);
            chkAnalytics.TabIndex = 6;
            chkAnalytics.Text = "Analytics";
            chkAnalytics.UseVisualStyleBackColor = true;
            // 
            // chkExportExcel
            // 
            chkExportExcel.AutoSize = true;
            chkExportExcel.Location = new Point(99, 236);
            chkExportExcel.Name = "chkExportExcel";
            chkExportExcel.Size = new Size(130, 24);
            chkExportExcel.TabIndex = 7;
            chkExportExcel.Text = "Export to Excel";
            chkExportExcel.UseVisualStyleBackColor = true;
            chkExportExcel.CheckedChanged += chkExportExcel_CheckedChanged;
            // 
            // chkExportPdf
            // 
            chkExportPdf.AutoSize = true;
            chkExportPdf.Location = new Point(99, 266);
            chkExportPdf.Name = "chkExportPdf";
            chkExportPdf.Size = new Size(117, 24);
            chkExportPdf.TabIndex = 8;
            chkExportPdf.Text = "Export to Pdf";
            chkExportPdf.UseVisualStyleBackColor = true;
            chkExportPdf.CheckedChanged += chkExportPdf_CheckedChanged;
            // 
            // chkAuditLogs
            // 
            chkAuditLogs.AutoSize = true;
            chkAuditLogs.Location = new Point(99, 296);
            chkAuditLogs.Name = "chkAuditLogs";
            chkAuditLogs.Size = new Size(102, 24);
            chkAuditLogs.TabIndex = 9;
            chkAuditLogs.Text = "Audit Logs";
            chkAuditLogs.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SkyBlue;
            btnSave.Location = new Point(52, 362);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(149, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save Permissions";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.SkyBlue;
            btnClose.Location = new Point(279, 362);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmManagePermissions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(432, 413);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(chkAuditLogs);
            Controls.Add(chkExportPdf);
            Controls.Add(chkExportExcel);
            Controls.Add(chkAnalytics);
            Controls.Add(chkDeleteCustomer);
            Controls.Add(chkEditCustomer);
            Controls.Add(chkAddCustomer);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmManagePermissions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Permissions";
            Load += frmManagePermissions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblRole;
        private ComboBox cmbRole;
        private CheckBox chkAddCustomer;
        private CheckBox chkEditCustomer;
        private CheckBox chkDeleteCustomer;
        private CheckBox chkAnalytics;
        private CheckBox chkExportExcel;
        private CheckBox chkExportPdf;
        private CheckBox chkAuditLogs;
        private Button btnSave;
        private Button btnClose;

        private void chkExportExcel_CheckedChanged(object sender, EventArgs e)
        {
            // handle Export to Excel permission change (implement as needed)
        }

        private void chkExportPdf_CheckedChanged(object sender, EventArgs e)
        {
            // handle Export to Pdf permission change (implement as needed)
        }
    }
}