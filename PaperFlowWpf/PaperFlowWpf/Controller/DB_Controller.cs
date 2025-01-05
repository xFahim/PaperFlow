using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PaperFlowWpf.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Controller
{
    public class DatabaseHelper
    {
        private const string DatabaseFile = "paperflow.db";
        private static string ConnectionString => $"Data Source={DatabaseFile}";

        public static void InitializeDatabase()
        {
            if (!File.Exists(DatabaseFile))
            {
                CreateDatabase();
            }
        }

        private static void CreateDatabase()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                CREATE TABLE Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT UNIQUE NOT NULL,
                    Password TEXT NOT NULL,
                    CreatedAt TEXT NOT NULL
                );";
                command.ExecuteNonQuery();
            }
        }

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
    }

}
