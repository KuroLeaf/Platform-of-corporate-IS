using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ADOtask
{
    class Second
    {
        public static void SecondGroup(SqlConnection _sqlConnection)
        {
            Console.WriteLine("Second group of task");

            string command1 =
                "SELECT CompanyName " +
                "FROM Customers LEFT JOIN Orders on Customers.CustomerID = Orders.CustomerID AND ShipCountry = 'France' " +
                "WHERE Country = 'France' AND ShipCountry IS NOT NULL GROUP BY CompanyName";

            string command2 =
                "SELECT ContactName " +
                "FROM Customers " +
                "WHERE CustomerID IN " +
                "(SELECT CustomerID FROM Orders WHERE OrderID IN " +
                "(SELECT OrderID FROM[Order Details] WHERE ProductID IN " +
                "(SELECT ProductID FROM Products WHERE ProductName = 'Tofu')))";

            SqlCommand command;
            SqlDataReader reader;

            // 22
            Console.WriteLine("22. Show the list of french customers’ names who used to order french products (use left join).");

            command = new SqlCommand(command1, _sqlConnection);
            reader = command.ExecuteReader();

            Console.WriteLine("Company Name");
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();

            //20
            Console.WriteLine("20. Show the list of customers’ names who used to order the ‘Tofu’ product.");

            command = new SqlCommand(command2, _sqlConnection);
            reader = command.ExecuteReader();

            Console.WriteLine("Result:");
            Console.WriteLine("  {0,10}", reader.GetName(0));
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("  {0,10}", reader.GetString(0));
                }
                reader.NextResult();
            }

            Console.WriteLine();
            reader.Close();
        }
    }
}
