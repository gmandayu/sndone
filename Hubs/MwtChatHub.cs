using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class ChatFileModel
{
    public string? FileUrl { get; set; }
    public string? FileType { get; set; }
    public string? OriginalFileName { get; set; }
}

public class MwtChatHub : Hub
{
    private readonly IConfiguration _configuration;

    public MwtChatHub(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task JoinMwtGroup(string noMwt)
    {
        if (!string.IsNullOrEmpty(noMwt))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, noMwt);
            //Console.WriteLine($"ID {Context.ConnectionId} joined MWT Group: {noMwt}");
        }
    }

    public async Task SendMwtMessage(string noMwt, string sender, string message, string? fileUrl, string? fileType, string? originalFileName, int idPlant)
    {
        try
        {
            DateTime plantDateTime = DateTime.Now;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                string sqlPlantTime = "EXEC dbo.GetPlantDateTime @IdPlant = @idPlant;";
                using (SqlCommand spCmd = new SqlCommand(sqlPlantTime, sqlConnection))
                {
                    spCmd.Parameters.Add("@idPlant", SqlDbType.Int).Value = idPlant;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        plantDateTime = (DateTime)spResult;
                    }
                }
            }

            int newId = SaveToDatabase(noMwt, sender, message, fileUrl, fileType, originalFileName, plantDateTime);

            string createdDate = plantDateTime.ToString("dd MMM yyyy, HH:mm");

            await Clients.Group(noMwt).SendAsync("ReceiveMwtMessage", sender, message, fileUrl, fileType, originalFileName, createdDate, newId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[MWT Chat Error]: {ex}");
            throw;
        }
    }
    
    public async Task SendMwtCompleted(string noMwt, string sender)
    {
        try
        {
            await Clients.Group(noMwt).SendAsync("ReceiveMwtCompleted", sender);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[MWT Completed Chat Error]: {ex}");
            throw;
        }
    }

    public async Task SendMwtBatchMessage(string noMwt, string sender, string message, List<ChatFileModel> files, int idPlant)
    {
        try
        {
            DateTime plantDateTime = DateTime.Now;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                string sqlPlantTime = "EXEC dbo.GetPlantDateTime @IdPlant = @idPlant;";
                using (SqlCommand spCmd = new SqlCommand(sqlPlantTime, sqlConnection))
                {
                    spCmd.Parameters.Add("@idPlant", SqlDbType.Int).Value = idPlant;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        plantDateTime = (DateTime)spResult;
                    }
                }
            }

            string createdDate = plantDateTime.ToString("dd MMM yyyy, HH:mm");

            if (files == null || files.Count == 0)
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    int textId = SaveToDatabase(noMwt, sender, message, null, null, null, plantDateTime);
                    await Clients.Group(noMwt).SendAsync("ReceiveMwtMessage", sender, message, null, null, null, createdDate, textId);
                }
            }
            else
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];

                    string? msgForThisBubble = (i == 0) ? message : null;

                    int fileId = SaveToDatabase(noMwt, sender, msgForThisBubble, file.FileUrl, file.FileType, file.OriginalFileName, plantDateTime);
                    
                    await Clients.Group(noMwt).SendAsync("ReceiveMwtMessage", sender, msgForThisBubble, file.FileUrl, file.FileType, file.OriginalFileName, createdDate, fileId);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[MWT Chat Batch Error]: {ex}");
            throw;
        }
    }

    private int SaveToDatabase(string noMwt, string sender, string? message, string? fileUrl, string? fileType, string? originalFileName, DateTime plantDateTime)
    {
        try
        {
            var dbName = _configuration["Databases:DB:dbname"] ?? "";
            var user = _configuration["Databases:DB:username"] ?? "";
            var pass = _configuration["Databases:DB:password"] ?? "";
            var baseConn = _configuration["Databases:DB:connectionstring"];
            if (string.IsNullOrEmpty(baseConn))
            {
                throw new Exception("Database connection string not found in configuration.");
            }
            int newId = 0;

            string connectionString = baseConn
                .Replace("{dbname}", dbName)
                .Replace("{uid}", user)
                .Replace("{pwd}", pass);

            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO MWTOnlineDetail 
                    (NoReferensi, Penjelasan, UploadEvidence, FileType, OriginalFileName, CreatedBy, CreatedDate) 
                    VALUES 
                    (@NoRef, @Msg, @FileUrl, @FileType, @OrigName, @Sender, @plantDateTime);

                    UPDATE MWTOnline 
                    SET LastUpdatedBy = @Sender, 
                        LastUpdatedDate = @plantDateTime
                    WHERE NoMWTOnline = @NoRef;

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NoRef", noMwt);
                    cmd.Parameters.AddWithValue("@Msg", (object?)message ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileUrl", (object?)fileUrl ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileType", (object?)fileType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrigName", (object?)originalFileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sender", sender);
                    cmd.Parameters.AddWithValue("@plantDateTime", plantDateTime);

                    conn.Open();
                    // newId = (int)cmd.ExecuteScalar();
                    object? result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        newId = id;
                    }
                }
            }

            return newId;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[MWT Save to DB Error]: {ex}");
            throw;
        }
    }
}
