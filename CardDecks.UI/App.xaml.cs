using Microsoft.Extensions.Configuration;

namespace CardDecks.UI;

public partial class App : Application
{
    private readonly CancellationTokenSource source = new();
    public IServiceProvider Provider { get; }

    public App()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot configuration = builder.Build();

        IServiceCollection services = new ServiceCollection();
        services.Configure<AppConfiguration>(configuration.GetSection(nameof(AppConfiguration)));
        services.AddHttpServices();
        services.AddFacades();
        services.AddViewModels();
        services.AddMemoryCache();

        Provider = services.BuildServiceProvider();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        try
        {
            base.OnExit(e);
            source.Cancel();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}

