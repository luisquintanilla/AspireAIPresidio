# Aspire Presidio Sample

This sample shows how to configure [Presidio](https://microsoft.github.io/presidio/) with .NET Aspire for PII redaction purposes inside an .NET Web API application.

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