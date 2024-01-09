
namespace FinalProject
{
	public class Player
	{
		// Base class for User and Dealer

		private int total_points;
		public int TotalPoints
		{
			get { return total_points; }
		}
		public Player()
		{
			total_points = 0;
		}
		public bool CheckIfBust()
		{
			if (total_points > 21)
				return true;
			else return false;
		}
		public void AddPoints(int points)
		{
			total_points += points;
		}
		public void RestartGame()
		{
			total_points = 0;
		}
	}
}
