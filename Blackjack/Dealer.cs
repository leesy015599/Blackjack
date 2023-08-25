using System;
namespace Blackjack
{
	public class Dealer : Player
	{
		public void DrawTillOver17(Deck deck)
		{
			while (Hand.GetTotalValue() < 17)
			{
				DrawCardFromDeck(deck);
			}
		}
	}
}

