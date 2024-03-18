using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Text;
using System.Transactions;
using System.Configuration;

namespace ClassLibraryNS20
{
    /// <summary>
    /// How to use transactions with dapper.net?
    /// https://stackoverflow.com/questions/10363933/how-to-use-transactions-with-dapper-net/
    /// </summary>
    public class DBHelper : IDBHelper
    {
        /// <summary>
        /// Using Simple Transaction
        /// </summary>
        /// <returns></returns>
        public (bool, string) InsertCustomer1()
        {
            bool success = true;
            string errorMsg = string.Empty;
            try
            {
                string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

                using (IDbConnection connection = CreateConnection1())
                {
                    connection.Open();

                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        connection.Execute(sql, new { CustomerName = "Mark" }, transaction: transaction);
                        connection.Execute(sql, new { CustomerName = "Sam" }, transaction: transaction);
                        connection.Execute(sql, new { CustomerName = "John" }, transaction: transaction);

                        //COMMIT TRANSACTION
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                errorMsg = ex.ToString();
                //throw;
            }
            return (success, errorMsg);
        }

        /// <summary>
        /// Using Transaction Scope
        /// </summary>
        /// <returns></returns>
        public (bool, string) InsertCustomer2()
        {
            bool success = true;
            string errorMsg = string.Empty;
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

                    using (IDbConnection connection = CreateConnection2())
                    {
                        connection.Open();

                        connection.Execute(sql, new { CustomerName = "Mark" });
                        connection.Execute(sql, new { CustomerName = "Sam" });
                        connection.Execute(sql, new { CustomerName = "John" });
                    }

                    //COMMIT TRANSACTION
                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                success = false;
                errorMsg = ex.ToString();
                //throw;
            }
            return (success, errorMsg);
        }

        public (bool, string) InsertCustomer3()
        {
            bool success = true;
            string errorMsg = string.Empty;
            try
            {
                string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

                using (IDbConnection connection = CreateConnection3())
                {
                    connection.Open();

                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        connection.Execute(sql, new { CustomerName = "Mark" }, transaction);
                        connection.Execute(sql, new { CustomerName = "Sam" }, transaction);
                        connection.Execute(sql, new { CustomerName = "John" }, transaction);

                        //COMMIT TRANSACTION
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                errorMsg = ex.ToString();
                //throw;
            }
            return (success, errorMsg);
        }

        private static string GetConnectionString1()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private static string GetConnectionString2()
        {
            return ConfigurationManager.AppSettings["DefaultConnection"];
        }

        private static string GetConnectionString3()
        {
            return "Data Source=localhost;Initial Catalog=mssql;Integrated Security=True;";
        }

        private IDbConnection CreateConnection1()
        {
            return new SqlConnection(GetConnectionString1());
        }

        private IDbConnection CreateConnection2()
        {
            return new SqlConnection(GetConnectionString2());
        }

        private IDbConnection CreateConnection3()
        {
            return new SqlConnection(GetConnectionString3());
        }
    }
}
