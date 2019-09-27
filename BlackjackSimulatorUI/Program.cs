using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackjackSimulatorUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.ForegroundColor = ConsoleColor.Black;
			//Console.BackgroundColor = ConsoleColor.White;
			//Console.Clear();

			var table = new Table(10);
			var player1 = new Player("player1", 100);
			var dealer = new Dealer();

			Console.WriteLine("Please input number of players:");
			var playerInput = Console.ReadLine();
			int numberOfPlayers;
			while (!Int32.TryParse(playerInput, out numberOfPlayers))
			{
				Console.WriteLine($"Ivalid amount. Please input number of players.");
				playerInput = Console.ReadLine();
			}

			Console.WriteLine();
			for (int i = 0; i<numberOfPlayers; i++)
			{
				Console.WriteLine("Please write the player's name: ");
				var playerName = Console.ReadLine();
				Console.WriteLine();
				var player = new Player(playerName, 100);
				table.AddPlayerToTable(player);
			}
					
			

			table.Shoe.Shuffle();

			while (table.PlayersAtTable.Any(x => x.WantsToPlay && x.Money > table.MinimumBet))
			{
				dealer.AskPlayersToBet(table); 

				dealer.DealToPlayer(table);
				dealer.DealToSelf(table.Shoe);
				dealer.DealToPlayer(table);
				dealer.DealToSelf(table.Shoe);

				dealer.ShowOneCard();
				player1.ShowHand(table);
								
				dealer.CheckBlackjackAllPlayers(table);

				dealer.AskPlayerToStickOrTwist(table);
			

				dealer.ShowHand();
				if (table.CurrentRoundPlayers.Any(player => !player.Hand.IsBust && !player.Hand.IsBlackjack))
				{
					dealer.Play(table.Shoe);
					dealer.CalculateWinnings(table);
				}


				dealer.AskToPlayNextRound(table);
				dealer.ClearCurrentRoundPlayers(table);
				dealer.DiscardDealerHand();
			}
		}
	}
}
