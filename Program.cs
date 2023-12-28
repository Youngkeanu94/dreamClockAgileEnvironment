using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dreamClock
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm loginForm = new LoginForm())
            {
                DialogResult result = loginForm.ShowDialog();
                if (result == DialogResult.OK) // Just check if DialogResult is OK
                {
                    // Assuming you have a way to determine if the logged-in user is a CEO inside LoginForm
                    // For example, loginForm.IsUserCEO could be a property you set after successful login based on their role
                    bool isCEO = loginForm.IsUserCEO;

                    // Pass both the UserRoleID and isCEO flag to MainForm
                    MainForm mainForm = new MainForm(loginForm.UserRoleID, isCEO);
                    Application.Run(mainForm);
                }
                // If ShowDialog doesn't return DialogResult.OK, the application will end
            }
        }
    }
}



