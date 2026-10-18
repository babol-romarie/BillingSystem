using System;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem.Utils
{
    /// <summary>
    /// Provides a single method to insert an audit log entry.
    /// Call AuditLogger.Log(action, details) from any form.
    /// </summary>
    public static class AuditLogger
    {
        public static void Log(string action, string details = "")
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO AuditLogs
                                        (UserID, Username, Role, Action, Details)
                                 VALUES
                                        (@UserID, @Username, @Role, @Action, @Details);";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // Use AppSession values when available. If session
                        // details are missing, write empty strings for
                        // Username/Role and 0 for UserID to satisfy DB.
                        int userIdParam = AppSession.CurrentUserID;
                        string usernameParam = string.IsNullOrWhiteSpace(AppSession.CurrentUsername) ? string.Empty : AppSession.CurrentUsername;
                        string roleParam = string.IsNullOrWhiteSpace(AppSession.CurrentRole) ? string.Empty : AppSession.CurrentRole;

                        cmd.Parameters.AddWithValue("@UserID", userIdParam);
                        cmd.Parameters.AddWithValue("@Username", usernameParam);
                        cmd.Parameters.AddWithValue("@Role", roleParam);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Details", details);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Silently ignore log failures — never crash the app
                // because of a logging error
            }
        }

        /// <summary>
        /// Clear Username and Role fields for specific audit log IDs.
        /// This is intended as a one-time cleanup for historical rows
        /// that accidentally recorded machine/user data.
        /// </summary>
        public static void ClearUsernameRoleForLogIds(int[] logIds)
        {
            if (logIds == null || logIds.Length == 0) return;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Build parameterized IN clause
                    var paramNames = new string[logIds.Length];
                    for (int i = 0; i < logIds.Length; i++) paramNames[i] = "@id" + i;

                    string sql = $"UPDATE AuditLogs SET Username = '', Role = '' WHERE LogID IN ({string.Join(",", paramNames)})";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        for (int i = 0; i < logIds.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramNames[i], logIds[i]);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // ignore errors during cleanup
            }
        }
    }
}
