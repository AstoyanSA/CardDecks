namespace CardDecks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly CardFacade _cardFacade;

    public CardController(CardFacade cardFacade)
    {
        _cardFacade = cardFacade;
    }

    [HttpGet]
    public async Task<ActionResult<List<Card>>> GetAllCards(CancellationToken cts)
    {
        return await _cardFacade.GetCards(false, cts);
    }
}
