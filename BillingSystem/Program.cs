namespace BillingSystem
{
    // Member A and Member B both updated this namespace
    internal static class Program
    {                                                 //Member A (Abigail libanan)
                                                      //Member B (Mae Ann Cumpleto)
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
            Application.Run(new CustomerListForm());
            Application.Run(new AddCustomerForm());
            // Application.Run(new EditAddCustomerForm()); // from Member A
        }
    }
}
