namespace FirstObjects_2024;
/// <summary>
/// Represents a Standard Deck of Playing Cards
/// </summary>
public class Deck : IEnumerable<Card>
{
    private List<Card> cards;
/// <summary>
/// Initialize a new Deck of Cards
/// </summary>
    public Deck()
    {
        _cards = [];
        foreach( var suit in Suit.AllSuits)
        foreach (var value in Value.AceHighValues)
            _cards.Add(item:new Card(suit, value));  
    }
}