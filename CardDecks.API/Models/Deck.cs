namespace CardDecks.API.Models;

public class Deck
{
    public int DeckId { get; set; }

    public string DeckName { get; set; }

    public List<Card> DeckCards { get; set; }
}
