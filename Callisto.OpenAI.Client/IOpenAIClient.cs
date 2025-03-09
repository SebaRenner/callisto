namespace Callisto.OpenAI.Client;

public interface IOpenAIClient
{
    public Task<string> SendUserMessageAsync(string message, CancellationToken cancellationToken = default);
}
