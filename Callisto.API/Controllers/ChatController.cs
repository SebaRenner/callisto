using Callisto.OpenAI.Client;
using Microsoft.AspNetCore.Mvc;

namespace Callisto.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IOpenAIClient _client;

    public ChatController(IOpenAIClient client) => _client = client;

    [HttpPost]
    public async Task<ActionResult<string>> SendUserMessageAsync(string message)
    {
        return await _client.SendUserMessageAsync(message);
    } 
}
