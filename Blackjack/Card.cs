using System;
namespace Blackjack
{
	public class Card
	{
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public Card(Suit s, Rank r)
		{
			Suit = s;
			Rank = r;
		}

        public int GetValue()
        {
            if ((int)Rank <= 10)
            {
                return (int)Rank;
            }
            else if ((int)Rank <= 13)
            {
                return 10;
            }
            else
            {
                return 11;
            }
        }
    }
}

