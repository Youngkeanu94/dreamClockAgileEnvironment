using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dreamClock
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public static string username = "";
        public static string password = "";
        private void LoginButton_Click(object sender, EventArgs e)
        {
            username = userNameTxt.Text;
            password = passwordTxt.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.");
            }
            else if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters in length.");
            }
            else if (!IsValidInput(username) || !IsValidInput(password))
            {
                MessageBox.Show("Username and password cannot contain special characters.");
            }
            else
            {
                var datasource = @"DESKTOP-0ANVP6M\SQLEXPRESS";
                var database = "IT488_Tech_Solutions";
                var connString = $"Data Source={datasource};Initial Catalog={database};Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "SELECT COUNT(*) FROM Login WHERE Username = @username AND Password = @password";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);

                            int count = (int)cmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Login Successful");
                                LoginForm frm1 = new LoginForm();
                                frm1.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }

        // Function to validate input (allow only letters, numbers, and underscore)
        private bool IsValidInput(string input)
        {
            Regex regex = new Regex("^[a-zA-Z0-9_]*$");
            return regex.IsMatch(input);
        }
    }

}
 