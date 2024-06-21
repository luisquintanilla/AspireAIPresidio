# Aspire Presidio Sample

This sample shows how to configure [Presidio](https://microsoft.github.io/presidio/) with .NET Aspire for PII redaction purposes inside an .NET Web API application.

![AspireAIPresidio trace for redaction request displayed in Aspire Dashboard](https://github.com/luisquintanilla/AspireAIPresidio/assets/46974588/0d82e4a8-d217-4f52-b7d6-fa45fd1ef57a)


## Project structure

- **AppHost** - .NET Aspire Application Host
- **ServiceDefaults** - .NET Aspire Service Defaults
- **AspireAIPresidio** - .NET Web API with Presidio Middleware
- **Presidio.Hosting** - .NET Aspire Presidio Custom Component

## Use cases

- Redact user prompts for GenAI applications

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
- [Docker](https://docs.docker.com/desktop/)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download)

## Run the application

1. In Visual Studio, Press <kbd>F5</kbd> or in the terminal, navigate to the *AppHost* project and enter `dotnet run`

### Sample Request in Swagger UI

![Image of chat request in Swagger UI](https://github.com/luisquintanilla/AspireAIPresidio/assets/46974588/a7f570b0-02fb-4b7b-9bdb-ddbc72240ef3)

