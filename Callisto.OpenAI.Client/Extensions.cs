using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Callisto.OpenAI.Client;

public static class Extensions
{
    public static IServiceCollection AddOpenAIClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.Configure<OpenAIClientOptions>(configuration.GetSection("OpenAI"));

        _ = serviceCollection.AddScoped<IOpenAIClient, OpenAIClient>();
        
        return serviceCollection;
    }
}
