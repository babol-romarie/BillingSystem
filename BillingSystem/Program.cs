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
            // Start the application at the Analytics dashboard for development/testing.
            Application.Run(new frmAnalytics());
        }
    }
}
