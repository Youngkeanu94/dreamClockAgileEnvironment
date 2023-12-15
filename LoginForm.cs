using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
   

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LogIn();
        }
        private void LogIn()
        {
            string conString = Constants.connection;
            SqlConnection connection = new SqlConnection(conString);
            //***********Stored procedure name needs to go on the line below with ""************
            //SqlCommand sqlCommand = new SqlCommand(, connection);
            //SqlCommand.CommandType = CommandType.StoredProcedure;
            //SqlCommand.Parameters.AddWithValue("@userName", userNameTxt.Text);
            //SqlCommand.Parameters.AddWithValue("@password", passwordTxt.Text);
            object obj = (object)null;
            try
            {
                connection.Open();
                //return first column of the first row query below
               //obj = SqlCommand.ExecuteScalar();
            }
            //catch (Exception ex)
           // {
           //     this.Close();
           // }
            finally
            {
                connection.Close();
                if (obj != null)
                {
                    MessageBox.Show("Invalid username or password");
                }
                else
                {
                    MessageBox.Show("LogIn successful");
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
            }
        }
    }
}
