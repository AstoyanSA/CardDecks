namespace CardDecks.UI.Models;

public class Deck : ViewModelBase
{
    private List<Card> _deckCards;

    public int DeckId { get; set; }

    public string DeckName { get; set; }

    public bool IsDeck36 { get; set; }

    public List<Card> DeckCards
    {
        get => _deckCards;
        set => Set(ref  _deckCards, value);
    }
}
