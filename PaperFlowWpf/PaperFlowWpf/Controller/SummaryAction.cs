using PaperFlowWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Controller
{
    public class SummaryAction
    {
        // Add Summary to the Summaries table
        public static bool AddSummary(Summary summary)
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
                        INSERT INTO Summaries (GroupId, Content, GeneratedBy, GeneratedAt)
                        VALUES (@groupId, @content, @generatedBy, @generatedAt);";

                        command.Parameters.AddWithValue("@groupId", summary.GroupId);
                        command.Parameters.AddWithValue("@content", summary.Content);
                        command.Parameters.AddWithValue("@generatedBy", summary.GeneratedBy);
                        command.Parameters.AddWithValue("@generatedAt", DateTime.UtcNow.ToString("O"));

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

        // Fetch Summaries for a specific Group
        public static List<Summary> GetGroupSummaries(int groupId)
        {
            var summaries = new List<Summary>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT * FROM Summaries
                WHERE GroupId = @groupId;";

                command.Parameters.AddWithValue("@groupId", groupId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        summaries.Add(new Summary
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            GroupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            GeneratedBy = reader.GetInt32(reader.GetOrdinal("GeneratedBy")),
                            GeneratedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("GeneratedAt")))
                        });
                    }
                }
            }
            return summaries;
        }

        // Delete a summary by ID
        public static bool DeleteSummary(int summaryId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                DELETE FROM Summaries
                WHERE Id = @summaryId;";

                command.Parameters.AddWithValue("@summaryId", summaryId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
