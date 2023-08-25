using System;
namespace Blackjack
{
    public class Hand
    {
        private List<Card> cards;

        public List<Card> Cards { get; }

        public Hand()
        {
            cards = new List<Card>();
        }

        public int CountCard()
        {
            return cards.Count();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetTotalValue()
        {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    aceCount++;
                }
                total += card.GetValue();
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }
    }
}

