using Polly.Extensions.Http;

namespace CardDecks.UI;

public static class ServiceDependencies
{
    public static IServiceCollection AddFacades(this IServiceCollection services)
    {
        services.AddSingleton<MainFacade>();

        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();

        return services;
    }

    public static IServiceCollection AddHttpServices(this IServiceCollection services)
    {
        services.AddHttpClient<IDeckCommunicator, DeckCommunicator>()
            .AddPolicyHandler(RetryPolicy());
        services.AddHttpClient<ICardCommunicator, CardCommunicator>()
            .AddPolicyHandler(RetryPolicy());

        return services;
    }

    private static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(r => r.StatusCode == HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));
    }
}
