namespace AspireAIPresidio.Domain;

public record AnalyzerRequest(string text, string language="en");

public record AnalyzerResponse(int start, int end, float score, string entity_type);

public record AnonymyzerRequest(string text, AnalyzerResponse[] analyzer_results);

public record AnonymyzerResponse(string text);