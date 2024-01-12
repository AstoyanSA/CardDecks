namespace CardDecks.UI.Main;

public class MainFacade
{
    private readonly IDeckCommunicator _deckCommunicator;

    public MainFacade(IDeckCommunicator deckCommunicator)
    {
        _deckCommunicator = deckCommunicator;
    }

    public async Task<ObservableCollection<Deck>> GetDecks(CancellationToken cts)
    {
        return new ObservableCollection<Deck>(await _deckCommunicator.GetDecks(cts));
    }
}
