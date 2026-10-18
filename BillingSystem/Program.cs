namespace BillingSystem
{
    // Member A and Member B both updated this namespace
    internal static class Program
    {                                       //  Edited by Member A (Abigail libanan) and 
                                                      //Member B (Mae Ann Cumpleto)
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // One-time cleanup: clear Username/Role for historical audit rows
            // that accidentally recorded machine user or generic role. Adjust
            // the IDs below as needed. This runs silently if it fails.
            try
            {
                BillingSystem.Utils.AuditLogger.ClearUsernameRoleForLogIds(new int[] { 7, 8, 9 });
            }
            catch { }

            // Start the application at the Login form so users must authenticate
            // before accessing the Customer List and other features.
            Application.Run(new LoginForm());
        }
    }
}
