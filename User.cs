

namespace FinalProject
{
	// Class for the person playing the game/ running the program
	public class User : Player
	{
		// unlike dealer, the user can place bets
		double total_user_money;
		double current_bet;

		public double TotalMoney
		{
			get { return total_user_money;}
		}

		public double CurrentBet
		{
			get { return current_bet; }
			set { current_bet = value; }
		}

		public User(double total_user_money)
		{
			this.total_user_money = total_user_money;	
        }

		public bool IsOutOfMoney()
		{
			if (total_user_money == 0)
				return true;
			else return false;
		}

		public void AddMoney(double amount)
		{
			total_user_money += amount;

		}

		public void LoseMoney(double amount)
		{
			total_user_money -= amount;
		}
	}
}
