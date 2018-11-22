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
            Console.WriteLine("25. Show the list of french customers’ names who used to order french products (use left join).");
            string command1 =
                 "SELECT cust.Country, SUM(ordd.Quantity) AS TotalSum FROM Customers AS cust, Orders AS ord, [Order Details] AS ordd WHERE ord.CustomerID = cust.CustomerID AND ord.OrderID = ordd.OrderID GROUP BY cust.Country; ";
            command = new SqlCommand(command1, _sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-10}{1}", reader["Country"], reader["TotalSum"]);
            }
            reader.Close();
          
           

            Console.ForegroundColor = ConsoleColor.Green;
            //23
            Console.WriteLine("23. Show the list of french customers’ names who used to order french products.");
            string command2 =
               "SELECT DISTINCT ContactName " +
               "FROM Customers, Orders " +
               "WHERE Customers.CustomerID = Orders.CustomerID AND Country = 'France' AND ShipCountry = 'France'";
            command = new SqlCommand(command2, _sqlConnection);
            reader = command.ExecuteReader();
           // Console.WriteLine("Company Name");
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
