namespace CardDecks.API.Services.Data;

public static class SeedData
{
    public static List<Card> Cards => Factory.GenerateAllCards();
}
