namespace CardDecks.UI.Main;

public class MainFacade
{
    private readonly IDeckCommunicator _deckCommunicator;
    private readonly ICardCommunicator _cardCommunicator;
    private readonly ServiceLocator _serviceLocator;

    public MainFacade(IDeckCommunicator deckCommunicator, ICardCommunicator cardCommunicator)
    {
        _deckCommunicator = deckCommunicator;
        _cardCommunicator = cardCommunicator;
        _serviceLocator = new ServiceLocator();
    }

    public async Task<ObservableCollection<Deck>> GetDecks(CancellationToken cts)
    {
        return new ObservableCollection<Deck>(await _deckCommunicator.GetDecks(cts));
    }

    public async Task<List<Card>> GetCards(CancellationToken cts)
    {
        return await _cardCommunicator.GetCards(cts);
    }

    public async Task<Deck> AddDeck(Deck deck, CancellationToken cts)
    {
        return await _deckCommunicator.AddDeck(deck, cts);
    }

    public async Task RemoveDeck(Deck deck, CancellationToken cts)
    {
        await _deckCommunicator.RemoveDeck(deck.DeckId, cts);
        _serviceLocator.MainViewModel.DeckList.Remove(deck);
    }

    public async Task ShuffleDeck(Deck deck, CancellationToken cts)
    {
        List<Card> newCardList = new();
        var shuffledDeck = await _deckCommunicator.UpdateDeck(deck, cts);

        int i = shuffledDeck.DeckCards.Count;
        while (i > 0)
        {
            --i;
            newCardList.Add(shuffledDeck.DeckCards.ElementAt(i));
        }

        deck.DeckCards = newCardList;
    }
}
