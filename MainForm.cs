using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dreamClock
{
    public partial class MainForm : Form
    {
        private int userEmployeeID;
        private bool isCEO; // A flag to indicate if the logged-in user is the CEO

        public MainForm(int employeeID, bool isCEO) // Pass the isCEO flag
        {
            InitializeComponent();
            userEmployeeID = employeeID;
            this.isCEO = isCEO; // Set the flag based on the logged-in user's role
            LoadEmployeeHours();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // This event handler is called when the MainForm loads.
            // If LoadEmployeeHours is already called in the constructor,
            // you don't need to call it here unless you want to refresh the data.
        }

        private void LoadEmployeeHours()
        {
            dataGridView1.DataSource = GetEmployeeHoursBasedOnRole(userEmployeeID, isCEO);
        }

        private DataTable GetEmployeeHoursBasedOnRole(int employeeID, bool isCEO)
        {
            DataTable dataTable = new DataTable();
            string connString = "Data Source=DESKTOP-0ANVP6M;Initial Catalog=IT488_Tech_Solutions;Integrated Security=True";
            string query;

            if (isCEO)
            {
                // If the user is a CEO, fetch hours for all employees
                query = @"
                SELECT 
                   e.FirstName,
                   e.LastName,
                   r.RoleName,
                   e.Shift,
                   p.PunchInTime,
                   p.PunchOutTime
                FROM 
                   Employees e
                   INNER JOIN EmployeeRoles r ON e.RoleID = r.RoleID
                   INNER JOIN EmployeePunches p ON e.EmployeeID = p.EmployeeID";
            }
            else
            {
                // For other employees, filter by their EmployeeID
                query = @"
                SELECT 
                   e.FirstName,
                   e.LastName,
                   r.RoleName,
                   e.Shift,
                   p.PunchInTime,
                   p.PunchOutTime
                FROM 
                   Employees e
                   INNER JOIN EmployeeRoles r ON e.RoleID = r.RoleID
                   INNER JOIN EmployeePunches p ON e.EmployeeID = p.EmployeeID
                WHERE 
                   e.EmployeeID = @employeeID"; // Filter by the logged-in employee's ID
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!isCEO) // Add the parameter only if not CEO
                    {
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    }

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred while retrieving data: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Typically used for when a cell in the DataGridView is clicked
            // If you need specific functionality when clicking a cell, implement it here
        }
    }
}