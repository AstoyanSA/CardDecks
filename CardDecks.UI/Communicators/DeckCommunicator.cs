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
        return await response.Content.ReadFromJsonAsync<List<Deck>>(cancellationToken: cts);
    }

    public async Task<Deck> AddDeck(Deck deck, CancellationToken cts)
    {
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync($"{Prefix}", deck, cts);
        return await response.Content.ReadFromJsonAsync<Deck>(cancellationToken: cts);
    }

    public async Task<HttpResponseMessage> RemoveDeck(int id, CancellationToken cts)
    {
        return await HttpClient.DeleteAsync($"{Prefix}/{id}", cts);
    }

    public async Task<Deck> UpdateDeck(Deck deck, CancellationToken cts)
    {
        HttpResponseMessage response = await HttpClient.PutAsJsonAsync($"{Prefix}", deck, cts);
        return await response.Content.ReadFromJsonAsync<Deck>(cancellationToken: cts);
    }
}
