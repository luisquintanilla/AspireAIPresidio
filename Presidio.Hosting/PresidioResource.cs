namespace Aspire.Hosting.ApplicationModel;

public sealed class PresidioAnalyzerResource(string name) : ContainerResource(name), IResourceWithConnectionString
{
    internal const string HttpEndpointName = "http";

    private EndpointReference? _httpReference;

    public EndpointReference HttpEndpoint => 
        _httpReference ??= new (this, HttpEndpointName);

    public ReferenceExpression ConnectionStringExpression => 
        ReferenceExpression.Create($"http://{HttpEndpoint.Property(EndpointProperty.Host)}:{HttpEndpoint.Property(EndpointProperty.Port)}");
}

public sealed class PresidioAnonymyzerResource(string name) : ContainerResource(name), IResourceWithConnectionString
{
    internal const string HttpEndpointName = "http";

    private EndpointReference? _httpReference;

    public EndpointReference HttpEndpoint =>
        _httpReference ??= new(this, HttpEndpointName);

    public ReferenceExpression ConnectionStringExpression =>
        ReferenceExpression.Create($"http://{HttpEndpoint.Property(EndpointProperty.Host)}:{HttpEndpoint.Property(EndpointProperty.Port)}");
}