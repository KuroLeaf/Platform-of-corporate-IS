using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ADOtask
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                //string provider = ConfigurationManager.ConnectionStrings["ADO.Properties.Settings.NorthwindConnectionString"].ProviderName;
                string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

                SqlConnection _sqlConnection = new SqlConnection(connectionString);
                
                    _sqlConnection.Open();

                    First.FirstGroup(_sqlConnection);
                    Second.SecondGroup(_sqlConnection);
                    Third.ThirdGroup(_sqlConnection);
                    Fourth.FourthGroup(_sqlConnection);
                
            }
            catch (SqlException _sqlException)
            {
                Console.WriteLine("Sql error: " + _sqlException.Message);
            }
            catch (Exception _exception)
            {
                Console.WriteLine("Error: " + _exception.Message);
            }
            finally
            {
                Console.ReadLine();
            }
            Console.ReadLine();
        }
        
    }
}
