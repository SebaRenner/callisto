using Microsoft.Extensions.DependencyInjection;

namespace Callisto.OpenAI.Client;

public static class Extensions
{
    public static IServiceCollection AddOpenAIClient(this IServiceCollection serviceCollection)
    {
        _ = serviceCollection.AddScoped<IOpenAIClient, OpenAIClient>();
        
        return serviceCollection;
    }
}
