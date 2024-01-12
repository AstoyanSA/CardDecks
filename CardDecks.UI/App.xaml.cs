using Microsoft.Extensions.Configuration;
using System.Windows;

namespace CardDecks.UI;

public partial class App : Application
{
    public IServiceProvider Provider { get; }

    public App()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot configuration = builder.Build();

        IServiceCollection services = new ServiceCollection();
        services.Configure<AppConfiguration>(configuration.GetSection(nameof(AppConfiguration)));
        services.AddMemoryCache();

        Provider = services.BuildServiceProvider();
    }
}

