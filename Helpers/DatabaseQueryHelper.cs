public class DatabaseQueryHelper
{
    public static List<T> ExecuteSelectListQuery<T>(
        string query,
        Func<SqlDataReader, T> mapFunc,
        Dictionary<string, object>? parameters = null,
        string? noReferensi = null,
        int? idProses = null,
        int? idAktivitas = null)
    {
        var result = new List<T>();
        var userName = CurrentUserName();
        if (string.IsNullOrEmpty(userName))
        {
            userName = "Anonymous";
        }
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 300;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        result.Add(mapFunc(reader));
            }
        }
        catch (Exception ex)
        {
            throw new LogErrorException(ex.Message, username: userName, noReferensi: noReferensi, idProses: idProses, idAktivitas: idAktivitas);
        }
                
        return result;
    }
    
    public static T? ExecuteSelectSingle<T>(
        string query,
        Func<SqlDataReader, T> mapFunc,
        Dictionary<string, object>? parameters = null,
        string? noReferensi = null,
        int? idProses = null,
        int? idAktivitas = null)
    {
        var userName = CurrentUserName() ?? "Anonymous";
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 300;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return mapFunc(reader);
                    else
                        return default;
                }
            }
        }
        catch (Exception ex)
        {
            throw new LogErrorException(
                ex.Message,
                username: userName,
                noReferensi: noReferensi,
                idProses: idProses,
                idAktivitas: idAktivitas);
        } 
    }
            
            // Asynchronous SELECT single record
    public static async Task<T>? ExecuteSelectSingleAsync<T>(
        string query,
        Func<SqlDataReader, T> mapFunc,
        Dictionary<string, object>? parameters = null,
        string? noReferensi = null,
        int? idProses = null,
        int? idAktivitas = null)
    {
        var userName = CurrentUserName() ?? "Anonymous";
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 300;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
    
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                        return mapFunc(reader);
                    else
                        return default;
                }
            }
        }
        catch (Exception ex)
        {
            throw new LogErrorException(
                ex.Message,
                username: userName,
                noReferensi: noReferensi,
                idProses: idProses,
                idAktivitas: idAktivitas);
        }
    }
            
    // Async SELECT - fixed signature, disposal, await logic
    public static async Task<List<T>> ExecuteSelectListQueryAsync<T>(
        string query,
        Func<SqlDataReader, T> mapFunc,
        Dictionary<string, object>? parameters = null,
        string? noReferensi = null,
        int? idProses = null,
        int? idAktivitas = null)
    {
        var result = new List<T>();
        var userName = CurrentUserName();
        if (string.IsNullOrEmpty(userName))
        {
            userName = "Anonymous";
        }
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 300;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
        
                using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                        result.Add(mapFunc(reader));
            }
        }
        catch (Exception ex)
        {
            throw new LogErrorException(ex.Message, username: userName, noReferensi: noReferensi, idProses: idProses,
                idAktivitas: idAktivitas);
        }
        return result;
    }
        
    // Synchronous NON-SELECT: removed mapFunc, return type List<T>
    public static void ExecuteNonSelectQuery(
        string query,
        Dictionary<string, object>? parameters = null,
        string? noReferensi = null,
        int? idProses = null,
        int? idAktivitas = null)
    {
        var userName = CurrentUserName();
        if (string.IsNullOrEmpty(userName)) userName = "Anonymous";
                
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 300;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
        
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new LogErrorException(ex.Message, username: userName, noReferensi: noReferensi, idProses: idProses, idAktivitas: idAktivitas);
        }
    }
        
    // Async NON-SELECT: removed mapFunc, fixed signature and logic
    public static async Task ExecuteNonSelectQueryAsync(
        string query,
        Dictionary<string, object>? parameters = null,
        string? noReferensi = null,
        int? idProses = null,
        int? idAktivitas = null)
    {
        var userName = CurrentUserName();
        if (string.IsNullOrEmpty(userName))
        {
            userName = "Anonymous";
        }
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 300;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
        
                await cmd.ExecuteNonQueryAsync();
            }
        }
        catch (Exception ex)
        {
            throw new LogErrorException(ex.Message, username: userName, noReferensi: noReferensi, idProses: idProses, idAktivitas: idAktivitas);
        }
    }
}
