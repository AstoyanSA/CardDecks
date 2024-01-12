namespace CardDecks.API.Models;

public class Card
{
    public int CardId { get; set; }

    public SuitType SuitType { get; set; }

    public CardValueType CardValue { get; set; }
}
