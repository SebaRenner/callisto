using System.ClientModel;

using Azure.AI.OpenAI;

using Microsoft.Extensions.Configuration;

using OpenAI.Chat;

namespace Callisto.OpenAI.Client;

public class OpenAIClient : IOpenAIClient
{
    ChatClient _chatClient;

    public OpenAIClient(IConfiguration configuration)
    {
        var endpoint = configuration["OpenAI:Endpoint"];
        // TODO: use DefaultAzureCredentials instead of apikey
        var apiKey = configuration["OpenAI:ApiKey"];
        var deploymentName = configuration["OpenAI:DeploymentName"];

        var azureClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));
        _chatClient = azureClient.GetChatClient(deploymentName);
    }
}
