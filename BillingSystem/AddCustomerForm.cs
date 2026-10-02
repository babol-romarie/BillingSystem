using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem
{
    public partial class AddCustomerForm : Form // Edited by: Mae Ann M. Cumpleto
    {
        // Constructor for ADD mode (no parameters)
        public AddCustomerForm()
        {
            InitializeComponent();
            _editCustomerId = 0;
            PrepareForPostSave();

            // Attach a post-save handler to allow the form to signal success to the caller
            btnSave.Click += BtnSave_PostClick;
        }

        // Constructor for EDIT mode — receives the CustomerID to edit
        public AddCustomerForm(int customerId)
        {
            InitializeComponent();
            _editCustomerId = customerId;

            // Attach a post-save handler to allow the form to signal success to the caller
            btnSave.Click += BtnSave_PostClick;
        }



        //ACT.4
        // 0 = Add mode (new customer)
        // > 0 = Edit mode (holds the CustomerID being edited)
        private int _editCustomerId = 0;

        // Placeholder method to allow post-save handler registrations in a later patch.
        // Currently empty to avoid changing behavior; will be populated in a follow-up.
        private void PrepareForPostSave()
        {
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }
        private void BtnSave_PostClick(object sender, EventArgs e)
        {
            // Only act in edit mode
            if (_editCustomerId <= 0) return;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT FullName, Address, ContactNumber, Email, Balance
                           FROM   Customers
                           WHERE  CustomerID = @CustomerID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", _editCustomerId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string dbFullName = reader.GetString("FullName");
                                string dbAddress = reader.GetString("Address");
                                string dbContact = reader.GetString("ContactNumber");
                                string dbEmail = reader.GetString("Email");
                                decimal dbBalance = reader.GetDecimal("Balance");

                                decimal formBalance = 0m;
                                decimal.TryParse(txtBalance.Text, out formBalance);

                                bool matches = string.Equals(dbFullName?.Trim(), txtFullName.Text.Trim(), StringComparison.Ordinal) &&
                                               string.Equals(dbAddress?.Trim(), txtAddress.Text.Trim(), StringComparison.Ordinal) &&
                                               string.Equals(dbContact?.Trim(), txtContact.Text.Trim(), StringComparison.Ordinal) &&
                                               string.Equals(dbEmail?.Trim(), txtEmail.Text.Trim(), StringComparison.Ordinal) &&
                                               Math.Abs(dbBalance - formBalance) < 0.01m;

                                if (matches)
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Ignore any errors in the post-check; do not prevent user from continuing
            }
        }

        private void InsertCustomer()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Parameterized INSERT — safe from SQL injection
                    string sql = @"INSERT INTO Customers
                               (FullName, Address, ContactNumber, Email, Balance, Status)
                           VALUES
                               (@FullName, @Address, @ContactNumber, @Email, @Balance, @Status);";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // Each @parameter safely carries one value from the form
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Balance", decimal.Parse(txtBalance.Text));
                        cmd.Parameters.AddWithValue("@Status", "Active");

                        // ExecuteNonQuery runs INSERT/UPDATE/DELETE and
                        // returns the number of rows affected
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer saved successfully.",
                                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Step 1: Validate input before touching the database
            if (!ValidateInputs()) return;

            if (_editCustomerId == 0)
            {
                InsertCustomer();   // ADD mode — from Activity 3
            }
            else
            {
                UpdateCustomer();   // EDIT mode — new in Activity 4
            }
        }

        //ACT.4
        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            if (_editCustomerId > 0)
            {
                // EDIT MODE — change the title and load existing data
                lblTitle.Text = "Edit Customer";
                this.Text = "Billing System - Edit Customer";
                LoadCustomerData(_editCustomerId);
            }
            else
            {
                // ADD MODE — set default values
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

                    string sql = @"SELECT FullName, Address, ContactNumber, Email, Balance
                           FROM   Customers
                           WHERE  CustomerID = @CustomerID;";

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
                            }
                            else
                            {
                                MessageBox.Show("Customer record not found.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            // Check Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            // Check Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            // Check Contact Number
            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Contact Number is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }

            // Check Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Check Balance is a valid number
            if (!decimal.TryParse(txtBalance.Text, out _))
            {
                MessageBox.Show("Initial Balance must be a valid number (e.g. 0.00).",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBalance.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtBalance.Text = "0.00";
            txtFullName.Focus();
        }

        private void UpdateCustomer()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Parameterized UPDATE — only the row matching
                    // @CustomerID is changed
                    string sql = @"UPDATE Customers
                           SET    FullName      = @FullName,
                                  Address       = @Address,
                                  ContactNumber = @ContactNumber,
                                  Email         = @Email,
                                  Balance       = @Balance
                           WHERE  CustomerID    = @CustomerID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Balance", decimal.Parse(txtBalance.Text));
                        cmd.Parameters.AddWithValue("@CustomerID", _editCustomerId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer updated successfully.",
                                "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Close the form — CustomerListForm will refresh on close
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. The record may no longer exist.",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}