namespace CardDecks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeckController : ControllerBase
{
    private readonly DeckFacade _deckFacade;

    public DeckController(DeckFacade deckFacade)
    {
        _deckFacade = deckFacade;
    }

    [HttpPost]
    public async Task<ActionResult<Deck>> AddDeck(Deck deck, CancellationToken cts)
    {
        return await _deckFacade.AddDeck(deck, cts);
    }

    [HttpGet]
    public async Task<ActionResult<List<Deck>>> GetDecks(CancellationToken cts)
    {
        return await _deckFacade.GetDecks(cts);
    }

    [HttpGet("names")]
    public async Task<ActionResult<List<string>>> GetNamesOfDecks(CancellationToken cts)
    {
        return await _deckFacade.GetNamesOfDecks(cts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Deck>> GetDeckById(int id, CancellationToken cts)
    {
        return await _deckFacade.GetDeckById(id, cts);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateDeck(Deck deck, CancellationToken cts)
    {
        return await _deckFacade.UpdateDeck(deck, cts);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteDeck(int id, CancellationToken cts)
    {
        return await _deckFacade.DeleteDeck(id, cts);
    }
}
