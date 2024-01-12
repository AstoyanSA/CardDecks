namespace CardDecks.API.Services.CardService;

public class CardFacade
{
    private readonly ICardRepository _cardRepository;

    public CardFacade(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<List<Card>> GetCards(bool isDeck36, CancellationToken cts)
    {
        return isDeck36 ?
            await _cardRepository.GetCardsForDeck36(cts) :
            await _cardRepository.GetAllCards(cts);
    }
}
