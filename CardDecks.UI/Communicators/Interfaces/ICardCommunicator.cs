namespace CardDecks.UI.Communicators.Interfaces;

public interface ICardCommunicator
{
    Task<List<Card>> GetCards(CancellationToken cts);
}