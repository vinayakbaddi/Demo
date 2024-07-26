using StandAloneDB;
using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        TestmethodYield.Process();
        //testc();
    }

    //private static void testc()
    //{
    //    string databaseFilePath = @"full_path_to_your_mdf_file";
    //    string serverName = "(LocalDB)\\MSSQLLocalDB"; // LocalDB instance name
    //    string databaseName = "YourDatabaseName"; // Set your database name
    //    string connectionString = $@"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

    //    // Attach the .mdf file
    //    AttachDatabase(databaseFilePath, serverName, databaseName);

    //    // Execute a simple SQL query after attaching
    //    ExecuteQuery(connectionString);
    //}

    //static void AttachDatabase(string databaseFilePath, string serverName, string databaseName)
    //{
    //    try
    //    {
    //        Server server = new Server(new ServerConnection(new ServerInstance(serverName)));
    //        Database database = new Database(server, databaseName);
    //        database.Attach(new AttachOptions(), databaseFilePath);

    //        Console.WriteLine("Database attached successfully!");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Error attaching database: " + ex.Message);
    //    }
    //}

    //static void ExecuteQuery(string connectionString)
    //{
    //    try
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            Console.WriteLine("Connection successful!");

    //            string query = "SELECT * FROM YourTableName"; // Replace with your table name
    //            SqlCommand command = new SqlCommand(query, connection);

    //            SqlDataReader reader = command.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                Console.WriteLine($"Column1: {reader["Column1"]}, Column2: {reader["Column2"]}"); // Replace with your column names
    //            }
    //            reader.Close();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Error executing query: " + ex.Message);
    //    }
    //}
}