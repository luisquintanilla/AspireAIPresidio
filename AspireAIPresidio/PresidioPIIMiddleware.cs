using AspireAIPresidio.Domain;
namespace AspireAIPresidio.Middleware;

public class PresidioPIIMiddleware
{
    private HttpClient _analyzerClient;
    private HttpClient _anonymyzerClient;
    public PresidioPIIMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    private readonly RequestDelegate _next;

    public async Task InvokeAsync(HttpContext context, IHttpClientFactory httpClientFactory)
    {
        _analyzerClient = httpClientFactory.CreateClient("AnalyzerClient");
        _anonymyzerClient = httpClientFactory.CreateClient("AnonymyzerClient");

        var request = context.Request;
        var response = context.Response;
        
        // Delete original text
        response.Clear();
        
        // Set content type
        response.Headers.Add("Content-Type", "text/plain");

        if (request.Path == "/chat")
        {
            var requestText = request.Query["text"];
            //var requestBody = await new StreamReader(request.QueryString["text"]).ReadToEndAsync();

            var analyzerRequest = new AnalyzerRequest(requestText);

            var req = await _analyzerClient.PostAsJsonAsync("/analyze", analyzerRequest);
            
            var analyzerResponse = await req.Content.ReadFromJsonAsync<AnalyzerResponse[]>();

            var anonymyzerRequest = new AnonymyzerRequest(requestText, analyzerResponse);

            var anonymyzerResponse = await _anonymyzerClient.PostAsJsonAsync("/anonymize", anonymyzerRequest);

            var responseBody = await anonymyzerResponse.Content.ReadFromJsonAsync<AnonymyzerResponse>();

            await response.WriteAsync(responseBody.text);

            await _next(context);
        }
        else
        {
            await _next(context);
        }
    }
}


public static class PresidioPIIMiddlewareExtensions
{
    public static IApplicationBuilder UsePresidioPII(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<PresidioPIIMiddleware>();
    }
}