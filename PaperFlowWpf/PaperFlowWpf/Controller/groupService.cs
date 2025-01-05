using PaperFlowWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFlowWpf.Controller
{
    public class GroupService
    {
        public static void InitializeGroupTables()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Groups (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT,
                    Category TEXT,
                    AdminId INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL,
                    Privacy INTEGER NOT NULL,
                    FOREIGN KEY(AdminId) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS GroupMemberships (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    GroupId INTEGER NOT NULL,
                    JoinedAt TEXT NOT NULL,
                    FOREIGN KEY(GroupId) REFERENCES Groups(Id),
                    FOREIGN KEY(UserId) REFERENCES Users(Id),
                    UNIQUE(UserId, GroupId)
                );

                CREATE TABLE IF NOT EXISTS Materials (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT,
                    FilePath TEXT NOT NULL,
                    UploadedBy INTEGER NOT NULL,
                    GroupId INTEGER NOT NULL,
                    UploadedAt TEXT NOT NULL,
                    FOREIGN KEY(GroupId) REFERENCES Groups(Id),
                    FOREIGN KEY(UploadedBy) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS Progress (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    GroupId INTEGER NOT NULL,
                    UpdateText TEXT NOT NULL,
                    UpdatedBy INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL,
                    FOREIGN KEY(GroupId) REFERENCES Groups(Id),
                    FOREIGN KEY(UpdatedBy) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS Summaries (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    GroupId INTEGER NOT NULL,
                    Content TEXT NOT NULL,
                    GeneratedBy INTEGER NOT NULL,
                    GeneratedAt TEXT NOT NULL,
                    FOREIGN KEY(GroupId) REFERENCES Groups(Id),
                    FOREIGN KEY(GeneratedBy) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS JoinRequests (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    GroupId INTEGER NOT NULL,
                    UserId INTEGER NOT NULL,
                    RequestedAt TEXT NOT NULL,
                    FOREIGN KEY(GroupId) REFERENCES Groups(Id),
                    FOREIGN KEY(UserId) REFERENCES Users(Id),
                    UNIQUE(UserId, GroupId)
                );";

                command.ExecuteNonQuery();
            }
        }

        public static int CreateGroup(ResearchGroup group)
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

                        // Insert group
                        command.CommandText = @"
                        INSERT INTO Groups (Title, Description, Category, AdminId, CreatedAt, Privacy)
                        VALUES (@title, @description, @category, @adminId, @createdAt, @privacy);
                        SELECT last_insert_rowid();";

                        command.Parameters.AddWithValue("@title", group.Title);
                        command.Parameters.AddWithValue("@description", group.Description);
                        command.Parameters.AddWithValue("@category", group.Category);
                        command.Parameters.AddWithValue("@adminId", group.AdminId);
                        command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow.ToString("O"));
                        command.Parameters.AddWithValue("@privacy", (int)group.Privacy);

                        int groupId = Convert.ToInt32(command.ExecuteScalar());

                        // Add admin as first member
                        command.CommandText = @"
                        INSERT INTO GroupMemberships (UserId, GroupId, JoinedAt)
                        VALUES (@userId, @groupId, @joinedAt);";

                        command.Parameters.AddWithValue("@groupId", groupId);
                        command.Parameters.AddWithValue("@userId", group.AdminId);
                        command.Parameters.AddWithValue("@joinedAt", DateTime.UtcNow.ToString("O"));

                        command.ExecuteNonQuery();
                        transaction.Commit();
                        return groupId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static ResearchGroup GetGroupById(int groupId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT g.*, u.Name as CreatorName, u.Email as CreatorEmail
                FROM Groups g
                JOIN Users u ON g.AdminId = u.Id
                WHERE g.Id = @groupId;";
                command.Parameters.AddWithValue("@groupId", groupId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var group = new ResearchGroup
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = reader.GetString(reader.GetOrdinal("Category")),
                            AdminId = reader.GetInt32(reader.GetOrdinal("AdminId")),
                            CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                            Privacy = (Privacy)reader.GetInt32(reader.GetOrdinal("Privacy")),
                            Creator = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("AdminId")),
                                Name = reader.GetString(reader.GetOrdinal("CreatorName")),
                                Email = reader.GetString(reader.GetOrdinal("CreatorEmail"))
                            }
                        };

                        // Load members
                        group.Members = GetGroupMembers(groupId);
                        // Load materials
                        group.Materials = MaterialAction.GetGroupMaterials(groupId);
                        // Load progress updates
                        group.ProgressUpdates = ProgressAction.GetGroupProgress(groupId);
                        // Load summaries
                        group.Summaries = SummaryAction.GetGroupSummaries(groupId);
                        // Load join requests
                        group.JoinRequests = GetGroupJoinRequests(groupId);

                        return group;
                    }
                }
            }
            return null;
        }

        private static List<GroupMembership> GetGroupMembers(int groupId)
        {
            var members = new List<GroupMembership>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT m.*, u.Name, u.Email
                FROM GroupMemberships m
                JOIN Users u ON m.UserId = u.Id
                WHERE m.GroupId = @groupId;";
                command.Parameters.AddWithValue("@groupId", groupId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new GroupMembership
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            GroupId = groupId,
                            JoinedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("JoinedAt"))),
                            User = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            }
                        });
                    }
                }
            }
            return members;
        }

        // Similar methods for GetGroupMaterials, GetGroupProgress, GetGroupSummaries...
        // Implementation would follow the same pattern as GetGroupMembers

        private static List<JoinRequest> GetGroupJoinRequests(int groupId)
        {
            var requests = new List<JoinRequest>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT r.*, u.Name, u.Email
                FROM JoinRequests r
                JOIN Users u ON r.UserId = u.Id
                WHERE r.GroupId = @groupId;";
                command.Parameters.AddWithValue("@groupId", groupId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new JoinRequest
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            GroupId = groupId,
                            RequestedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("RequestedAt"))),
                            User = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            }
                        });
                    }
                }
            }
            return requests;
        }


        public static List<ResearchGroup> GetPublicGroups()
        {
            var groups = new List<ResearchGroup>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();

                // Get all public groups with creator information
                command.CommandText = @"
                SELECT g.*, u.Name as CreatorName, u.Email as CreatorEmail
                FROM Groups g
                JOIN Users u ON g.AdminId = u.Id
                WHERE g.Privacy = @privacy
                ORDER BY g.CreatedAt DESC;";

                command.Parameters.AddWithValue("@privacy", (int)Privacy.Public);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var group = new ResearchGroup
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = reader.GetString(reader.GetOrdinal("Category")),
                            AdminId = reader.GetInt32(reader.GetOrdinal("AdminId")),
                            CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                            Privacy = (Privacy)reader.GetInt32(reader.GetOrdinal("Privacy")),
                            Creator = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("AdminId")),
                                Name = reader.GetString(reader.GetOrdinal("CreatorName")),
                                Email = reader.GetString(reader.GetOrdinal("CreatorEmail"))
                            }
                        };

                        // Load related data for each group
                        group.Members = GetGroupMembers(group.Id);
                        group.JoinRequests = GetGroupJoinRequests(group.Id);
                        groups.Add(group);
                    }
                }
            }
            return groups;
        }

        public static bool RequestToJoinGroup(int groupId, int userId)
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

                        // First check if user is already a member
                        command.CommandText = @"
                        SELECT COUNT(*) FROM GroupMemberships 
                        WHERE GroupId = @groupId AND UserId = @userId;";

                        command.Parameters.AddWithValue("@groupId", groupId);
                        command.Parameters.AddWithValue("@userId", userId);

                        int memberCount = Convert.ToInt32(command.ExecuteScalar());
                        if (memberCount > 0)
                        {
                            return false; // User is already a member
                        }

                        // Then check if user already has a pending request
                        command.CommandText = @"
                        SELECT COUNT(*) FROM JoinRequests 
                        WHERE GroupId = @groupId AND UserId = @userId;";

                        int requestCount = Convert.ToInt32(command.ExecuteScalar());
                        if (requestCount > 0)
                        {
                            return false; // Request already exists
                        }

                        // Create new join request
                        command.CommandText = @"
                        INSERT INTO JoinRequests (GroupId, UserId, RequestedAt)
                        VALUES (@groupId, @userId, @requestedAt);";

                        command.Parameters.AddWithValue("@requestedAt", DateTime.UtcNow.ToString("O"));
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

        public static bool ApproveJoinRequest(int groupId, int userId, int approvedByUserId)
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

                        // First verify that approvedByUserId is the admin of the group
                        command.CommandText = @"
                        SELECT AdminId FROM Groups WHERE Id = @groupId;";
                        command.Parameters.AddWithValue("@groupId", groupId);

                        int adminId = Convert.ToInt32(command.ExecuteScalar());
                        if (adminId != approvedByUserId)
                        {
                            return false; // Only admin can approve requests
                        }

                        // Check if request exists
                        command.CommandText = @"
                        SELECT COUNT(*) FROM JoinRequests 
                        WHERE GroupId = @groupId AND UserId = @userId;";

                        command.Parameters.AddWithValue("@userId", userId);

                        int requestCount = Convert.ToInt32(command.ExecuteScalar());
                        if (requestCount == 0)
                        {
                            return false; // No request found
                        }

                        // Add to members
                        command.CommandText = @"
                        INSERT INTO GroupMemberships (GroupId, UserId, JoinedAt)
                        VALUES (@groupId, @userId, @joinedAt);";

                        command.Parameters.AddWithValue("@joinedAt", DateTime.UtcNow.ToString("O"));
                        command.ExecuteNonQuery();

                        // Remove from requests
                        command.CommandText = @"
                        DELETE FROM JoinRequests 
                        WHERE GroupId = @groupId AND UserId = @userId;";

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

        // Helper method to check if a user is a member of a group
        public static bool IsUserMember(int groupId, int userId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT COUNT(*) FROM GroupMemberships 
                WHERE GroupId = @groupId AND UserId = @userId;";

                command.Parameters.AddWithValue("@groupId", groupId);
                command.Parameters.AddWithValue("@userId", userId);

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }


    }
}
