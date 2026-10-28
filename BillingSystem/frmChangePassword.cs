//ACTIVITY 6.1
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            AppTheme.Apply(this);
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string retype = txtRetypePassword.Text;

            // Make sure nothing is blank
            if (string.IsNullOrEmpty(current) || string.IsNullOrEmpty(newPass)
                || string.IsNullOrEmpty(retype))
            {
                MessageBox.Show("Please fill in all fields.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validation 1: current password must match the database
                if (!IsCurrentPasswordCorrect(current))
                {
                    MessageBox.Show("Current password is incorrect.",
                        "Change Password", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtCurrentPassword.Clear();
                    txtCurrentPassword.Focus();
                    return;
                }

                // Validation 2: new and retype must match
                if (newPass != retype)
                {
                    MessageBox.Show("New Password and Retype Password do not match.",
                        "Change Password", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtRetypePassword.Clear();
                    txtRetypePassword.Focus();
                    return;
                }

                // Validation 3: complexity rules (shows ALL unmet rules at once)
                List<string> missing = GetMissingRules(newPass);
                if (missing.Count > 0)
                {
                    MessageBox.Show(
                        "The new password does not meet these requirements:\n\n- "
                        + string.Join("\n- ", missing),
                        "Weak Password", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    return;
                }

                // All validations passed: save
                UpdatePassword(newPass);

                AuditLogger.Log("CHANGE_PASSWORD",
                    $"{AppSession.CurrentUsername} changed their password.");

                MessageBox.Show("Password changed successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Checks the typed password against the logged-in user's row
        private bool IsCurrentPasswordCorrect(string current)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM Users
                               WHERE UserID = @UserID AND Password = @Password;";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                    cmd.Parameters.AddWithValue("@Password", current);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // Returns a list of every rule the password fails
        private List<string> GetMissingRules(string pw)
        {
            var missing = new List<string>();
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char c in pw)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsWhiteSpace(c)) hasSpecial = true;
            }

            if (pw.Length < 8) missing.Add("At least 8 characters long");
            if (!hasUpper) missing.Add("At least one uppercase letter (A-Z)");
            if (!hasLower) missing.Add("At least one lowercase letter (a-z)");
            if (!hasDigit) missing.Add("At least one number (0-9)");
            if (!hasSpecial) missing.Add("At least one special character (e.g. !@#$%^&*)");
            return missing;
        }

        // Parameterized UPDATE: only the logged-in user's row
        private void UpdatePassword(string newPass)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Users SET Password = @NewPassword
                               WHERE UserID = @UserID;";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPass);
                    cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}