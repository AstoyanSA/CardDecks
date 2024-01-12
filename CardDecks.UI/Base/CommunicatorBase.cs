namespace CardDecks.UI.Base;

public class CommunicatorBase
{
    private readonly IOptionsMonitor<AppConfiguration> _options;

    public CommunicatorBase(HttpClient httpClient, IOptionsMonitor<AppConfiguration> options)
    {
        _options = options;
        _options.OnChange(UpdateConfiguration);

        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri(_options.CurrentValue.DatabaseAddress);
    }

    public HttpClient HttpClient { get; }

    private void UpdateConfiguration(AppConfiguration configuration)
    {
        HttpClient.BaseAddress = new Uri(configuration.DatabaseAddress);
    }
}
