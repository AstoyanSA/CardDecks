namespace CardDecks.UI.Communicators;

public class DeckCommunicator : CommunicatorBase, IDeckCommunicator
{
    private const string Prefix = "api/deck";

    public DeckCommunicator(HttpClient httpClient, IOptionsMonitor<AppConfiguration> options)
        : base(httpClient, options)
    {
    }

    public async Task<List<Deck>> GetDecks(CancellationToken cts)
    {
        HttpResponseMessage response = await HttpClient.GetAsync($"{Prefix}", cts);
        return await response.Content.ReadFromJsonAsync<List<Deck>>();
    }
}
