
namespace FinalProject
{
	public class Dealer: Player
	{
		// Class for the "dealer", which is just the computer
		public Dealer()
		{
		}

		public bool ChooseHit()
		{
			if (this.TotalPoints < 17)
				return true;
			else return false;
		}

	}
}
