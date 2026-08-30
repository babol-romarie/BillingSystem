namespace Billing_System
{
    // Member A and Member B both updated this namespace
    internal static class Program
    {
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
