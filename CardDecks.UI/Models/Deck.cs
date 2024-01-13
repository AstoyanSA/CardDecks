namespace CardDecks.UI.Models;

public class Deck : ViewModelBase
{
    private List<Card> _deckCards;
    private bool _isDeck36;

    public int DeckId { get; set; }

    public string DeckName { get; set; }

    public bool IsDeck36
    {
        get => _isDeck36;
        set => Set(ref _isDeck36, value);
    }

    public List<Card> DeckCards
    {
        get => _deckCards;
        set => Set(ref _deckCards, value);
    }
}
