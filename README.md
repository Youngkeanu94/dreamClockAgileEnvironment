This C# application was developed in an Agile environment by the "The Dream Team" over 8 weeks. You can find the product backlog, DFD, and all other designs/documentation in the files!
The provided C# code constitutes a comprehensive Windows Forms application for a time-tracking system. It is designed to manage employee working hours, with specific functionalities tailored to different user roles, including a CEO. Here’s a detailed breakdown:

MainForm Class
Functionality: Manages the primary user interface for tracking employee work hours.
Features:
Authentication: Accepts employeeID and a flag isCEO to identify the user's role.
Data Loading: Fetches and displays employee hours from an SQL database, with different data views for CEOs and regular employees.
Clock-in/Clock-out: Provides functionality for employees to clock in and out, recording these events in the database.
Role-based Data Access: CEOs can view all employees' hours, while other employees can only see their hours.

LoginForm Class
Functionality: Handles the login process.
Features:
Credential Verification: Checks for valid username and password input.
Database Connection: Connects to an SQL database to validate credentials.
Role Identification: Determines if the logged-in user is a CEO, and stores key user information like EmployeeID and UserRoleID.
Input Validation: Ensures username and password do not contain special characters (though the actual validation is commented out).
Key Aspects
Database Integration: Utilizes SQL Server (SqlConnection, SqlCommand, etc.) for data storage and retrieval.
Security: Includes basic security measures for login.
Error Handling: Implements try-catch blocks to handle SQL exceptions.

Possible Enhancements
Input Validation: Enhance validation in LoginForm to prevent SQL injection.
Password Security: Store and verify hashed passwords rather than plain text.
