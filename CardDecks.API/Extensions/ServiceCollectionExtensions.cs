using CardDecks.API.Services.CardService;

namespace CardDecks.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IDeckRepository, DeckRepository>();

        return services;
    }
    public static IServiceCollection AddFacades(this IServiceCollection services)
    {
        services.AddScoped<CardFacade>();
        services.AddScoped<DeckFacade>();

        return services;
    }
}
