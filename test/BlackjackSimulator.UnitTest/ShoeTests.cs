using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BlackjackSimulatorUI;

namespace BlackjackSimulator.UnitTest
{
	public class ShoeTests
	{
		[Test]
		public void ShoeTest_NumberOfCards()
		{
			var shoe = new Shoe(4);
			{
				Assert.AreEqual(208, shoe.Cards.Count);
			}

		}
	}
}
