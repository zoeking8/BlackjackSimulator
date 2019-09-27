namespace BlackjackSimulator
{
	public class Table
	{
		public Shoe Shoe { get; set; }

		public Table()
		{
			Shoe = new Shoe();
		}
	}
}