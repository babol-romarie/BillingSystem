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
            dgvTop5 = new DataGridView();
            FullName = new DataGridViewTextBoxColumn();
            TotalConsumption = new DataGridViewTextBoxColumn();
            TotalBilled = new DataGridViewTextBoxColumn();
            plotMonthlyRevenue = new ScottPlot.WinForms.FormsPlot();
            lblTotalCustomers = new Label();
            lblTotalRevenue = new Label();
            lblTotalUnpaid = new Label();
            plotPaidUnpaid = new ScottPlot.WinForms.FormsPlot();
            btnCloseAnalytics = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).BeginInit();
            SuspendLayout();
            // 
            // dgvTop5
            // 
            dgvTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop5.Columns.AddRange(new DataGridViewColumn[] { FullName, TotalConsumption, TotalBilled });
            dgvTop5.Location = new Point(42, 390);
            dgvTop5.Name = "dgvTop5";
            dgvTop5.RowHeadersWidth = 62;
            dgvTop5.Size = new Size(517, 155);
            dgvTop5.TabIndex = 0;
            // 
            // FullName
            // 
            FullName.HeaderText = "Full Name";
            FullName.MinimumWidth = 8;
            FullName.Name = "FullName";
            FullName.Width = 150;
            // 
            // TotalConsumption
            // 
            TotalConsumption.HeaderText = "Total Consumption";
            TotalConsumption.MinimumWidth = 8;
            TotalConsumption.Name = "TotalConsumption";
            TotalConsumption.Width = 150;
            // 
            // TotalBilled
            // 
            TotalBilled.HeaderText = "Total Billed";
            TotalBilled.MinimumWidth = 8;
            TotalBilled.Name = "TotalBilled";
            TotalBilled.Width = 150;
            // 
            // plotMonthlyRevenue
            // 
            plotMonthlyRevenue.Location = new Point(143, 131);
            plotMonthlyRevenue.Name = "plotMonthlyRevenue";
            plotMonthlyRevenue.Size = new Size(225, 225);
            plotMonthlyRevenue.TabIndex = 1;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Location = new Point(94, 91);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(32, 25);
            lblTotalCustomers.TabIndex = 2;
            lblTotalCustomers.Text = "10";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Location = new Point(428, 91);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(101, 25);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "₱11,000.00";
            // 
            // lblTotalUnpaid
            // 
            lblTotalUnpaid.AutoSize = true;
            lblTotalUnpaid.Location = new Point(782, 91);
            lblTotalUnpaid.Name = "lblTotalUnpaid";
            lblTotalUnpaid.Size = new Size(91, 25);
            lblTotalUnpaid.TabIndex = 4;
            lblTotalUnpaid.Text = "₱4,000.00";
            // 
            // plotPaidUnpaid
            // 
            plotPaidUnpaid.Location = new Point(530, 131);
            plotPaidUnpaid.Name = "plotPaidUnpaid";
            plotPaidUnpaid.Size = new Size(225, 225);
            plotPaidUnpaid.TabIndex = 5;
            plotPaidUnpaid.Load += plotPaidUnpaid_Load;
            // 
            // btnCloseAnalytics
            // 
            btnCloseAnalytics.Location = new Point(796, 548);
            btnCloseAnalytics.Name = "btnCloseAnalytics";
            btnCloseAnalytics.Size = new Size(112, 34);
            btnCloseAnalytics.TabIndex = 6;
            btnCloseAnalytics.Text = "Close";
            btnCloseAnalytics.UseVisualStyleBackColor = true;
            btnCloseAnalytics.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 66);
            label1.Name = "label1";
            label1.Size = new Size(139, 25);
            label1.TabIndex = 7;
            label1.Text = "Total Customers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(428, 66);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 8;
            label2.Text = "Total Revenue";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(782, 66);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 9;
            label3.Text = "Total Unpaid";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(355, 9);
            label4.Name = "label4";
            label4.Size = new Size(269, 38);
            label4.TabIndex = 10;
            label4.Text = "Analytics Dashboard";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 359);
            label5.Name = "label5";
            label5.Size = new Size(284, 25);
            label5.TabIndex = 11;
            label5.Text = "Top 5 Customers by Consumption";
            // 
            // frmAnalytics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 594);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCloseAnalytics);
            Controls.Add(plotPaidUnpaid);
            Controls.Add(lblTotalUnpaid);
            Controls.Add(lblTotalRevenue);
            Controls.Add(lblTotalCustomers);
            Controls.Add(plotMonthlyRevenue);
            Controls.Add(dgvTop5);
            Name = "frmAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System - Analytics Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvTop5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTop5;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn TotalConsumption;
        private DataGridViewTextBoxColumn TotalBilled;
        private ScottPlot.WinForms.FormsPlot plotMonthlyRevenue;
        private Label lblTotalCustomers;
        private Label lblTotalRevenue;
        private Label lblTotalUnpaid;
        private ScottPlot.WinForms.FormsPlot plotPaidUnpaid;
        private Button btnCloseAnalytics;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}