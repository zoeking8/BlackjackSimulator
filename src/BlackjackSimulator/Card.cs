using System;

namespace BlackjackSimulator
{
	public class Card
	{
		public Guid Id { get; }
		public Rank Rank { get; }
		public Suit Suit { get; }

		public Card(Suit suit, Rank rank)
		{
			Id = Guid.NewGuid();
			Suit = suit;
			Rank = rank;
		}
	}
}