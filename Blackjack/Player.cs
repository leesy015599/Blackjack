using System;
namespace Blackjack
{
    public class Player
    {
        public Hand Hand { get; private set; }

        public Player()
        {
            Hand = new Hand();
        }

        public Card DrawCardFromDeck(Deck deck)
        {
			Thread.Sleep(500);
            Card drawnCard = deck.DrawCard();
            Hand.AddCard(drawnCard);
            return drawnCard;
        }
    }
}

