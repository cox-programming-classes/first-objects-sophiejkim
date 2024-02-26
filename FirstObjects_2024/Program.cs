
using FirstObjects_2024;

Console.WriteLine("Let's Play Cards!");
// create a new deck
Deck deck = new();
foreach (var card in deck)
{
    Console.WriteLine(card);
}

var cards  = deck.Deal( 5).ToList();
Console.WriteLine("I dealt some cards");

foreach (var card in cards)
{
    Console.WriteLine(card);
}
//Card card = new (Suit.Spades, Value.AceHigh);
//Console.WriteLine($"Check out that {card}!");
