namespace Callisto.OpenAI.Client;

public class OpenAIClientOptions
{
    public required string Endpoint { get; set; }
    public required string ApiKey { get; set; }
    public required string DeploymentName { get; set; }
}
