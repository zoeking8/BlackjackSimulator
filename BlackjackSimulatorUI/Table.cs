using System.Collections.Generic;

namespace BlackjackSimulatorUI
{
	public class Table
	{
		readonly List<Player> _playersAtTable;
		readonly List<Player> _currentRoundPlayers;
		public Shoe Shoe { get; set; }
		public int MinimumBet { get; set; }
		public List<Player> PlayersAtTable => _playersAtTable;
		public List<Player> CurrentRoundPlayers => _currentRoundPlayers;
		public Table(int minimumBet)
		{
			Shoe = new Shoe();
			MinimumBet = minimumBet;
			_playersAtTable = new List<Player>();
			_currentRoundPlayers = new List<Player>();
		}

		public void AddPlayerToTable(Player player)
		{
			_playersAtTable.Add(player);
		}
		
	}
}