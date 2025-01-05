using PaperFlowWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Controller
{
    public class MaterialAction
    {
        // Add Material to the Materials table
        public static bool AddMaterial(Material material)
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
                        INSERT INTO Materials (Title, Description, FilePath, UploadedBy, GroupId, UploadedAt)
                        VALUES (@title, @description, @filePath, @uploadedBy, @groupId, @uploadedAt);";

                        command.Parameters.AddWithValue("@title", material.Title);
                        command.Parameters.AddWithValue("@description", material.Description);
                        command.Parameters.AddWithValue("@filePath", material.FilePath);
                        command.Parameters.AddWithValue("@uploadedBy", material.UploadedBy);
                        command.Parameters.AddWithValue("@groupId", material.GroupId);
                        command.Parameters.AddWithValue("@uploadedAt", DateTime.UtcNow.ToString("O"));

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

        // Fetch Materials for a specific Group
        public static List<Material> GetGroupMaterials(int groupId)
        {
            var materials = new List<Material>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT * FROM Materials
                WHERE GroupId = @groupId;";

                command.Parameters.AddWithValue("@groupId", groupId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        materials.Add(new Material
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            FilePath = reader.GetString(reader.GetOrdinal("FilePath")),
                            UploadedBy = reader.GetInt32(reader.GetOrdinal("UploadedBy")),
                            GroupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            UploadedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("UploadedAt")))
                        });
                    }
                }
            }
            return materials;
        }

        // Delete a material by ID
        public static bool DeleteMaterial(int materialId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                DELETE FROM Materials
                WHERE Id = @materialId;";

                command.Parameters.AddWithValue("@materialId", materialId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
