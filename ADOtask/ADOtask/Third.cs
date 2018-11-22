using System;
using System.Configuration;
using System.Data.SqlClient;
namespace ADOtask
{
    class Third
    {
        public static void ThirdGroup(SqlConnection _sqlConnection)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Third group of task");
            SqlCommand command;
            SqlDataReader reader;
            //22
            Console.WriteLine("22. Show the list of french customers’ names who used to order french products (use left join).");
            string command1 =
                "SELECT ContactName " +
                "FROM Customers " +
                "LEFT JOIN Orders on Customers.CustomerID = Orders.CustomerID AND ShipCountry = 'France' " +
                "WHERE Country = 'France' AND ShipCountry IS NOT NULL GROUP BY ContactName";
            command = new SqlCommand(command1, _sqlConnection);
            reader = command.ExecuteReader();

            Console.WriteLine("Result:");
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();

            //23
            Console.WriteLine("23. Show the list of french customers’ names who used to order french products.");
            string command2 =
               "SELECT DISTINCT CompanyName " +
               "FROM Customers, Orders " +
               "WHERE Customers.CustomerID = Orders.CustomerID AND Country = 'France' AND ShipCountry = 'France'";
            command = new SqlCommand(command2, _sqlConnection);
            reader = command.ExecuteReader();
            Console.WriteLine("Company Name");
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
