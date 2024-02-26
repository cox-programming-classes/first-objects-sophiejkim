using System.Collections;

namespace FirstObjects_2024;

public class hand //: IEnumerable<Card>
{
   private readonly List<Card> _cards;

   private static readonly Random rand = new();

//static means that it shared across all instances in this class
   public hand()
   {
      _cards = new();
   }

   public void Add(Card a)
   {
      _cards.Add(a);
   }

   public Card Take()
   {
      var card = _cards[0];
      _cards.RemoveAt(0);
      return card;
   }

   public Card TakeRandomly()
   {
      var n = rand.Next(_cards.Count);
      var card = _cards[n];
      _cards.RemoveAt(n);
      return card;
   }

   
 
}
