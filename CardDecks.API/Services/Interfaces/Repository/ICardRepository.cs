namespace CardDecks.API.Services.Interfaces.Repository;

public interface ICardRepository
{
    Task<List<Card>> GetAllCards(CancellationToken cts);
    Task<List<Card>> GetCardsForDeck36(CancellationToken cts);
}