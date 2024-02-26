
using FirstObjects_2024;

Console.WriteLine("Let's Play Cards!");
// create a new deck
/*Deck deck = new();
foreach (var card in deck)
{
    Console.WriteLine(card);
}

var cards  = deck.Deal( 5).ToList();
Console.WriteLine("I dealt some cards");

foreach (var card in cards)
{
    Console.WriteLine(card);
}*/
//Card card = new (Suit.Spades, Value.AceHigh);
//Console.WriteLine($"Check out that {card}!");

Console.WriteLine("Let's Play BlackJack!");
Deck deck = new();
deck.Shuffle();

Player dealer = new(), player = new();
dealer.Hit( deck.DealOne());
player.Hit( deck.DealOne());
dealer.Hit( deck.DealOne());
player.Hit(deck.DealOne());

Console.WriteLine($"Player : {player}");
while (!player.DidStand)
{
    if (dealer.Score < 18)
        dealer.Hit(deck.DealOne());
    else dealer.Stand();
    Console.WriteLine("[H]it or [S]tand?");
    var response = Console.ReadLine()!. ToUpperInvariant();
    if(response.StartsWith("H"))
        player.Hit(deck.DealOne());
    else if (response.StartsWith("S"))
        player.Stand();
    else Console.WriteLine("Mmmm... wat?");
}

