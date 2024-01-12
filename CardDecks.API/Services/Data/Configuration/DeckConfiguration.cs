namespace CardDecks.API.Services.Data.Configuration;

public class DeckConfiguration : IEntityTypeConfiguration<Deck>
{
    public void Configure(EntityTypeBuilder<Deck> builder)
    {
        builder.HasKey(x => x.DeckId);

        builder.Property(x => x.DeckName)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .HasMany(x => x.DeckCards)
            .WithMany(x => x.CardDecks)
            .UsingEntity<DecksCards>(x =>
            {
                x.HasKey(k => new { k.CardId, k.DeckId });
                x.HasIndex(x => x.CardId);
            });

    }
}
