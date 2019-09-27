using System;
using System.Runtime.InteropServices.ComTypes;

namespace BlackjackSimulator
{
	public class Player
	{
		public Hand Hand { get; set; }
		public int Money { get; set; }
		public string Name { get; set; }

		public Player(string name, int money)
		{
			Money = money;
			Name = name;
		}

		public void ShowHand()
		{
			foreach (var card in Hand.Cards)
			{
				Console.Write($"{card.Rank}{card.Suit}");
			}
		}
	}
}