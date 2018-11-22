using System;
using System.Configuration;
using System.Data.SqlClient;
namespace ADOtask
{
    class Third
    {
        public static void ThirdGroup(SqlConnection _sqlConnection)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSTART OF THIRD PART!\n");
            SqlCommand command;
            SqlDataReader reader;
            Console.WriteLine("24. Show the list of french customers’ names who used to order french products.");
            string command1 =
               "SELECT DISTINCT ContactName " +
               "FROM Customers, Orders " +
               "WHERE Customers.CustomerID = Orders.CustomerID AND Country = 'France' AND ShipCountry = 'France'";
            command = new SqlCommand(command1, _sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Third group of task");
           
           
            Console.WriteLine("25. Show the total ordering sum calculated for each country of customer.");
            string command2 =
                 "SELECT cust.Country, SUM(ordd.Quantity) AS TotalSum FROM Customers AS cust, Orders AS ord, [Order Details] AS ordd WHERE ord.CustomerID = cust.CustomerID AND ord.OrderID = ordd.OrderID GROUP BY cust.Country; ";
            command = new SqlCommand(command2, _sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-10}{1}", reader["Country"], reader["TotalSum"]);
            }
            reader.Close();
            Console.WriteLine("\nEND OF THIRD PART!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
