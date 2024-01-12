namespace CardDecks.API.Models;

public class Card
{
    public int CardId { get; set; }

    public SuitType SuitType { get; set; }

    public CardValueType CardValue { get; set; }

    public bool IsForDeck36 { get; set; }

    public List<Deck> CardDecks { get; set; }
}
