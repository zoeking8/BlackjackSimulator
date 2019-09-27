using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace BlackjackSimulatorUI
{
	public class Player
	{
		public Hand Hand { get; set; }
		public double Money { get; set; }
		public string Name { get; set; }
		public bool WantsToPlay = true; 

		public Player(string playerName, int money)
		{
			Money = money;
			Name = playerName;
		}

		public void ShowHand(Table table)
		{
			foreach (var player in table.CurrentRoundPlayers)
			{
				var listOfCards = new List<string>();	
				Console.Write($"{player.Name}'s hand: ");
				foreach (var card in player.Hand.Cards)
				{
					
					listOfCards.Add($"{card.Rank} of {card.Suit}");
				}
				var newListOfCards = string.Join(", ", listOfCards);
				Console.Write(newListOfCards + ". ");
				Console.WriteLine($"{player.Name}'s total:{player.Hand.Score}");

			}
		}
	}
}