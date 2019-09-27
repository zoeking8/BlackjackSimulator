using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackSimulator
{
	class Program
	{
		static void Main(string[] args)
		{
			var table = new Table();
			var player1 = new Player("player1", 100);
			var dealer = new Dealer();

			Console.WriteLine("Do you want to play?");
			// add in logic for response 

			Console.WriteLine("How much do you want to bet?");
			var betAmount = Console.Read();

			player1.Hand = new Hand(betAmount); 

			player1.Hand.AddCard(table.Shoe.TakeCard());
			player1.Hand.AddCard(table.Shoe.TakeCard());


			player1.ShowHand();

		}

	}
}
