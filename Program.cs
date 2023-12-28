using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dreamClock
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm loginForm = new LoginForm())
            {
                DialogResult result = loginForm.ShowDialog();
                if (result == DialogResult.OK)  // ShowDialog is used to display the login form as a modal dialog box
                {
                    Application.Run(new MainForm()); // Only run MainForm if login is successful
                }
                // If ShowDialog doesn't return DialogResult.OK, the application will end

            }
        }
    }
}


