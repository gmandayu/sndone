//Yang sqlinjectionmiddlewarebya pakai ini
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;
using System.Web;
using System.Text.Json; // For JSON parsing
using Microsoft.AspNetCore.Http;
 
public class SQLInjectionMiddleware
{
  private readonly RequestDelegate _next;

  public SQLInjectionMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    if (context.Request.Path.StartsWithSegments("/mwtChatHub"))
    {
        await _next(context);
        return;
    }
    // if (!IsLoggedIn())
    // {
    //   var response = new { message = "Not authorized." };
    //   string jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
              
    //   context.Response.ContentType = "application/json";
    //   await context.Response.WriteAsync(jsonResponse);
    //   return;
    // }
    
    string[] arrayWhiteList = { "action", 
      "g-recaptcha-response", 
      "g-captcha-response", 
      "h-recaptcha-response",
      "h-captcha-response",
      "__RequestVerificationToken",

    };
    // Periksa Query String
    var strMessageQueryString = "";
    foreach (var kunciItem in context.Request.Query.Keys)
    {
      string value = context.Request.Query[kunciItem].ToString() ?? "";
      string kunci = kunciItem;


        if (kunci == "search" || kunci.EndsWith("[]"))
        {
          string wordFound = SQLInjectionDetector.HasSQLInjection(value);

          if (wordFound != "")
          {
            context.Response.StatusCode = 400;
            strMessageQueryString += $"Potensi SQL Injection terdeteksi di Query String.\\n    Query String : {value} \\n    Word: {wordFound}\\n";

          }

          wordFound = SQLInjectionDetector.HasTagInjection(value);

          if (wordFound != "")
          {
            context.Response.StatusCode = 400;
            var matchSQL = SQLInjectionDetector.FindTagWithPositions(value);
            strMessageQueryString += $"Potensi Tag Injection terdeteksi di Query String.\\n    String {value} \\n    Word: {wordFound}\\n";


          }


        }
      }

      if (strMessageQueryString != "")
      {
        await context.Response.WriteAsync($"<script>alert(\"{strMessageQueryString}\");</script>");
        //await context.Response.WriteAsync("<script>alert('Anda akan di redirect ke Halaman Login.');</script>");
        //await context.Response.WriteAsync("<script>window.location = 'logout';</script>");
        return;
      }


      // Periksa Post Content
      if (context.Request.Method == HttpMethods.Post)
      {
        if (context.Request.ContentType != null)
        {
          context.Request.EnableBuffering(); // Allow the body to be read multiple times

          // Handle "application/x-www-form-urlencoded"
          if (context.Request.ContentType.Contains("application/x-www-form-urlencoded"))
          {
            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
              var body = await reader.ReadToEndAsync();
              context.Request.Body.Position = 0;

              var parsedBody = HttpUtility.ParseQueryString(body);
              string strMessageBody = "";
              string errorMessage = "";
              string injectionFound = "";

              bool keyFound = false;


              foreach (string? key in parsedBody.AllKeys)
              {
                string value = parsedBody[key] ?? "";
                injectionFound = SQLInjectionDetector.HasSQLInjection(value);

                keyFound = Array.Exists(arrayWhiteList, element => element.Equals(key ?? "", StringComparison.OrdinalIgnoreCase));


                if (injectionFound != "" && keyFound != true)
                {
                  context.Response.StatusCode = 400;
                    //errorMessage = $"\\nPotential SQL Injection detected [{injectionFound}] in parameter [{key}] with value [{value}].";
                    //strMessageBody += errorMessage.Replace("'", "\\'");
                    errorMessage = $"\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{key}].";
                    strMessageBody += errorMessage;

                }


                injectionFound = SQLInjectionDetector.HasTagInjection(value);

                if (injectionFound != "" && keyFound != true)
                {
                    context.Response.StatusCode = 400;
                        //errorMessage = $"\\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{key}] with value [{value}].";
                        //strMessageBody += errorMessage.Replace("'", "\\'");
                        errorMessage = $"\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{key}].";
                        strMessageBody += errorMessage;
                    }
              }

              if (strMessageBody != "")
              {
                    //context.Response.ContentType = "text/html";
                    //await context.Response.WriteAsync($"<script>alert('{strMessageBody}');</script>");
                    var response = new { message = strMessageBody };
                    string jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
                            
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(jsonResponse);


                    //await context.Response.WriteAsync("<script>alert('Anda akan di redirect ke Halaman Login.');</script>");
                    //await context.Response.WriteAsync("<script>window.location = 'logout';</script>");
                    return;
              }
            }
          }
          // Handle "application/json"
          else if (context.Request.ContentType.Contains("application/json"))
          {
            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
              var body = await reader.ReadToEndAsync();
              context.Request.Body.Position = 0;

            try
            {
              var jsonDocument = JsonDocument.Parse(body);
              JsonElement rootJson = jsonDocument.RootElement;
              string strMessageJson = "";
              string errorMessage = "";
              string injectionFound = "";


                if (jsonDocument.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (var element in jsonDocument.RootElement.EnumerateObject())
                    {
                        var value = element.Value.ToString();
                        injectionFound = SQLInjectionDetector.HasSQLInjection(value);
                        if (injectionFound != "")
                        {
                            context.Response.StatusCode = 400;
                            errorMessage = $"\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{element.Name}].";
                            strMessageJson += errorMessage;
                            //errorMessage = $"Potential SQL Injection detected [{injectionFound}] in JSON key '{element.Name}' with value '{value}'.\\n";
                            //strMessageJson += errorMessage.Replace("'", "\\'");
                        }

                        injectionFound = SQLInjectionDetector.HasTagInjection(value);
                        if (injectionFound != "")
                        {
                            context.Response.StatusCode = 400;
                            //errorMessage += $"Potential Tag Injection detected [{injectionFound}] in JSON key '{element.Name}' with value '{value}'.\\n";
                            //strMessageJson += errorMessage.Replace("'", "\\'");
                            errorMessage = $"\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{element.Name}].";
                            strMessageJson += errorMessage;
                        }
                    }
                }
                else if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in jsonDocument.RootElement.EnumerateArray())
                    {
                        foreach (var element in item.EnumerateObject())
                        {
                            var value = element.Value.ToString();
                            injectionFound = SQLInjectionDetector.HasSQLInjection(value);
                            if (injectionFound != "")
                            {
                                context.Response.StatusCode = 400;
                                //errorMessage = $"Potential SQL Injection detected [{injectionFound}] in JSON key '{element.Name}' with value '{value}'.\\n";
                                //strMessageJson += errorMessage.Replace("'", "\\'");
                                errorMessage = $"\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{element.Name}].";
                                strMessageJson += errorMessage;
                            }

                            injectionFound = SQLInjectionDetector.HasTagInjection(value);
                            if (injectionFound != "")
                            {
                                context.Response.StatusCode = 400;
                                //errorMessage += $"Potential Tag Injection detected [{injectionFound}] in JSON key '{element.Name}' with value '{value}'.\\n";
                                //strMessageJson += errorMessage.Replace("'", "\\'");
                                errorMessage = $"\nPotential Script Tag Injection detected [{injectionFound}] in parameter [{element.Name}].";
                                strMessageJson += errorMessage;
                            }
                        }
                    }
                }

                if (strMessageJson != "")
                {
                    //await context.Response.WriteAsync($"<script>alert('{strMessageJson}');</script>");
                    var response = new { message = strMessageJson };
                    string jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(jsonResponse);
                    //await context.Response.WriteAsync("<script>alert('Anda akan di redirect ke Halaman Login.');</script>");
                    //await context.Response.WriteAsync("<script>window.location = 'logout';</script>");
                    return;
                }
              }
              catch (System.Text.Json.JsonException)
              {
                // Handle invalid JSON if needed
              }
            }
          }

          // Handle "multipart/form-data"
          else if (context.Request.ContentType.Contains("multipart/form-data"))
          {
            var form = await context.Request.ReadFormAsync();
            string strMessageForm = "";
            string injectionFound = "";

            foreach (var key in form.Keys)
            {
              var value = form[key];

              injectionFound = SQLInjectionDetector.HasSQLInjection(value.ToString() ?? "");
              if (injectionFound != "")
              {
                context.Response.StatusCode = 400;
                strMessageForm += $"\nPotential SQL Injection detected [{injectionFound}] in form-data key '{key}'.";
                
            }


              injectionFound = SQLInjectionDetector.HasTagInjection(value.ToString() ?? "");
              if (injectionFound != "")
              {
                context.Response.StatusCode = 400;
                strMessageForm += $"\nPotential TAG Injection detected [{injectionFound}] in form-data key '{key}'.";

              }
            }

            if (strMessageForm != "")
            {
                //await context.Response.WriteAsync($"<script>alert('{strMessageForm}');</script>");
                var response = new { message = strMessageForm };
                string jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(jsonResponse);
                //await context.Response.WriteAsync("<script>alert('Anda akan di redirect ke Halaman Login.');</script>");
                //await context.Response.WriteAsync("<script>window.location = 'logout';</script>");
                return;
            }
          }
        }
      }


      //Periksa Content Path
      // Get the URL path
      var path = context.Request.Path.Value;

      // Check if any of the target words are present in the URL
      foreach (var word in SQLInjectionDetector.UrlWordCheckList)
      {
        if (path != null && path.Contains(word, StringComparison.OrdinalIgnoreCase))
        {
          // var strMessageApiQueryString = "";
          foreach (var kunciItem in context.Request.Query.Keys)
          {
            //string value = context.Request.Query[kunciItem];
            //string kunci = kunciItem;

            string wordFound = SQLInjectionDetector.HasSQLInjection(context.Request.Query[kunciItem].ToString() ?? "");

            if (wordFound != "")
            {
              context.Response.StatusCode = 400;

              strMessageQueryString += $"Potensi SQL Injection terdeteksi di Query String.\\n    " +
                $"Query Parameter : {kunciItem} \\n    " +
                $"Query Value     : {context.Request.Query[kunciItem]} \\n    " +
                $"Word            : {wordFound}\\n";
            }

            wordFound = SQLInjectionDetector.HasTagInjection(context.Request.Query[kunciItem].ToString() ?? "");

            if (wordFound != "")
            {
              context.Response.StatusCode = 400;
              var matchSQL = SQLInjectionDetector.FindTagWithPositions(context.Request.Query[kunciItem].ToString() ?? "");
              strMessageQueryString += $"Potensi SQL Injection terdeteksi di Query String.\\n    " +
                $"Query Parameter : {kunciItem} \\n    " +
                $"Query Value     : {context.Request.Query[kunciItem]} \\n    " +
                $"Word            : {wordFound}\\n";

            }
          }

          if (strMessageQueryString != "")
          {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync($"<script>alert(\"{strMessageQueryString}\");</script>");
            //await context.Response.WriteAsync("<script>alert('Anda akan di redirect ke Halaman Login.');</script>");
            //await context.Response.WriteAsync("<script>window.location = 'logout';</script>");
            return;
          }
        }
      }


      // Lanjutkan ke middleware berikutnya jika aman
      await _next(context);
    }
}
