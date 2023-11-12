namespace OpenBaseNET.Domain.Context;

public sealed class SessionContext
{
    public Guid Correlationid { get; set; } = Guid.NewGuid();
    public string Host { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string QueryString { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Dictionary<string, string> Headers { get; set; } = new();
}