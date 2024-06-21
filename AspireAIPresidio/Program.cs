using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using AspireAIPresidio.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Need to fix this to actually get the connection strings from resources
builder.Services.AddHttpClient("AnalyzerClient", client => { client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("ANALYZER_URL")); });
builder.Services.AddHttpClient("AnonymyzerClient", client => { client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("ANONYMIZER_URL")); });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UsePresidioPII();

app.MapPost("/chat", (string text) =>
{
    app.Logger.LogInformation($"Redacted information");
});

app.Run();


