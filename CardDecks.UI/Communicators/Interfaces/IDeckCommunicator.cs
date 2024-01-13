namespace CardDecks.UI.Communicators.Interfaces;

public interface IDeckCommunicator
{
    Task<Deck> AddDeck(Deck deck, CancellationToken cts);
    Task<List<Deck>> GetDecks(CancellationToken cts);
    Task<HttpResponseMessage> RemoveDeck(int id, CancellationToken cts);
    Task<Deck> UpdateDeck(Deck deck, CancellationToken cts);
}