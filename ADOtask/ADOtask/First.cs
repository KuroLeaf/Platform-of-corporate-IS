using System;
using System.Configuration;
using System.Data.SqlClient;
namespace ADOtask
{
    class First
    {
            public static void FirstGroup(SqlConnection _sqlConnection)
            {
                Console.WriteLine("First group of task");
                string command1 =
                    "SELECT * " +
                    "FROM Employees " +
                    "WHERE EmployeeID = 8';";
                string command2 =
                    "SELECT TOP 3 FirstName,  LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age " +
                    "FROM Employees " +
                    "ORDER BY Age DESC; ";

                SqlCommand command;
                SqlDataReader reader;

                //1
                Console.WriteLine("1. Show all info about the employee with ID 8.");

                command = new SqlCommand(command1, _sqlConnection);
                reader = command.ExecuteReader();

                Console.WriteLine("Result:");
                reader.Read();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                reader.Close();

                //10
                Console.WriteLine("10. Show first, last names and ages of 3 eldest employees.");

                command = new SqlCommand(command2, _sqlConnection);
                reader = command.ExecuteReader();

                Console.WriteLine("Result:");
                Console.WriteLine("  {0,10}\t{1,10}\t{2,5}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("  {0,10}\t{1,10}\t{2,5}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                    }
                    reader.NextResult();
                }
                Console.WriteLine();

                reader.Close();
        }
    }
}
