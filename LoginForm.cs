﻿using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace dreamClock
{
    public partial class LoginForm : Form
    {
        public bool LoginSuccessful { get; private set; }
        public int UserRoleID { get; private set; }
        public int UserLoginID { get; private set; }
        public int EmployeeID { get; private set; }
        public bool IsUserCEO { get; private set; } // Property to determine if the user is a CEO

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = userNameTxt.Text;
            string password = passwordTxt.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            if (password.Length < 5)
            {
                MessageBox.Show("Password must be at least 8 characters in length.");
                return;
            }

            if (!IsValidInput(username) || !IsValidInput(password))
            {
                MessageBox.Show("Username and password cannot contain special characters.");
                return;
            }

            AttemptLogin(username, password);
        }

        private void AttemptLogin(string username, string password)
        {
            var datasource = @"DESKTOP-0ANVP6M\NORTH_WIND"; // Note the addition of \NORTH_WIND
            var database = "Qwerty"; // Updated database name
            var connString = $"Data Source={datasource};Initial Catalog={database};Integrated Security=True;Encrypt=False";


            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Adjusted to include RoleID in the SELECT to check for CEO role later
                    string sql = @"
                        SELECT e.EmployeeID, e.RoleID, l.LoginID 
                        FROM Employees e 
                        INNER JOIN Login l ON e.EmployeeID = l.EmployeeID 
                        WHERE e.Username = @username AND e.Password = @password";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login Successful");
                                this.LoginSuccessful = true;
                                this.UserRoleID = reader.GetInt32(reader.GetOrdinal("RoleID"));
                                this.EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID"));
                                this.UserLoginID = reader.GetInt32(reader.GetOrdinal("LoginID"));
                                // Check if the logged-in user is a CEO
                                // Assuming that the CEO's RoleID is known, e.g., 1
                                this.IsUserCEO = this.UserRoleID == 1;
                                //need to add HR method to program.cs & mainform
                                this.DialogResult = DialogResult.OK; // Signal success
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                                this.LoginSuccessful = false;
                                this.DialogResult = DialogResult.None; // Signal failure
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private bool IsValidInput(string input)
        {
            //This regex matches strings that consist of only letters and numbers.
            //Regex regex = new Regex("^[a-zA-Z0-9]+$");
            //return regex.IsMatch(input);
            return true;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}