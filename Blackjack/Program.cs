namespace Blackjack;

public enum Suit { Hearts, Diamonds, Clubs, Spades }
public enum Rank { Two = 2, Three, Four, Five, Six, Seven,
            Eight, Nine, Ten, Jack, Queen, King, Ace }

class Program
{
    static void Main()
    {
        Player player = new();
        Dealer dealer = new();
        Deck deck = new();
        Blackjack game = new();

        Console.Clear();
        ConsoleIO.PrintTable();

        game.Start(player, dealer, deck);

        Console.SetCursorPosition(0, 18);
    }
}

