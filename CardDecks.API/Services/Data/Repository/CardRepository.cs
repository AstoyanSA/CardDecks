namespace CardDecks.API.Services.Data.Repository;

public class CardRepository : ICardRepository
{
    private readonly CardDecksDbContext _context;

    public CardRepository(CardDecksDbContext context)
    {
        _context = context;
    }

    public async Task<List<Card>> GetAllCards(CancellationToken cts)
    {
        return await _context.Cards.ToListAsync(cts);
    }

    public async Task<List<Card>> GetCardsForDeck36(CancellationToken cts)
    {
        return await _context.Cards
            .Where(x => x.IsForDeck36)
            .ToListAsync(cts);
    }
}
