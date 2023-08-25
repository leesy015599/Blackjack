using System;
namespace Blackjack
{
	public class Blackjack
	{
		public void Start(Player player, Dealer dealer, Deck deck)
		{
			Thread.Sleep(1000);
			Draw(player, deck);
			Thread.Sleep(500);
			Draw(player, deck);
			Thread.Sleep(1000);
			Draw(dealer, deck);
			Thread.Sleep(500);
			Draw(dealer, deck);
			Thread.Sleep(1000);
		}

		private void Draw(Player player, Deck deck)
		{
			Card card = player.DrawCardFromDeck(deck);
			ConsoleIO.PrintCard(player, card);
		}
	}
}

