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
        Blackjack blackjack = new();

        Console.Clear();
        ConsoleIO.PrintTable();

        blackjack.GameStart(player, dealer, deck);

        bool isFirstLoop = true;
        while (true)
        {
            if (isFirstLoop)
            {
                if (blackjack.IsBlackjack(player))
                    break ;
            }
            isFirstLoop = false;
            ConsoleIO.WriteScore(player);
            ConsoleIO.WriteScore(dealer);
            if (blackjack.IsOver(player, dealer))
            {
                blackjack.Stand(dealer, deck);
                break ;
            }
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.D1)
            {
                blackjack.Hit(player, deck);
                if (blackjack.IsBust(player))
                    break ;
            }
            else if (pressedKey.Key == ConsoleKey.D2)
            {
                blackjack.Stand(dealer, deck);
                break ;
            }
        }
        blackjack.GameOver(player, dealer);

        Console.SetCursorPosition(0, 18);
    }
}

