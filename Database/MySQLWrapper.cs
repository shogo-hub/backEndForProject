using System;
using MySql.Data.MySqlClient;


namespace Database
{
    public class MySQLWrapper : MySqlConnection
    {
        public MySQLWrapper(string hostname = "localhost", string username = null, string password = null, string database = null, uint? port = null)
        {
            //Get mysql connecting parameter
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = username ?? Helpers.Settings.env("DATABASE_USER"),
                Password = password ?? Helpers.Settings.env("DATABASE_USER_PASSWORD"),
                Database = database ?? Helpers.Settings.env("DATABASE_NAME"),
                Port = port ?? 3306  // Default MySQL port is 3306

            };

            // Set the connection string for the current MySQL connection
            this.ConnectionString = connectionStringBuilder.ToString();
            // Attempt to open the connection to the database
            this.Open();


        }
    }
}

