namespace CardDecks.API.Services.Data;

public class CardDecksDbContext : DbContext
{
    public CardDecksDbContext(DbContextOptions<CardDecksDbContext> options) : base(options)
    {
        Cards.AddRange(SeedData.Cards);
    }

    public DbSet<Card> Cards { get; set; }

    public DbSet<Deck> Decks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");
    }
}
