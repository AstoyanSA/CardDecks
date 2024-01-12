namespace CardDecks.API.Services.Interfaces.Repository;

public interface IDeckRepository
{
    Task<int> CreateDeck(Deck deck, CancellationToken cts);
    Task DelecteDeck(Deck deck, CancellationToken cts);
    Task<Deck> GetDeck(int decId, CancellationToken cts);
    Task<List<Deck>> GetDecks(CancellationToken cts);
    Task UpdateDeck(Deck deck, CancellationToken cts);
}