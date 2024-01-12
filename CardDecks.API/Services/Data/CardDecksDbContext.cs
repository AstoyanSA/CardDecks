namespace CardDecks.API.Services.Data;

public class CardDecksDbContext : DbContext
{
    public CardDecksDbContext(DbContextOptions<CardDecksDbContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }

    public DbSet<Deck> Decks { get; set; }
}
