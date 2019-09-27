using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using BlackjackSimulatorUI;

namespace BlackjackSimulator.UnitTest

{
	public class DealerTests
	{
		[Test]
		public void DealerTest_PayOutBlackjackWinnings()
		{
			var dealer = new Dealer();
			var player = new Player("name", 100);
			player.Hand = new Hand(10);
			dealer.PayoutBlackjack(player);
			Assert.AreEqual(player.Money, 125);


		}

		[TestCase("A", 100, 10, 125)]
		[TestCase("B", 10, 8, 30)]
	

		public void DealerTest_PayOutBlackjackWinning(string playerName, int money, int bet, int expectedResult)
		{
			Player player = new Player
			{
				Name = playerName,
				Money = money
			};

			player.Hand = new Hand(bet);

			var dealer = new Dealer();
			dealer.PayoutBlackjack(player);
			Assert.AreEqual(expectedResult, player.Money, player.Hand.Bet, player.Name);
		}
	}
}



