namespace CardDecks.API.Services.Data.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(x => x.CardId);

        builder.Property(x => x.SuitType)
            .IsRequired()
            .HasMaxLength(20)
            .HasConversion<string>();

        builder.Property(x => x.CardValue)
            .IsRequired()
            .HasMaxLength(20)
            .HasConversion<string>();

        builder.Property(x => x.IsForDeck36)
            .IsRequired();
    }
}
