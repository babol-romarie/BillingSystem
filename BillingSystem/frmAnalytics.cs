using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using ScottPlot;

namespace BillingSystem
{
    public partial class frmAnalytics : Form
    {
        public frmAnalytics()
        {
            InitializeComponent();
            dgvTop5.AutoGenerateColumns = false;
            dgvTop5.Columns["FullName"]!.DataPropertyName = "FullName";
            dgvTop5.Columns["TotalConsumption"]!.DataPropertyName = "TotalConsumption";
            dgvTop5.Columns["TotalBilled"]!.DataPropertyName = "TotalBilled";
            // Ensure the Load event is handled (designer did not wire it)
            this.Load += frmAnalytics_Load;
        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            LoadKpiSummary();
            LoadMonthlyRevenueChart();
            LoadPaidUnpaidChart();
            LoadTop5Customers();
        }
        private void LoadKpiSummary()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // 1) Total number of customers
                    string sqlCustomers = "SELECT COUNT(*) FROM Customers;";
                    using (var cmd = new MySqlCommand(sqlCustomers, conn))
                    {
                        int totalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                        lblTotalCustomers.Text = $"Total Customers: {totalCustomers}";
                    }

                    // 2) Total revenue — sum of all PAID bills
                    string sqlRevenue = @"SELECT IFNULL(SUM(TotalAmount), 0)
                                  FROM   Billing
                                  WHERE  Status = 'Paid';";
                    using (var cmd = new MySqlCommand(sqlRevenue, conn))
                    {
                        decimal totalRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalRevenue.Text = $"Total Revenue: ₱{totalRevenue:N2}";
                    }

                    // 3) Total unpaid — sum of all UNPAID bills
                    string sqlUnpaid = @"SELECT IFNULL(SUM(TotalAmount), 0)
                                 FROM   Billing
                                 WHERE  Status = 'Unpaid';";
                    using (var cmd = new MySqlCommand(sqlUnpaid, conn))
                    {
                        decimal totalUnpaid = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalUnpaid.Text = $"Total Unpaid: ₱{totalUnpaid:N2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading KPI summary:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCloseAnalytics_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void plotPaidUnpaid_Load(object sender, EventArgs e)
        {

        }
        private void LoadTop5Customers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT c.FullName,
                                  SUM(b.Consumption)  AS TotalConsumption,
                                  SUM(b.TotalAmount)  AS TotalBilled
                           FROM   Customers c
                           INNER JOIN Billing b ON c.CustomerID = b.CustomerID
                           GROUP  BY c.CustomerID, c.FullName
                           ORDER  BY TotalConsumption DESC
                           LIMIT  5;";

                    using (var adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTop5.DataSource = dt;

                        if (dgvTop5.Columns.Count > 0)
                        {
                            dgvTop5.Columns["FullName"].HeaderText = "Customer Name";
                            dgvTop5.Columns["TotalConsumption"].HeaderText = "Total Consumption (kWh)";
                            dgvTop5.Columns["TotalBilled"].HeaderText = "Total Billed (₱)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Top 5 customers:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadMonthlyRevenueChart()
        {
            try
            {
                // We want to show January to June 2026 explicitly.
                string[] monthLabels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
                double[] values = new double[6]; // defaults to 0

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // The Billing table already has a BillingMonth column with values like "January 2026".
                    // Query paid bills grouped by that column and map the results to Jan..Jun slots.
                    string sql = @"SELECT BillingMonth, IFNULL(SUM(TotalAmount),0) AS MonthlyTotal
                                   FROM Billing
                                   WHERE Status = 'Paid' AND BillingMonth IS NOT NULL
                                   GROUP BY BillingMonth;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string bm = reader.GetString("BillingMonth").Trim();
                            decimal total = reader.GetDecimal("MonthlyTotal");

                            // Determine index 0..5 for Jan..Jun 2026
                            int idx = -1;
                            if (bm.StartsWith("January", StringComparison.OrdinalIgnoreCase) && bm.Contains("2026")) idx = 0;
                            else if (bm.StartsWith("February", StringComparison.OrdinalIgnoreCase) && bm.Contains("2026")) idx = 1;
                            else if (bm.StartsWith("March", StringComparison.OrdinalIgnoreCase) && bm.Contains("2026")) idx = 2;
                            else if (bm.StartsWith("April", StringComparison.OrdinalIgnoreCase) && bm.Contains("2026")) idx = 3;
                            else if (bm.StartsWith("May", StringComparison.OrdinalIgnoreCase) && bm.Contains("2026")) idx = 4;
                            else if (bm.StartsWith("June", StringComparison.OrdinalIgnoreCase) && bm.Contains("2026")) idx = 5;

                            if (idx >= 0 && idx < values.Length)
                                values[idx] = (double)total;
                        }
                    }
                }

                // Clear and draw
                plotMonthlyRevenue.Plot.Clear();
                // positions 0..5
                double[] positions = new double[values.Length];
                for (int i = 0; i < positions.Length; i++) positions[i] = i;

                var bar = plotMonthlyRevenue.Plot.Add.Bars(values);
                // positions 0..n-1
                double[] positionsD = new double[values.Length];
                for (int i = 0; i < positionsD.Length; i++) positionsD[i] = i;
                plotMonthlyRevenue.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positionsD, monthLabels);
                plotMonthlyRevenue.Plot.Title("Monthly Revenue (Jan–Jun 2026) - Paid Bills");
                plotMonthlyRevenue.Plot.YLabel("Revenue (₱)");
                plotMonthlyRevenue.Plot.XLabel("Month");

                plotMonthlyRevenue.Plot.Axes.AutoScale();

                // Debug: show the loaded values so we can verify mapping
                double sum = 0;
                double min = double.MaxValue;
                double max = double.MinValue;
                for (int i = 0; i < values.Length; i++)
                {
                    double v = values[i];
                    sum += v;
                    if (v < min) min = v;
                    if (v > max) max = v;
                }
                if (min == double.MaxValue) min = 0;
                if (max == double.MinValue) max = 0;

                plotMonthlyRevenue.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly revenue chart:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaidUnpaidChart()
        {
            try
            {
                int paidCount = 0;
                int unpaidCount = 0;

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Group all bills by status and count each group
                    string sql = @"SELECT Status, COUNT(*) AS StatusCount
                                   FROM   Billing
                                   GROUP  BY Status;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader.GetString("Status");
                            int count = reader.GetInt32("StatusCount");

                            if (status == "Paid") paidCount = count;
                            if (status == "Unpaid") unpaidCount = count;
                        }
                    }
                }

                // Clear any existing plot before drawing a new one
                plotPaidUnpaid.Plot.Clear();

                // Build the pie slices: Paid and Unpaid
                double[] values = { paidCount, unpaidCount };
                string[] labels = { "Paid", "Unpaid" };
                double total = paidCount + unpaidCount;

                var pie = plotPaidUnpaid.Plot.Add.Pie(values);
                for (int i = 0; i < pie.Slices.Count; i++)
                {
                    pie.Slices[i].Label = $"{labels[i]} ({(total == 0 ? 0 : values[i] / total):P0})";
                }
                pie.SliceLabelDistance = 0.5;   // place labels on the slices

                plotPaidUnpaid.Plot.Title("Paid vs Unpaid Bills");
                plotPaidUnpaid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Paid/Unpaid chart:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
