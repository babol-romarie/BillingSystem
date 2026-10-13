using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;                       
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem
{
    public partial class LoginForm : Form         //Edited by Abigail C. Libanan
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Billing System - Login (A.L)";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Test the database connection when the form opens.
            // This gives a clear warning if MySQL is not running.
            // Try opening a connection at startup so we can show a full error now
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cannot connect to the database:\n" + ex.ToString(),
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            txtUsername.Focus();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Step 1: Make sure both fields are filled
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Step 2: Query the Users table to check credentials
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Parameterized query — safe from SQL injection
                    string sql = @"SELECT UserID, FullName, Role
                           FROM   users
                           WHERE  Username = @Username
                             AND  Password = @Password;";
                    string userVal = txtUsername?.Text?.Trim() ?? string.Empty;
                    string passVal = txtPassword?.Text ?? string.Empty;
                    MessageBox.Show($"Input -> User: '{userVal}', Pass: '{passVal}'", "Input Check");
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername?.Text?.Trim() ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Password", txtPassword?.Text ?? string.Empty);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Credentials matched — open the Customer List form
                                CustomerListForm listForm = new CustomerListForm();
                                listForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                // No match found — wrong credentials
                                MessageBox.Show(
                                    "Invalid username or password.\nPlease try again.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show a full exception (stack trace) during development so we can
                // see the exact cause and line where the error originated.
                MessageBox.Show(
                    "Database error:\n" + ex.ToString(),
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            txtUsername.Focus();
        }
    }
}
       