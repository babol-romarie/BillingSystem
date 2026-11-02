using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BillingSystem   // keep YOUR project's namespace here
{
    public partial class frmBillingHistory : Form
    {
        private int customerId;
        private string ConnectionString => "server=192.168.8.38;database=billingdb;uid=billing_user;pwd=BillingPass123!;";
        // ^ use the same connection string (or connection class) as your other forms

        public frmBillingHistory(int id)
        {
            InitializeComponent();
            customerId = id;
            AppTheme.Apply(this);
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {
            if (LoadCustomerName())
            {
                LoadBillingRecords();
            }
            else
            {
                MessageBox.Show("Customer not found in the database.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); 
            }
        }

        // Gets the name from the Customers table (requirement 3.4)
        private bool LoadCustomerName()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT FullName FROM Customers WHERE CustomerID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", customerId);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result == null) return false;

                lblCustomerName.Text = "Billing History — " + result.ToString();
                return true;
            }
        }

        private void LoadBillingRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = @"SELECT 
                          BillingMonth AS `Billing Month`,
                          PreviousReading AS `Previous Reading`,
                          PresentReading AS `Present Reading`,
                          Consumption,
                          RatePerCubic AS `Rate Per Cubic`,
                          TotalAmount AS `Total Amount`,
                          Status
                       FROM Billing
                       WHERE CustomerID = @id
                       ORDER BY BillingDate DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", customerId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvBilling.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No billing records were found for this customer.",
                        "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BeginInvoke(new Action(this.Close));   // go back to the Customer List
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}