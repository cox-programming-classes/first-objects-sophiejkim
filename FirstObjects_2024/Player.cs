using System.Xml.Schema;

namespace FirstObjects_2024;


public class Player
{
   private Hand _hand = new();



   public bool DidStand { get; private set; } = false;
   


   public void Hit(Card card) => _hand.Add(card);

   public void Stand() => DidStand = true;

   public void Reset()
   {
      _hand = new();
      DidStand = false;
   }

   public override string ToString() => $"{_hand} => {Score}";



   public int Score
   {
      get
      {
         var total = 0;
         var sorted = _hand.OrderBy(card => card.Value);
         foreach (var card in _hand)
         {
            if (card.Value == Value.Jack
                || card.Value == Value.Queen
                || card.Value == Value.King)
               total += 10;
            else if(card.Value == Value.AceLow ||
                    card.Value == Value.AceHigh)
            {
               
               total += 11;
               if (total > 21)
                  total -= 10;
            }
            else
            {
               total += card.Value;
            }

         }

         return total;
      }
   }
}

