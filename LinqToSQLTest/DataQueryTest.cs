using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToSQLTest
{
    [TestClass]
    public class DataQueryTest
    {
        [TestMethod]
        public void ShouldUseSqlConnectionToQueryData()
        {
            using (var sqlConnection =
                new SqlConnection(@"Server=(local)\sqlexpress;Integrated Security=True;Database=Northwind"))
            {
                sqlConnection.Open();

                using (var command = new SqlCommand("SELECT TOP 2 * FROM Customers", sqlConnection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                                          reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }
        }
    }
}

