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
using System.Collections.Generic;
using System.Globalization;

namespace BillingSystem
{
    public partial class frmAnalytics : Form
    {
        public frmAnalytics()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            AppTheme.Apply(this);

            // Configure grid for editable cells and user-resizable columns
            dgvTop5.AutoGenerateColumns = false;

            // Allow the user to resize columns at runtime
            dgvTop5.AllowUserToResizeColumns = true;
            dgvTop5.AllowUserToOrderColumns = true;

            // Do not auto-size columns so the user can control widths
            dgvTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Make cells editable
            dgvTop5.ReadOnly = false;
            dgvTop5.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // Ensure required columns exist and make them resizable/editable
            void EnsureTop5Column(string name, string header = null)
            {
                if (!dgvTop5.Columns.Contains(name))
                {
                    var c = new DataGridViewTextBoxColumn()
                    {
                        Name = name,
                        HeaderText = header ?? name,
                        ReadOnly = false,
                        Resizable = DataGridViewTriState.True,
                        SortMode = DataGridViewColumnSortMode.NotSortable
                    };
                    dgvTop5.Columns.Add(c);
                }
                else
                {
                    dgvTop5.Columns[name].ReadOnly = false;
                    dgvTop5.Columns[name].Resizable = DataGridViewTriState.True;
                }
            }

            EnsureTop5Column("FullName");
            EnsureTop5Column("TotalConsumption");
            EnsureTop5Column("TotalBilled");

            // Map properties to columns if they are present
            if (dgvTop5.Columns.Contains("FullName"))
                dgvTop5.Columns["FullName"].DataPropertyName = "FullName";
            if (dgvTop5.Columns.Contains("TotalConsumption"))
                dgvTop5.Columns["TotalConsumption"].DataPropertyName = "TotalConsumption";
            if (dgvTop5.Columns.Contains("TotalBilled"))
                dgvTop5.Columns["TotalBilled"].DataPropertyName = "TotalBilled";
            try
            {
                plotMonthlyRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            catch { }

            try
            {
                plotPaidUnpaid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            catch { }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void formsPlot2_Load(object sender, EventArgs e)
        {

        }

        private void lblTotalRevenue_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalCustomers_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseAnalytics_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch { }

            if (this.Owner != null)
            {
                try { this.Owner.Activate(); } catch { }
            }

            this.Close();
        }



        private void plotMonthlyRevenue_Load(object sender, EventArgs e)
        {

        }

        private void dgvTop5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void LoadMonthlyRevenueChart()
        {
            try
            {
                var months = new List<string>();
                var amounts = new List<double>();

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Group PAID bills by month and sum the total amount
                    string sql = @"SELECT BillingMonth,
                                  SUM(TotalAmount) AS MonthlyTotal
                           FROM   Billing
                           WHERE  Status = 'Paid'
                           GROUP  BY BillingMonth
                           ORDER  BY MIN(BillingDate);";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            months.Add(reader.GetString("BillingMonth"));
                            amounts.Add((double)reader.GetDecimal("MonthlyTotal"));
                        }
                    }
                }

                // Clear any existing plot before drawing a new one
                plotMonthlyRevenue.Plot.Clear();

                // Add a bar chart using the amounts as bar heights
                double[] values = amounts.ToArray();
                var barPlot = plotMonthlyRevenue.Plot.Add.Bars(values);

                // Use the month names as X-axis tick labels
                double[] positions = new double[months.Count];
                for (int i = 0; i < months.Count; i++) positions[i] = i;

                // Create abbreviated month labels (e.g., Jan, Feb, Mar)
                var labels = new string[months.Count];
                for (int i = 0; i < months.Count; i++)
                {
                    string mstr = months[i];
                    DateTime dt;
                    // Try general parse first (handles many formats like "January 2026")
                    if (DateTime.TryParse(mstr, out dt))
                    {
                        labels[i] = dt.ToString("MMM", CultureInfo.InvariantCulture);
                        continue;
                    }

                    // Try exact "MMMM yyyy" pattern
                    if (DateTime.TryParseExact(mstr, "MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        labels[i] = dt.ToString("MMM", CultureInfo.InvariantCulture);
                        continue;
                    }

                    // Fallback: attempt to match the first token to month names
                    var first = mstr.Split(' ')[0];
                    if (!string.IsNullOrEmpty(first))
                    {
                        var monthNames = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames;
                        for (int mi = 0; mi < 12; mi++)
                        {
                            if (string.Equals(first, monthNames[mi], StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(first, CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames[mi], StringComparison.OrdinalIgnoreCase))
                            {
                                labels[i] = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames[mi];
                                break;
                            }
                        }
                    }

                    // Last resort: first 3 characters
                    if (string.IsNullOrEmpty(labels[i])) labels[i] = mstr.Length >= 3 ? mstr.Substring(0, 3) : mstr;
                }

                plotMonthlyRevenue.Plot.Axes.Bottom.SetTicks(positions, labels);
                plotMonthlyRevenue.Plot.Title("Monthly Revenue (Paid Bills)");
                plotMonthlyRevenue.Plot.YLabel("Revenue (₱)");
                plotMonthlyRevenue.Plot.XLabel("Month");

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
                    pie.Slices[i].Label = $"{labels[i]} ({values[i] / total:P0})";
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

        private void frmAuditLogs_Click(object sender, EventArgs e)
        {

        }
    }
}
