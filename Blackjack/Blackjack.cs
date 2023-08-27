using System;
namespace Blackjack
{
	public class Blackjack
	{
		public void GameStart(Player player, Dealer dealer, Deck deck)
		{
			Thread.Sleep(500);
			Draw(player, deck);
			Draw(player, deck);
			Thread.Sleep(500);
			Draw(dealer, deck);
			Draw(dealer, deck);
		}

		private void Draw(Player player, Deck deck)
		{
			Card card = player.DrawCardFromDeck(deck);
			ConsoleIO.PrintCard(player, card);
		}

		public void Hit(Player player, Deck deck)
		{
			Thread.Sleep(200);
			Draw(player, deck);
		}

		public void Stand(Dealer dealer, Deck deck)
		{
			while (dealer.Hand.GetTotalValue() < 17)
			{
				Card card = dealer.DrawCardFromDeck(deck);
				ConsoleIO.PrintCard(dealer, card);
			}
		}

		public bool IsBust(Player player)
		{
			int playerScore = player.Hand.GetTotalValue();
			if (playerScore > 21)
				return true;
			return false;
		}

		public bool IsBlackjack(Player player)
		{
			int playerScore = player.Hand.GetTotalValue();

			if (playerScore == 21)
				return true;
			return false;
		}

		public bool IsOver(Player player, Dealer dealer)
		{
			int playerScore = player.Hand.GetTotalValue();
			int dealerScore = dealer.Hand.GetTotalValue();

			if ((playerScore >= 21) || (dealerScore >= 21))
				return true;

			return false;
		}

		public void GameOver(Player player, Dealer dealer)
		{
			ConsoleIO.RevealHiddenCard(dealer);
			ConsoleIO.WriteScore(player);
			int playerScore = player.Hand.GetTotalValue();
			int dealerScore = dealer.Hand.GetTotalValue();

			if (playerScore > 21)
			{
				ConsoleIO.Lose();
			}
			else
			{
				Thread.Sleep(800);
				if (dealerScore > 21)
					ConsoleIO.Win();
				else if (playerScore > dealerScore)
					ConsoleIO.Win();
				else if (playerScore < dealerScore)
					ConsoleIO.Lose();
				else // push
					ConsoleIO.Push();
			}
			Thread.Sleep(1000);
		}
	}
}

