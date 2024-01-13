
namespace CardDecks.API.Services.Data.Repository;

public class CardRepository : ICardRepository
{
    private readonly CardDecksDbContext _context;

    public CardRepository(CardDecksDbContext context)
    {
        _context = context;
        if (!_context.Cards.Any())
        {
            _ = LoadData(CancellationToken.None);
        }
    }

    private async Task LoadData(CancellationToken cts)
    {
        await _context.Cards.AddRangeAsync(SeedData.Cards);
        await _context.SaveChangesAsync(cts);
    }

    public async Task<List<Card>> GetAllCards(CancellationToken cts)
    {
        return await _context.Cards
            .Include(x => x.CardDecks)
            .ToListAsync(cts);
    }

    public async Task<List<Card>> GetCardsForDeck36(CancellationToken cts)
    {
        return await _context.Cards
            .Where(x => x.IsForDeck36)
            .Include(x => x.CardDecks)
            .ToListAsync(cts);
    }
}
