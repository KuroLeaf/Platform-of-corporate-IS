using System;
using System.Configuration;
using System.Data.SqlClient;
namespace ADOtask
{
    class Fourth
    {
        public static void FourthGroup(SqlConnection _sqlConnection)
        {
            
                Console.WriteLine("Fouth group of task");

                string command1 =
                    "UPDATE Employees " +
                    "SET City = 'Lviv' " +
                    "Where EmployeeID = 8";

                string command2 =
                    "DELETE " +
                    "FROM Region " +
                    "WHERE RegionID = 8";
                SqlCommand command;

                //33
                Console.WriteLine("33. Change the City field in one of your records using the UPDATE statement.");

                command = new SqlCommand(command1, _sqlConnection);

                Console.WriteLine("Result:");
                Console.WriteLine("  Affected {0} rows.\n", command.ExecuteNonQuery());

                //35
                Console.WriteLine("35. Delete one of your records.");

                command = new SqlCommand(command2, _sqlConnection);

                Console.WriteLine("Result:");
                Console.WriteLine("  Affected {0} rows.\n", command.ExecuteNonQuery());
            }
        
    }
}
