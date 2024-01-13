namespace CardDecks.API.Services.DeckService;

public class DeckFacade
{
    private readonly IDeckRepository _deckRepository;
    private readonly CardFacade _cardFacade;

    public DeckFacade(IDeckRepository deckRepository,
        CardFacade cardFacade)
    {
        _deckRepository = deckRepository;
        _cardFacade = cardFacade;
    }

    public async Task<ActionResult<Deck>> AddDeck(Deck deck, CancellationToken cts)
    {
        int response = await _deckRepository.AddDeck(deck, cts);
        deck.DeckCards = await _cardFacade.GetCards(deck.IsDeck36, cts);
        await _deckRepository.UpdateDeck(deck, cts);

        return new CreatedAtActionResult(nameof(GetDeckById), nameof(Deck), new { id = response }, deck);
    }

    public async Task<ActionResult<List<Deck>>> GetDecks(CancellationToken cts)
    {
        List<Deck> deckList = await _deckRepository.GetDecks(cts);

        return deckList == null ?
            new NotFoundResult() :
            new OkObjectResult(deckList);
    }

    public async Task<ActionResult<List<string>>> GetNamesOfDecks(CancellationToken cts)
    {
        List<string> deck = await _deckRepository.GetNamesOfDecks(cts);

        return deck == null ?
            new NotFoundResult() :
            new OkObjectResult(deck);
    }

    public async Task<ActionResult<Deck>> GetDeckById(int deckId, CancellationToken cts)
    {
        Deck deck = await _deckRepository.GetDeck(deckId, cts);

        return deck == null ?
            new NotFoundResult() :
            new OkObjectResult(deck);
    }

    public async Task<ActionResult<Deck>> UpdateDeck(Deck deck, CancellationToken cts)
    {
        deck = await _deckRepository.GetDeck(deck.DeckId, cts);
        var shuffledCards = ShuffleDeck(deck.DeckCards);

        deck.DeckCards.Clear();
        await _deckRepository.UpdateDeck(deck, cts);

        deck.DeckCards.AddRange(shuffledCards);
        await _deckRepository.UpdateDeck(deck, cts);

        return new OkObjectResult(deck);
    }


    private static List<Card> ShuffleDeck(List<Card> cards)
    {
        List<Card> newCards = new List<Card>(cards);
        Random random = new Random();

        int i = newCards.Count;
        while (i > 0)
        {
            i--;
            int j = random.Next(0, i + 1);
            (newCards[i], newCards[j]) = (newCards[j], newCards[i]);
        }
        return newCards;
    }

    public async Task<ActionResult> DeleteDeck(int deckId, CancellationToken cts)
    {
        Deck deck = await _deckRepository.GetDeck(deckId, cts);

        if (deck != null)
        {
            await _deckRepository.DelecteDeck(deck, cts);
        }

        return new OkResult();
    }
}
