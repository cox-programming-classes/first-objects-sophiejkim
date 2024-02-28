using System.Collections;
using System.Security.Cryptography;

namespace FirstObjects_2024;

/// <summary>
/// Represents a Standard Deck of Playing Cards
/// </summary>
public class Deck : IEnumerable<Card>
{
    private List<Card> _cards;


    ///<summary>
    /// insert a single card at the Bottom of the Deck
    /// </summary>
    /// <param name="card "> The card to add.</param>
    public void AddToBottom(Card card) => _cards.Add(card);


    ///<summary>
    /// Add a collection of cards to the Bottom of the deck.
    /// </summary>
    /// <param name="cards">Cards to be added to the deck.</param>
    public void AddToBottom(IEnumerable<Card> cards) => _cards.AddRange(cards);
    
    /// <summary>
    /// Initialize a new Deck of Cards
    /// </summary>
    public bool IsEmpty => _cards.Count == 0;

    public Deck()
    {
        _cards = [];
        foreach (var suit in Suit.AllSuits)
        foreach (var value in Value.AceHighValues)
            _cards.Add(item: new Card(suit, value));

    }

    public Card DealOne()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException(message: "Deck is Empty!");
        var card= _cards.First();
        _cards.RemoveAt(index:0);
        return card;

    }
/// <summary>
/// deal n cards from the deck
/// </summary>
/// <param name="n"># of cards to return</param>
/// <returns></returns>
    public IEnumerable<Card> Deal(int n)
    {
        for (var i = 0; i < n; i++)
            yield return DealOne();
    }
    public IEnumerator<Card> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
   //split the deck 

   private (List<Card>, List<Card>) Split()
   {
       var pile1 = new List<Card>();
       var pile2 = new List<Card>();
       var count = _cards.Count;
       for (int i = 0; i < count; i++)
       {
           if (i % 2 == 0)
           {
               pile1.Add(_cards[0]);
               _cards.RemoveAt(0);
           }
       }

       return (pile1, pile2); 
   }
    
    
    

    public void InsertRandomly(Card card)
    {
        var n = RNG.Next(_cards.Count);
        _cards.Insert(n, card);
    }

    private static readonly Random RNG = new();
    
    public void InsertRandomly(IEnumerable<Card> cards)
    {
        foreach (var card in cards)
        {
            InsertRandomly(card);
        }
    }
    
    //shuffling a deck
    public void Shuffle()
    {
        //IEnumerable<Card> deck2 = _cards;
        var (pile1, pile2) = Split();
        InsertRandomly(pile1);
        InsertRandomly(pile2);

    }
    
}