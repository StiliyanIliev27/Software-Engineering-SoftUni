using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace _01.Initial_Setup
{
    internal class Program
    {
        private const string ConnectionString = "Server = DESKTOP-ME8RHIA;Integrated Security=true; TrustServerCertificate = True; MultipleActiveResultSets=true;";
        static void Main(string[] args)
        {           
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
               
                CreateDB(sqlConnection);
                CreateDBTables(sqlConnection);
                InsertIntoDBTables(sqlConnection);
            }
            finally
            {
                sqlConnection?.Dispose();
            }         
        }

        static void CreateDB(SqlConnection sqlConnection)
        {
            using SqlCommand cmd = new SqlCommand(SQLQueries.CreateDB, sqlConnection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Succesfully created MinionsDB!");
        }

        static void CreateDBTables(SqlConnection sqlConnection)
        {
            using SqlCommand cmd = new SqlCommand(SQLQueries.CreateDBTables, sqlConnection);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Created DB tables!");
        }

        static void InsertIntoDBTables(SqlConnection sqlConnection)
        {
            using SqlCommand cmd = new SqlCommand(SQLQueries.InsertIntoDBTables, sqlConnection);
            Console.WriteLine($"Insertion into tables was succesfully! Rows affected: {cmd.ExecuteNonQuery()}");
        }
    }
}