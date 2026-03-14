public class LogErrorException : Exception
{
    public int StatusCode { get; }
    public string? NoReferensi { get; }
    public int? IdProses { get; }
    public int? IdAktivitas { get; }
    public string? Username { get; }

    public LogErrorException(string message) : base(message)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }

    public LogErrorException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public LogErrorException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }

    public LogErrorException(string message, int statusCode, Exception innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
    
    public LogErrorException(string message, int statusCode, string? innerMessage) : base(message, innerMessage != null ? new Exception(innerMessage) : null)
    {
        StatusCode = statusCode;
    }

    public LogErrorException(string message, int statusCode, string? noReferensi = null, int? idProses = null,
        int? idAktivitas = null, string? username = null) : base(message)
    {
        StatusCode = statusCode;
        NoReferensi = noReferensi;
        IdProses = idProses;
        IdAktivitas = idAktivitas;
        Username = username;
    }
    
    public LogErrorException(string message, string? noReferensi = null, int? idProses = null,
        int? idAktivitas = null, string? username = null) : base(message)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
        NoReferensi = noReferensi;
        IdProses = idProses;
        IdAktivitas = idAktivitas;
        Username = username;
    }
}
