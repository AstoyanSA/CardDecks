namespace CardDecks.API.Services;

internal class Factory
{
    public static List<Card> GenerateAllCards()
    {
        List<Card> allCards = new();
        int i = 0;

        foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
        {
            foreach (CardValueType cardValue in Enum.GetValues(typeof(CardValueType)))
            {
                allCards.Add(new()
                {
                    CardId = ++i,
                    SuitType = suit,
                    CardValue = cardValue,
                    IsForDeck36 = cardValue > CardValueType.Five,
                    CardDecks = new()
                });
            }
        }

        return allCards;
    }
}
