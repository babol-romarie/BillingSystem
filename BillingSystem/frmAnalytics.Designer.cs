namespace BillingSystem
{
    partial class frmAnalytics
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
            plotMonthlyRevenue = new ScottPlot.WinForms.FormsPlot();
            lblTitle = new Label();
            lblTotalCustomers = new Label();
            lblTotalRevenue = new Label();
            lblTotalUnpaid = new Label();
            plotPaidUnpaid = new ScottPlot.WinForms.FormsPlot();
            lblTop5Title = new Label();
            dgvTop5 = new DataGridView();
            FullName = new DataGridViewTextBoxColumn();
            TotalConsumption = new DataGridViewTextBoxColumn();
            TotalBilled = new DataGridViewTextBoxColumn();
            btnCloseAnalytics = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).BeginInit();
            SuspendLayout();
            // 
            // plotMonthlyRevenue
            // 
            plotMonthlyRevenue.Location = new Point(48, 85);
            plotMonthlyRevenue.Name = "plotMonthlyRevenue";
            plotMonthlyRevenue.Size = new Size(442, 254);
            plotMonthlyRevenue.TabIndex = 0;
            plotMonthlyRevenue.Load += plotMonthlyRevenue_Load;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(381, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(234, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Analytics Dashboard";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Location = new Point(185, 62);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(130, 20);
            lblTotalCustomers.TabIndex = 2;
            lblTotalCustomers.Text = "Total Customers: 0";
            lblTotalCustomers.Click += lblTotalCustomers_Click;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Location = new Point(430, 62);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(145, 20);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "Total Revenue: ₱0.00";
            lblTotalRevenue.Click += lblTotalRevenue_Click;
            // 
            // lblTotalUnpaid
            // 
            lblTotalUnpaid.AutoSize = true;
            lblTotalUnpaid.Location = new Point(670, 62);
            lblTotalUnpaid.Name = "lblTotalUnpaid";
            lblTotalUnpaid.Size = new Size(137, 20);
            lblTotalUnpaid.TabIndex = 4;
            lblTotalUnpaid.Text = "Total Unpaid: ₱0.00";
            // 
            // plotPaidUnpaid
            // 
            plotPaidUnpaid.Location = new Point(531, 85);
            plotPaidUnpaid.Name = "plotPaidUnpaid";
            plotPaidUnpaid.Size = new Size(439, 227);
            plotPaidUnpaid.TabIndex = 5;
            plotPaidUnpaid.Load += formsPlot2_Load;
            // 
            // lblTop5Title
            // 
            lblTop5Title.AutoSize = true;
            lblTop5Title.Location = new Point(48, 342);
            lblTop5Title.Name = "lblTop5Title";
            lblTop5Title.Size = new Size(231, 20);
            lblTop5Title.TabIndex = 6;
            lblTop5Title.Text = "Top 5 Customers by Consumption";
            // 
            // dgvTop5
            // 
            dgvTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop5.Columns.AddRange(new DataGridViewColumn[] { FullName, TotalConsumption, TotalBilled });
            dgvTop5.Location = new Point(98, 365);
            dgvTop5.Name = "dgvTop5";
            dgvTop5.RowHeadersWidth = 51;
            dgvTop5.Size = new Size(812, 191);
            dgvTop5.TabIndex = 7;
            dgvTop5.CellContentClick += dgvTop5_CellContentClick;
            // 
            // FullName
            // 
            FullName.FillWeight = 40F;
            FullName.HeaderText = "FullName";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // TotalConsumption
            // 
            TotalConsumption.FillWeight = 30F;
            TotalConsumption.HeaderText = "TotalConsumption";
            TotalConsumption.MinimumWidth = 6;
            TotalConsumption.Name = "TotalConsumption";
            // 
            // TotalBilled
            // 
            TotalBilled.FillWeight = 30F;
            TotalBilled.HeaderText = "TotalBilled";
            TotalBilled.MinimumWidth = 6;
            TotalBilled.Name = "TotalBilled";
            // 
            // btnCloseAnalytics
            // 
            btnCloseAnalytics.Location = new Point(816, 562);
            btnCloseAnalytics.Name = "btnCloseAnalytics";
            btnCloseAnalytics.Size = new Size(94, 29);
            btnCloseAnalytics.TabIndex = 8;
            btnCloseAnalytics.Text = "Close";
            btnCloseAnalytics.UseVisualStyleBackColor = true;
            btnCloseAnalytics.Click += btnCloseAnalytics_Click;
            // 
            // frmAnalytics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCloseAnalytics);
            Controls.Add(dgvTop5);
            Controls.Add(lblTop5Title);
            Controls.Add(plotPaidUnpaid);
            Controls.Add(lblTotalUnpaid);
            Controls.Add(lblTotalRevenue);
            Controls.Add(lblTotalCustomers);
            Controls.Add(lblTitle);
            Controls.Add(plotMonthlyRevenue);
            Name = "frmAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System - Analytics Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmAnalytics_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTop5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plotMonthlyRevenue;
        private Label lblTitle;
        private Label lblTotalCustomers;
        private Label lblTotalRevenue;
        private Label lblTotalUnpaid;
        private ScottPlot.WinForms.FormsPlot plotPaidUnpaid;
        private Label lblTop5Title;
        private DataGridView dgvTop5;
        private Button btnCloseAnalytics;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn TotalConsumption;
        private DataGridViewTextBoxColumn TotalBilled;
    }
}