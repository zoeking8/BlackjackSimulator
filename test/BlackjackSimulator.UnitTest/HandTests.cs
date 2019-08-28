using NUnit.Framework;
using BlackjackSimulator;

namespace BlackjackSimulator.UnitTest
{
	public class HandTests
	{
		[Test]
		public void Score(score, score expected)
		{
			var actual = Hand.Score(score); 
			Assert.That(actual, Is.LessThanOrEqualTo(21));
		}
	}
}
