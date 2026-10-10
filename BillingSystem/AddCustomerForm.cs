using BillingSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class AddCustomerForm : Form
    {
        // 0 = Add mode, >0 = edit mode
        private int _editCustomerId = 0;

        public AddCustomerForm()
        {
            InitializeComponent();
            _editCustomerId = 0;
        }

        public AddCustomerForm(int customerId) : this()
        {
            _editCustomerId = customerId;
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            if (_editCustomerId > 0)
            {
                lblTitle.Text = "Edit Customer";
                this.Text = "Billing System - Edit Customer";
                LoadCustomerData(_editCustomerId);
            }
            else
            {
                lblTitle.Text = "Add New Customer";
                txtBalance.Text = "0.00";
            }
        }

        private void LoadCustomerData(int customerId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT FullName, Address, ContactNumber, Email, Balance, Status
                                   FROM Customers
                                   WHERE CustomerID = @CustomerID;";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader.GetString("FullName");
                                txtAddress.Text = reader.GetString("Address");
                                txtContact.Text = reader.GetString("ContactNumber");
                                txtEmail.Text = reader.GetString("Email");
                                txtBalance.Text = reader.GetDecimal("Balance").ToString("N2");
                                cmbStatus.Text = reader["Status"]?.ToString() ?? string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (_editCustomerId == 0)
                InsertCustomer();
            else
                UpdateCustomer();
        }

        private void InsertCustomer()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Customers (FullName, Address, ContactNumber, Email, Balance, Status)
                                   VALUES (@FullName, @Address, @ContactNumber, @Email, @Balance, @Status);";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Balance", Convert.ToDecimal(txtBalance.Text));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCustomer()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE Customers SET FullName=@FullName, Address=@Address, ContactNumber=@ContactNumber,
                                   Email=@Email, Balance=@Balance, Status=@Status WHERE CustomerID=@CustomerID;";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Balance", Convert.ToDecimal(txtBalance.Text));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", _editCustomerId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Contact Number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!decimal.TryParse(txtBalance.Text, out _))
            {
                MessageBox.Show("Initial Balance must be a valid number (e.g. 0.00).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBalance.Focus();
                return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtBalance.Text = "0.00";
            txtFullName.Focus();
        }

        // Designer event handlers referenced in InitializeComponent
        private void lblFullName_Click(object sender, EventArgs e) { }
        private void lblAddress_Click(object sender, EventArgs e) { }
    }
}