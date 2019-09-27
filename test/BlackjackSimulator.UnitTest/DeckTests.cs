using System.Linq;
using NUnit.Framework;
using BlackjackSimulatorUI;

namespace BlackjackSimulator.UnitTest

{
	public class DeckTests
	{
		[Test]
		public void DeckTest_NumberOfCards()
		{
			var deck = new Deck();
			{
				Assert.AreEqual(52, deck.Cards.Count);
			}
		}

		[Test]
		public void DeckTest_NumberOfSuit()
		{
			//var sortedDeck = new Deck();
			//sortedDeck.Cards.GroupBy(i => i.Suit);


			//Assert.AreEqual(13, sortedDeck.Count);

		}

	}
}



