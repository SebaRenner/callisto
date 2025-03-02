using System.ClientModel;

using Azure.AI.OpenAI;

using Microsoft.Extensions.Options;

using OpenAI.Chat;

namespace Callisto.OpenAI.Client;

public class OpenAIClient : IOpenAIClient
{
    ChatClient _chatClient;

    public OpenAIClient(IOptions<OpenAIClientOptions> options)
    {
        var endpoint = options.Value.Endpoint;
        // TODO: use DefaultAzureCredentials instead of apikey
        var apiKey = options.Value.ApiKey;
        var deploymentName = options.Value.DeploymentName;

        var azureClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));
        _chatClient = azureClient.GetChatClient(deploymentName);
    }
}
