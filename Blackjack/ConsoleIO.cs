using Microsoft.VisualBasic;

namespace Blackjack
{
	public class ConsoleIO
	{
		private static string table =
	   "꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖\n"
	 + "\n"
	 + "  D E A L E R :\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "\n"
     + " ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚   1. hit    2. stand\n"
//   + " ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚  Y O U   W I N !  ˚ ˚ ˚ ˚   1. hit    2. stand\n"
//   + " ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚  Y O U   L O S E  ˚ ˚ ˚ ˚   1. hit    2. stand\n"
//   + " ˚ ˚ ˚ ˚ ˚ ˚ ˚ ˚   P U S H (tie)   ˚ ˚ ˚ ˚   1. hit    2. stand\n"
	 + "  P L A Y E R :\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "\n"
	 + "꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖꙳✧˖°⌖\n";

		private static string suitSymbol = "♥◆♣♠";
		private static string rankSymbol = "  234567891JQKA";
		public static void PrintTable()
		{
			Console.WriteLine(ConsoleIO.table);
		}

		public static void PrintCard(Player somebody, Card card)
		{
			int col = (somebody.Hand.CountCard() - 1) * 6 + 3;
			int row = (somebody.GetType() == typeof(Dealer)) ? 4 : 12;
			
			Console.SetCursorPosition(col, row);
			Console.Write("┌────┒");
			Console.SetCursorPosition(col, row + 1);
			Console.Write("│    ┃");
			Console.SetCursorPosition(col, row + 2);
			Console.Write("│    ┃");
			Console.SetCursorPosition(col, row + 3);
			Console.Write("┕━━━━┛");

			char rank = rankSymbol[(int)card.Rank];
			char suit = suitSymbol[(int)card.Suit];

			bool isHide = false;

			if ((somebody.GetType() == typeof(Dealer))
				&& (somebody.Hand.CountCard() != 1))
			{
				isHide = true;
				rank = '?';
				suit = '?';
			}
			Console.SetCursorPosition(col + 2, row + 1);
			Console.Write($"{rank}");
			if (((int)card.Rank == 10) && isHide == false)
				Console.Write("0");
			Console.SetCursorPosition(col + 3, row + 2);
			Console.Write($"{suit}");
		}

		public static void RevealHiddenCard(Dealer dealer)
		{
			Thread.Sleep(500);
			int cardCount = dealer.Hand.CountCard();

			int col = 0;
			int row = 4;
			int i = 0;
			foreach (Card card in dealer.Hand.Cards)
			{
				col = i++ * 6 + 3;
				Console.SetCursorPosition(col + 2, row + 1);
				Console.Write($"{rankSymbol[(int)card.Rank]}");
				if ((int)card.Rank == 10)
					Console.Write("0");
				Console.SetCursorPosition(col + 3, row + 2);
				Console.Write($"{suitSymbol[(int)card.Suit]}");
			}

			Console.SetCursorPosition(16, 2);
			Console.Write("   ");
			Console.SetCursorPosition(16, 2);
			Console.Write(dealer.Hand.GetTotalValue());
		}

		public static void WriteScore(Player player)
		{
			bool isDealer = false;
			if (player.GetType() == typeof(Dealer))
				isDealer = true;
			int row = isDealer ? 2 : 10;
			Console.SetCursorPosition(16, row);
			if (isDealer)
				Console.Write("???");
			else
				Console.Write(player.Hand.GetTotalValue());
		}

		public static void Win()
		{
			Console.SetCursorPosition(17, 9);
			Console.Write(" Y O U   W I N ! ");
		}

		public static void Lose()
		{
			Console.SetCursorPosition(17, 9);
			Console.Write(" Y O U   L O S E ");
		}

		public static void Push()
		{
			Console.SetCursorPosition(17, 9);
			Console.Write("  P U S H (tie)  ");
		}
	}
}

