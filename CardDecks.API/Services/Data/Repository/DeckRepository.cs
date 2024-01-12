namespace CardDecks.API.Services.Data.Repository;

public class DeckRepository : IDeckRepository
{
    private readonly CardDecksDbContext _context;

    public DeckRepository(CardDecksDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddDeck(Deck deck, CancellationToken cts)
    {
        await _context.Decks.AddAsync(deck, cts);
        await _context.SaveChangesAsync(cts);

        return deck.DeckId;
    }

    public async Task<List<Deck>> GetDecks(CancellationToken cts)
    {
        return await _context.Decks
            .Include(x => x.DeckCards)
            .ToListAsync(cts);
    }

    public async Task<Deck> GetDeck(int decId, CancellationToken cts)
    {
        return await _context.Decks
            .Include(x => x.DeckCards)
            .FirstOrDefaultAsync(x => x.DeckId == decId);
    }

    public async Task UpdateDeck(Deck deck, CancellationToken cts)
    {
        _context.Decks.Update(deck);
        await _context.SaveChangesAsync(cts);
    }

    public async Task DelecteDeck(Deck deck, CancellationToken cts)
    {
        _context.Decks.Remove(deck);
        await _context.SaveChangesAsync(cts);
    }
}
