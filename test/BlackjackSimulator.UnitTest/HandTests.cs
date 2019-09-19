using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BlackjackSimulator;

namespace BlackjackSimulator.UnitTest
{
	public class HandTests
	{
		[Test]
		public void HandTest_ctor()
		{
			var hand = new Hand();
			
			Assert.AreEqual(0, hand.Cards.Count);
			Assert.AreEqual(false, hand.IsBust);
			Assert.AreEqual(0, hand.Score);
		}

		[Test]
		public void HandTest_AddCard_2xAceClubs()
		{
			var cards = new[]
			{
				new Card(Suit.Clubs, Rank.Ace),
				new Card(Suit.Clubs, Rank.Ace)
			};
			const bool expectedIsBust = false;
			const int expectedScore = 12;

			HandTest_AddCard(cards, expectedIsBust, expectedScore);
		}

		[Test]
		public void HandTest_AddCard_Blackjack()
		{
			var cards = new[]
			{
				new Card(Suit.Clubs, Rank.Ace),
				new Card(Suit.Clubs, Rank.Ten)
			};
			const bool expectedIsBust = false;
			const int expectedScore = 21;

			HandTest_AddCard(cards, expectedIsBust, expectedScore);
		}

		private static void HandTest_AddCard(IReadOnlyCollection<Card> cards, bool expectedIsBust, int expectedScore)
		{
			var hand = new Hand();

			foreach (var card in cards)
			{
				hand.AddCard(card);
			}

			Assert.AreEqual(cards.Count, hand.Cards.Count);

			foreach (var card in cards)
			{
				Assert.IsTrue(hand.Cards.Any(c => c.Id == card.Id));
			}

			Assert.AreEqual(expectedIsBust, hand.IsBust);
			Assert.AreEqual(expectedScore, hand.Score);
		}
	}
}
