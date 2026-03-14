//SQLInjectionDetector.cs

using DocumentFormat.OpenXml.ExtendedProperties;
using MimeDetective.Storage.Xml.v2;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class SQLInjectionDetector
{
    // Daftar pola sederhana untuk SQL Injection
    public static readonly string[] SqlInjectionPatterns = new[]
    {
        //"'", //"\"", //";",
        //"--", //"/",
        //"select", "drop", "insert", "delete", "union", "alter", "create", "update", "truncate",
        //"or", "and", "like", "where",  "in",
        //" and ", " or ", " not ", " xor ", " like ", " between ",
        //"--", "/*", "*/",
        "select ", "from ", "where ", "insert ", "update ", "delete ", "drop ", "alter ", "create ", "truncate ", "union ",
        "union all", "limit ", "order by ", "group by ", "having ", "offset ", "waitfor", "delay",
        //"top ",
        //"case ", "when ", "end ", "begin ",
        "char(", "concat(", "substring(", "ascii(", "len(", "length(",
        "database()", "user()", "session_user()", "system_user()", "current_user()", "schema_name()",
        "count(", "sum(", "avg(", "floor(", "rand(", "case ", "if(", "nullif(", "coalesce(", "cast(", "convert(",
        //"exists ", "not exists", 
        //"any ", "all ",
        "information_schema.tables ", "information_schema.columns ", "information_schema.schemata ", "information_schema.routines ",
        "sysobjects", "syscolumns", "sysdatabases",
        "insert into", " values ",
        //"set", "exec", "execute", "openrowset",
        "opendatasource",
        "1=0", "'1'='1'", "'1'='2'",
        //"waitfor delay '0:0:5'",
        "benchmark(1000000,encode('data','data'))", "sleep(5)",
        "exec xp_cmdshell", "load_file()", "outfile", "into outfile", "bulk insert", "shutdown", "xp_regread",
        "dbms_pipe.receive_message", "utl_http.request",
        // "=", "<", ">", "<=", ">=", "<>", "+", "||", "%", ";",  "#",
        "0x...", "unhex(", "convert(", "cast("

    };

    public static readonly string[] UrlWordCheckList = new[]
    {
        "/LookUpList/"
    };

    public static readonly string[] TagInjectionPatterns = new[]
    {
        "<a", "<abbr", "<address", "<area", "<article", "<aside", "<audio", "<b", "<base", "<bdi", "<bdo",
        "<blockquote", "<body", "<br", "<button", "<canvas", "<caption", "<cite", "<code", "<col", "<colgroup",
        "<data", "<datalist", "<dd", "<del", "<details", "<dfn", "<dialog", "<div", "<dl", "<dt", "<em", "<embed",
        "<fieldset", "<figcaption", "<figure", "<footer", "<form", "<h1", "<h2", "<h3", "<h4", "<h5", "<h6", "<head",
        "<header", "<hr", "<html", "<i", "<iframe", "<img", "<input", "<ins", "<kbd", "<label", "<legend", "<li",
        "<link", "<main", "<map", "<mark", "<meta", "<meter", "<nav", "<noscript", "<object", "<ol", "<optgroup",
        "<option", "<output", "<p", "<picture", "<pre", "<progress", "<q", "<rp", "<rt", "<ruby", "<samp",
        "<script", "<section", "<select", "<small", "<source", "<span", "<strong", "<style", "<sub", "<summary",
        "<sup", "<table", "<tbody", "<td", "<template", "<textarea", "<tfoot", "<th", "<thead", "<time", "<title",
        "<tr", "<track", "<u", "<ul", "<var", "<video", "<wbr",
        "<script", "<style", "<svg", "alert("
      // "<s",

    };

    private static string pattern;

    /// <summary>
    /// Metode utama untuk mendeteksi SQL Injection.
    /// </summary>
    /// <param name="input">Input dari pengguna.</param>
    /// <returns>True jika input mencurigakan, false jika aman.</returns>
    public static string HasSQLInjection(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        // Normalisasi input ke lowercase untuk pencocokan case-insensitive
        input = input.ToLower();

        string result = ContainsAnyWord(input, SqlInjectionPatterns);


        return result;
    }

    public static string HasTagInjection(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        // Normalisasi input ke lowercase untuk pencocokan case-insensitive
        input = input.ToLower();

        string result = ContainsAnyWord(input, TagInjectionPatterns);
        return result;
    }

    public static string ContainsAnyWord(string input, string[] words)
    {
        if (string.IsNullOrEmpty(input) || words == null || words.Length == 0)
            return "";

        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word) && input.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return word;
            }
        }
        return "";
    }

    public static List<(string Word, int Position)> FindSQLWithPositions(string input)
    {
        var result = new List<(string Word, int Position)>();
        var words = SqlInjectionPatterns;
        if (string.IsNullOrEmpty(input) || words == null || words.Length == 0)
            return result;

        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                int position = input.IndexOf(word, StringComparison.OrdinalIgnoreCase);
                if (position != -1)
                {
                    result.Add((word, position));
                }
            }
        }

        return result;
    }
    public static List<(string Word, int Position)> FindTagWithPositions(string input)
    {
        var result = new List<(string Word, int Position)>();
        var words = SqlInjectionPatterns;
        if (string.IsNullOrEmpty(input) || words == null || words.Length == 0)
            return result;

        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                int position = input.IndexOf(word, StringComparison.OrdinalIgnoreCase);
                if (position != -1)
                {
                    result.Add((word, position));
                }
            }
        }

        return result;
    }

    public static string HexDecode(string str, int add = 45)
    {
        int len = str.Length;
        StringBuilder hasil = new StringBuilder();

        for (int i = 0; i < len; i += 2)
        {
            // Convert each two-character hex string to an integer, subtract the offset, and append the resulting character.
            string hexPair = str.Substring(i, 2);
            int charCode = Convert.ToInt32(hexPair, 16) - add;
            hasil.Append((char)charCode);
        }

        return hasil.ToString();
    }

    public static string HexEncode(string strInput = "", int add = 45)
    {
        string result = string.Empty;
        int length = strInput.Length;

        for (int i = 0; i < length; i++)
        {
            char currentChar = strInput[i];
            int charValue = currentChar + add;
            result += charValue.ToString("X").ToUpper(); // Convert to uppercase hexadecimal
        }

        return result;
    }


    private static bool HasSQLInjectionRegex(string input)
    {
        // Daftar pola regex untuk mendeteksi SQL Injection
        string[] regexPatterns = new[]
        {
            @"(\b(select|insert|update|delete|drop|alter|create|truncate|union|exec)\b)",
            @"([';]+--)",
            @"(xp_cmdshell|sp_executesql)",
            @"(\bor\b.*=|and\b.*=)",
            @"\b(waitfor delay|char\(|concat\(|information_schema)\b"
        };

        foreach (var pattern in regexPatterns)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                return true; // Pola mencurigakan ditemukan
            }
        }

        return false; // Tidak ada pola regex yang cocok
    }
}
