using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

public static class PresidioAnalyzerResourceBuilderExtensions
{
    public static IResourceBuilder<PresidioAnalyzerResource> AddPresidioAnalyzer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null)
    {
        var resource = new PresidioAnalyzerResource(name);

        return builder.AddResource(resource)
            .WithImage(PresidioAnalyzerImageTags.Image)
            .WithImageRegistry(PresidioAnalyzerImageTags.Registry)
            .WithImageTag(PresidioAnalyzerImageTags.Tag)
            .WithHttpEndpoint(
                targetPort: httpPort ?? 3000,
                name: PresidioAnalyzerResource.HttpEndpointName);
    }
}

public static class PresidioAnonymyzerResourceBuilderExtensions
{
    public static IResourceBuilder<PresidioAnonymyzerResource> AddPresidioAnonymizer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null)
    {
        var resource = new PresidioAnonymyzerResource(name);

        return builder.AddResource(resource)
            .WithImage(PresidioAnonymizerImageTags.Image)
            .WithImageRegistry(PresidioAnonymizerImageTags.Registry)
            .WithImageTag(PresidioAnonymizerImageTags.Tag)
            .WithHttpEndpoint(
                targetPort: httpPort ?? 3000,
                name: PresidioAnonymyzerResource.HttpEndpointName);
    }
}

internal static class PresidioAnalyzerImageTags
{
    internal const string Registry = "mcr.microsoft.com";

    internal const string Image = "presidio-analyzer";

    internal const string Tag = "latest";

}

internal static class PresidioAnonymizerImageTags
{
    internal const string Registry = "mcr.microsoft.com";

    internal const string Image = "presidio-anonymizer";

    internal const string Tag = "latest";
}