using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var presidioAnalyzer = builder.AddPresidioAnalyzer(name: "analyzer");
var presidioAnonymizer = builder.AddPresidioAnonymizer(name: "anonymizer");

//var analyzer =
//    builder.AddContainer(
//        name: "analyzer",
//        image: "presidio-analyzer")
//    .WithImageRegistry(registry: "mcr.microsoft.com")
//    .WithImageTag(tag: "latest")
//    .WithHttpEndpoint(targetPort:3000, name: "analyzer");

//var anonymyzer =
//    builder.AddContainer(
//        name: "anonymizer",
//        image: "presidio-anonymizer")
//    .WithImageRegistry(registry: "mcr.microsoft.com")
//    .WithImageTag(tag: "latest")
//    .WithHttpEndpoint(targetPort: 3000, name: "anonymyzer");

builder.AddProject<Projects.AspireAIPresidio>("aspireaipresidio")
    .WithReference(presidioAnalyzer)
    .WithReference(presidioAnonymizer)
    .WithEnvironment("ANALYZER_URL", presidioAnalyzer.GetEndpoint("http"))
    .WithEnvironment("ANONYMIZER_URL", presidioAnonymizer.GetEndpoint("http"));

builder.Build().Run();
