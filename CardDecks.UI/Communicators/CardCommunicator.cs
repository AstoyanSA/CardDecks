namespace CardDecks.UI.Communicators;

public class CardCommunicator : CommunicatorBase, ICardCommunicator
{
    private const string Prefix = "api/card";

    public CardCommunicator(HttpClient httpClient, IOptionsMonitor<AppConfiguration> options)
        : base(httpClient, options)
    {
    }

    public async Task<List<Card>> GetCards(CancellationToken cts)
    {
        return await HttpClient.GetFromJsonAsync<List<Card>>($"{Prefix}", cts);
    }
}
