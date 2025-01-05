using PaperFlowWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaperFlowWpf.Controller
{
    public class UserService
    {
        // Simple password hashing (for demo - use better hashing in production)
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool SignUp(string name, string email, string password)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                    INSERT INTO Users (Name, Email, Password, CreatedAt)
                    VALUES (@name, @email, @password, @createdAt);";

                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", HashPassword(password));
                    command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow.ToString("O"));

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static User Login(string email, string password)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT Id, Name, Email, CreatedAt 
                FROM Users 
                WHERE Email = @email AND Password = @password;";

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", HashPassword(password));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            CreatedAt = DateTime.Parse(reader.GetString(3))
                        };
                    }
                }
            }
            return null;
        }
    }
}
