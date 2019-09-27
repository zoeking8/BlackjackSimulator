using System.Collections.Generic;

namespace BlackjackSimulatorUI
{
	public class Hand
	{
		private readonly List<Card> _cards;
		private static readonly Dictionary<Rank, int> _rankValues;
		private readonly int _bet;
		public IReadOnlyCollection<Card> Cards => _cards;
		public bool IsBlackjack => Score == 21 && _cards.Count == 2;

		public bool IsBust => Score > 21;
		public bool HasStuck { get; set; }
		public int Bet => _bet;



		public int Score
		{
			get
			{
				var score = 0;

				foreach (var card in _cards)
				{
					score += _rankValues[card.Rank];

					if (score > 21 && card.Rank == Rank.Ace)
					{
						score -= 10;
					}
				}

				return score;
			}
		}

		static Hand()
		{
			_rankValues = new Dictionary<Rank, int>
			{
				{ Rank.Two, 2 },
				{ Rank.Three, 3 },
				{ Rank.Four, 4 },
				{ Rank.Five, 5 },
				{ Rank.Six, 6 },
				{ Rank.Seven, 7 },
				{ Rank.Eight, 8 },
				{ Rank.Nine, 9 },
				{ Rank.Ten, 10 },
				{ Rank.Jack, 10 },
				{ Rank.Queen, 10 },
				{ Rank.King, 10 },
				{ Rank.Ace, 11 },
			};
		}

		public Hand(int bet)
		{
			_bet = bet;
			_cards = new List<Card>();
		}

		public void AddCard(Card card)
		{
			_cards.Add(card);
		}
	}
}