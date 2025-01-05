using PaperFlowWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Controller
{
    public class ProgressAction
    {
        // Add Progress Update to the Progress table
        public static bool AddProgress(Progress progress)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;

                        command.CommandText = @"
                        INSERT INTO Progress (GroupId, UpdateText, UpdatedBy, CreatedAt)
                        VALUES (@groupId, @updateText, @updatedBy, @createdAt);";

                        command.Parameters.AddWithValue("@groupId", progress.GroupId);
                        command.Parameters.AddWithValue("@updateText", progress.UpdateText);
                        command.Parameters.AddWithValue("@updatedBy", progress.UpdatedBy);
                        command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow.ToString("O"));

                        command.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        // Fetch Progress Updates for a specific Group
        public static List<Progress> GetGroupProgress(int groupId)
        {
            var progressUpdates = new List<Progress>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT * FROM Progress
                WHERE GroupId = @groupId;";

                command.Parameters.AddWithValue("@groupId", groupId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        progressUpdates.Add(new Progress
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            GroupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            UpdateText = reader.GetString(reader.GetOrdinal("UpdateText")),
                            UpdatedBy = reader.GetInt32(reader.GetOrdinal("UpdatedBy")),
                            CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt")))
                        });
                    }
                }
            }
            return progressUpdates;
        }

        // Delete a progress update by ID
        public static bool DeleteProgress(int progressId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                DELETE FROM Progress
                WHERE Id = @progressId;";

                command.Parameters.AddWithValue("@progressId", progressId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
