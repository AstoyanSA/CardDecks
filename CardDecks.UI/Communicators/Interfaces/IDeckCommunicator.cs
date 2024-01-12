namespace CardDecks.UI.Communicators;

public interface IDeckCommunicator
{
    Task<List<Deck>> GetDecks(CancellationToken cts);
}