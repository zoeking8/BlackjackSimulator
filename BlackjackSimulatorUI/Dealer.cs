using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackSimulatorUI
{
	public class Dealer
	{
		private Hand _hand;

		public Dealer()
		{
			_hand = new Hand(0);
		}

		internal void AskPlayersToBet(Table table)
		{
			foreach (var player in table.PlayersAtTable)
			{
				
				if (player.WantsToPlay && player.Money >= table.MinimumBet)
				{
					Console.WriteLine($"Money in {player.Name}'s bank: {player.Money}");
					Console.WriteLine($"The minimum bet for this table is {table.MinimumBet}. How much do you want to bet {player.Name}?");
					var input = (Console.ReadLine());
					int betAmount; 
					while (!Int32.TryParse(input, out betAmount) || betAmount < table.MinimumBet || betAmount > player.Money)
					{
						Console.WriteLine($"Ivalid bet amount. {player.Name}, please bet an amount between {table.MinimumBet} and {player.Money}");
						input = Console.ReadLine();
					}
					Console.WriteLine();
					player.Hand = new Hand(betAmount);
					player.Money -= player.Hand.Bet;
					table.CurrentRoundPlayers.Add(player);
				}
			}
		}

		internal void DealToPlayer(Table table)
		{
			foreach (var player in table.CurrentRoundPlayers)
			{
				player.Hand.AddCard(table.Shoe.TakeCard());
			}
		}

		internal void DealToSelf(Shoe shoe)
		{
			_hand.AddCard(shoe.TakeCard());
		}

		public void ShowOneCard()
		{
			var firstCard = _hand.Cards.First();
			Console.WriteLine($"Dealer's card: {firstCard.Rank} of {firstCard.Suit}.");
		}

		internal void ShowHand()
		{
			var cardsInDealersHand = new List<string>();
			Console.Write("Dealer's hand: ");
			foreach (var card in _hand.Cards)

			{
				cardsInDealersHand.Add($"{card.Rank} of {card.Suit}");
			}
			var newCardsInDealersHand = string.Join(", ", cardsInDealersHand);
			Console.Write(newCardsInDealersHand + ". ");
			Console.WriteLine($"Dealer's total:{_hand.Score}");
		}

		public void Play(Shoe shoe)
		{
			while (_hand.Score < 17)
			{
				_hand.AddCard(shoe.TakeCard());
				ShowHand();
			}
		}
		
		internal void CheckBlackjackAllPlayers(Table table)
		{
			foreach (var player in table.CurrentRoundPlayers)
			{
				if (player.Hand.IsBlackjack)
				{
					PayoutBlackjack(player);
				}
			}
		}
		public void PayoutBlackjack(Player player)
		{
			Console.WriteLine($"{player.Name} has Blackjack, you win!");
			player.Money += player.Hand.Bet * 2.5;
		}

		internal void ClearCurrentRoundPlayers(Table table)
		{
			table.CurrentRoundPlayers.Clear();
		}

		internal void AskPlayerToStickOrTwist(Table table)
		{
			foreach (var player in table.CurrentRoundPlayers)
			{
				while (!player.Hand.HasStuck && !player.Hand.IsBust)
				{
					Console.WriteLine($"{player.Name}, would you like to Stick (S) or Twist (T)?");
					var playerChoice = Console.ReadLine();
					switch (playerChoice)
					{
						case "T":
							player.Hand.AddCard(table.Shoe.TakeCard());
							player.ShowHand(table);
							if (player.Hand.IsBust)
							{
								Console.WriteLine($"{player.Name} is bust.");
							}
							break;
						case "S":
							player.Hand.HasStuck = true;
							player.ShowHand(table);
							break;
						default:
							Console.WriteLine($"Invalid input. {player.Name}, please input either S for stick or T for twist.");
							break;
					}
				}
			}
		}

		internal void CalculateWinnings(Table table)
		{
			foreach (var player in table.CurrentRoundPlayers)
			{
				if ((!player.Hand.IsBust && player.Hand.Score > _hand.Score) || (_hand.Score > 21 && !player.Hand.IsBust))
				{
					Console.WriteLine($"{player.Name} has beaten the dealer. You win.");
					player.Money += player.Hand.Bet * 2;
				}
				else if (player.Hand.Score == _hand.Score && !player.Hand.IsBust)
				{
					Console.WriteLine($"{player.Name} has drawn with the dealer.");
					player.Money += player.Hand.Bet;
				}
				else if (player.Hand.IsBust)
				{
					Console.WriteLine($"{player.Name} has gone bust, {player.Name} loses.");
				}
				else Console.WriteLine($"Dealer has beaten {player.Name}.");
			}
		}

		internal void DiscardDealerHand()
		{
			_hand = new Hand(0);
			//do something with current cards
		}

		internal void AskToPlayNextRound(Table table)
		{
			foreach (var player in table.PlayersAtTable)
			{
				if (player.Money >= table.MinimumBet)
				{
					Console.WriteLine($"{player.Name}, would you like to play again Y/N?");
					var playerDecision = Console.ReadLine();
					if (playerDecision == "N")
					{
						player.WantsToPlay = false;
					}
					else
					{
						player.WantsToPlay = true;
					}
				}
				else
				{
					Console.WriteLine($"Sorry {player.Name}, you have insufficient funds to play.");
				}
			}
		}
	}
}