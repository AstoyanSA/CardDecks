namespace CardDecks.UI.Models;

public class Deck
{
    public int DeckId { get; set; }

    public string DeckName { get; set; }

    public bool IsDeck36 { get; set; }

    public List<Card> DeckCards { get; set; }
}
