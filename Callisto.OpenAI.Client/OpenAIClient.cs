using System.ClientModel;
using Azure.AI.OpenAI;

using Microsoft.Extensions.Options;

using OpenAI.Chat;

namespace Callisto.OpenAI.Client;

public class OpenAIClient : IOpenAIClient
{
    private readonly ChatClient _chatClient;

    public OpenAIClient(IOptions<OpenAIClientOptions> options)
    {
        var endpoint = options.Value.Endpoint;
        // TODO: use DefaultAzureCredentials instead of apikey
        var apiKey = options.Value.ApiKey;
        var deploymentName = options.Value.DeploymentName;

        var azureClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));
        _chatClient = azureClient.GetChatClient(deploymentName);
    }

    public async Task<string> SendUserMessageAsync(string message, CancellationToken cancellationToken = default)
    {
        var userMessage = new UserChatMessage(message);

        var chatCompletion = await _chatClient.CompleteChatAsync(
            [userMessage],
            CreateChatCompletionOptions(),
            cancellationToken: cancellationToken);

        if (chatCompletion.Value.ToolCalls.Count > 0)
        {
            var expression = chatCompletion.Value.ToolCalls[0].FunctionArguments.ToString();
        }

        var response = chatCompletion.Value.Content[0].Text;
        return response;
    }

    private ChatCompletionOptions CreateChatCompletionOptions()
    {
        var calculator = ChatTool.CreateFunctionTool(
            "Calculator",
            "Perform all kinds of mathematical calculations",
            BinaryData.FromString("""
                {
                    "type": "object",
                    "properties": {
                        "expression": {
                            "type": "string",
                            "description": "The mathematical expression to calculate."
                        }
                    },
                    "required": ["expression"]
                }
                """));

        var options = new ChatCompletionOptions();
        options.Tools.Add(calculator);

        return options;
    }
}
