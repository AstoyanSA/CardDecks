namespace CardDecks.API.Services.DeckService;

public class DeckFacade
{
    private readonly IDeckRepository _deckRepository;
    private CardFacade _cardFacade;

    public DeckFacade(IDeckRepository deckRepository, CardFacade cardFacade)
    {
        _deckRepository = deckRepository;
        _cardFacade = cardFacade;
    }

    public async Task<ActionResult<Deck>> AddDeck(Deck deck, CancellationToken cts)
    {
        deck.DeckCards = await _cardFacade.GetCards(deck.IsDeck36, cts);
        int response = await _deckRepository.AddDeck(deck, cts);

        return new CreatedAtActionResult(nameof(GetDeckById), nameof(Deck), new { deckId = response }, deck);
    }

    public async Task<ActionResult<List<Deck>>> GetDecks(CancellationToken cts)
    {
        List<Deck> deck = await _deckRepository.GetDecks(cts);

        return deck == null ?
            new NotFoundResult() :
            new OkObjectResult(deck);
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

    public async Task<ActionResult> UpdateDeck(Deck deck, CancellationToken cts)
    {
        await _deckRepository.UpdateDeck(deck, cts);

        return new OkResult();
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
