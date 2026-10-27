using System;
using System.Windows.Forms;

namespace BillingSystem
{
    // Minimal designer partial class: provides control fields and a basic InitializeComponent implementation
    public partial class CustomerListForm : Form
    {

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            dgvCustomers = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ContactNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Balance = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnDelete = new Button();
            btnLogout = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAnalytics = new Button();
            btnExportExcel = new Button();
            btnExportPdf = new Button();
            btnAuditLog = new Button();
            btnManagePermissions = new Button();
            statusStrip1 = new StatusStrip();
            lblStatusUser = new ToolStripStatusLabel();
            lblStatusSep = new ToolStripStatusLabel();
            lblStatusTime = new ToolStripStatusLabel();
            statusTimer = new System.Windows.Forms.Timer(components);
            btnChangePassword = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer List ";
            lblTitle.Click += lblTitle_Click_1;
            // 
            // dgvCustomers
            // 
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = SystemColors.Control;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance, Status });
            dgvCustomers.Location = new Point(21, 50);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(740, 229);
            dgvCustomers.TabIndex = 1;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "ID";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            // 
            // FullName
            // 
            FullName.HeaderText = "Full Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // Address
            // 
            Address.HeaderText = "Address";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            // 
            // ContactNumber
            // 
            ContactNumber.HeaderText = "Contact Number";
            ContactNumber.MinimumWidth = 6;
            ContactNumber.Name = "ContactNumber";
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // Balance
            // 
            Balance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Balance.HeaderText = "Balance";
            Balance.MinimumWidth = 6;
            Balance.Name = "Balance";
            Balance.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // btnAdd
            // 
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(112, 304);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Customer";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(339, 304);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(128, 128, 255);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(554, 304);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(350, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(167, 27);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(530, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(71, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // btnAnalytics
            // 
            btnAnalytics.ForeColor = Color.Black;
            btnAnalytics.Location = new Point(339, 339);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(94, 29);
            btnAnalytics.TabIndex = 7;
            btnAnalytics.Text = "Analytics";
            btnAnalytics.UseVisualStyleBackColor = true;
            btnAnalytics.Click += btnAnalytics_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = SystemColors.Control;
            btnExportExcel.ForeColor = Color.Black;
            btnExportExcel.Location = new Point(112, 339);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(128, 29);
            btnExportExcel.TabIndex = 8;
            btnExportExcel.Text = "Export to Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.ForeColor = Color.Black;
            btnExportPdf.Location = new Point(541, 339);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(122, 29);
            btnExportPdf.TabIndex = 9;
            btnExportPdf.Text = "Export to PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // btnAuditLog
            // 
            btnAuditLog.ForeColor = Color.Black;
            btnAuditLog.Location = new Point(251, 374);
            btnAuditLog.Name = "btnAuditLog";
            btnAuditLog.Size = new Size(94, 29);
            btnAuditLog.TabIndex = 10;
            btnAuditLog.Text = "Audit Log";
            btnAuditLog.UseVisualStyleBackColor = true;
            btnAuditLog.Click += btnAuditLog_Click;
            // 
            // btnManagePermissions
            // 
            btnManagePermissions.BackColor = SystemColors.Control;
            btnManagePermissions.ForeColor = Color.Black;
            btnManagePermissions.Location = new Point(609, 12);
            btnManagePermissions.Name = "btnManagePermissions";
            btnManagePermissions.Size = new Size(161, 29);
            btnManagePermissions.TabIndex = 11;
            btnManagePermissions.Text = "Manage Permissions";
            btnManagePermissions.UseVisualStyleBackColor = false;
            btnManagePermissions.Click += btnManagePermissions_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusUser, lblStatusSep, lblStatusTime });
            statusStrip1.Location = new Point(0, 427);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(782, 26);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusUser
            // 
            lblStatusUser.Name = "lblStatusUser";
            lblStatusUser.Size = new Size(151, 20);
            lblStatusUser.Text = "toolStripStatusLabel1";
            // 
            // lblStatusSep
            // 
            lblStatusSep.Name = "lblStatusSep";
            lblStatusSep.Size = new Size(465, 20);
            lblStatusSep.Spring = true;
            lblStatusSep.Click += lblStatusSep_Click;
            // 
            // lblStatusTime
            // 
            lblStatusTime.Name = "lblStatusTime";
            lblStatusTime.Size = new Size(151, 20);
            lblStatusTime.Text = "toolStripStatusLabel3";
            lblStatusTime.Click += lblStatusTime_Click;
            // 
            // statusTimer
            // 
            statusTimer.Enabled = true;
            statusTimer.Interval = 1000;
            statusTimer.Tick += statusTimer_Tick;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(255, 128, 128);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(422, 374);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(132, 29);
            btnChangePassword.TabIndex = 13;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // CustomerListForm
            // 
            ClientSize = new Size(782, 453);
            Controls.Add(btnChangePassword);
            Controls.Add(statusStrip1);
            Controls.Add(btnManagePermissions);
            Controls.Add(btnAuditLog);
            Controls.Add(btnExportPdf);
            Controls.Add(btnExportExcel);
            Controls.Add(btnAnalytics);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnLogout);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvCustomers);
            Controls.Add(lblTitle);
            Name = "CustomerListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += CustomerListForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvCustomers;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnLogout;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ContactNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Balance;
        private DataGridViewTextBoxColumn Status;
        private Button btnAnalytics;
        private Button btnExportExcel;
        private Button btnExportPdf;
        private Button btnAuditLog;
        private Button btnManagePermissions;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatusUser;
        private ToolStripStatusLabel lblStatusSep;
        private ToolStripStatusLabel lblStatusTime;
        private System.Windows.Forms.Timer statusTimer;
        private System.ComponentModel.IContainer components;
        private Button btnChangePassword;
    }
}
