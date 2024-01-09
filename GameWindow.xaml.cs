using System;
using System.Threading;
using System.Windows;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for WindowA.xaml
    /// </summary>

    public partial class GameWindow : Window
    {
        // For each game, there is a user, dealer, and deck of cards
        User user = new User(Convert.ToDouble(((MainWindow) Application.Current.MainWindow).money_textbox.Text));
        Dealer dealer = new Dealer();
        DeckofCards deckofCards = new DeckofCards();

        public GameWindow()
        {
            // initial design details when window is opened
            InitializeComponent();
            hit_button.IsEnabled = false;
            stand_button.IsEnabled = false;
            game_textbox.Text = "Delete this text and replace it with your bet. Then, click 'Place Bet'.";
            playAgain_button.IsEnabled = false;
        }

        public void BeginGame()
        {

            // 1st Round
            user.CurrentBet = Convert.ToDouble(game_textbox.Text);
            place_bet_button.IsEnabled = false;
            game_textbox.Text = "Let's begin! ...";
       
            Thread.Sleep(1000);
            var playercard1 = deckofCards.GetCard();
            int playercard1_value = playercard1.getCardValue(user.TotalPoints);
            playerTextBox1.Text = playercard1.DisplayCard(playercard1_value);
            user.AddPoints(playercard1_value);

            var playercard2 = deckofCards.GetCard();
            int playercard2_value = playercard2.getCardValue(user.TotalPoints);
            playerTextBox2.Text = playercard2.DisplayCard(playercard2_value);
            user.AddPoints(playercard2_value);
   
            var dealercard1 = deckofCards.GetCard();
            int dealercard1_value = dealercard1.getCardValue(dealer.TotalPoints);
            dealerTextBox2.Text = dealercard1.DisplayCard(dealercard1_value);
            dealer.AddPoints(dealercard1_value);


            if (user.TotalPoints == 21)
            {
                // User gets Blackjack
                game_textbox.Text = $"Congrats! You got Blackjack! You win ${user.CurrentBet}. Click the Play Again button if you want to play again.. Otherwise, click Exit.";
                user.AddMoney(user.CurrentBet);
                playAgain_button.IsEnabled = true;
            }

            // User does not get Blackjack, game continues
            hit_button.IsEnabled = true;
            stand_button.IsEnabled = true;
            game_textbox.Text = "Would you like to hit or stand? Click the button/s below.";
  
        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            place_bet_button.IsEnabled = true;
            user.RestartGame();
            dealer.RestartGame();
            deckofCards.RestartGame();

            playerTextBox1.Text = "";
            playerTextBox2.Text = "";
            dealerTextBox1.Text = "";
            dealerTextBox2.Text = "";

            game_textbox.IsReadOnly = false;
            hit_button.IsEnabled = false;
            stand_button.IsEnabled = false;
            game_textbox.Text = "Delete this text and replace it with your bet. Then, click bet.";
            playAgain_button.IsEnabled = false;

        }
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            hit_button.IsEnabled=false;
            stand_button.IsEnabled=false;
            playerTextBox1.Text = "";
            playerTextBox2.Text = "";
            Thread.Sleep(1000);

            var playercard1 = deckofCards.GetCard();
            int playercard1_value = playercard1.getCardValue(user.TotalPoints);
            playerTextBox1.Text = playercard1.DisplayCard(playercard1_value);
            user.AddPoints(playercard1_value);


            if (user.TotalPoints <= 21)
            {
                game_textbox.Text = $"You now have {user.TotalPoints} points. Hit or stand?";
                hit_button.IsEnabled = true;
                stand_button.IsEnabled = true;
            }

            else
            {
                // User busts
                game_textbox.Text = $"Oops... You busted and lost ${user.CurrentBet}. Click the Play Again button if you want to play again.. Otherwise, click Exit.";
                user.LoseMoney(user.CurrentBet);
                playAgain_button.IsEnabled = true;
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            hit_button.IsEnabled = false;
            stand_button.IsEnabled = false;
            Thread.Sleep(1000);

            game_textbox.Text = "Dealer's turn now... ";
            var dealercard2 = deckofCards.GetCard();
            int dealercard2_value = dealercard2.getCardValue(dealer.TotalPoints);
            dealerTextBox1.Text = dealercard2.DisplayCard(dealercard2_value);
            dealer.AddPoints(dealercard2_value);
            Thread.Sleep(1000);

            while (dealer.ChooseHit() == true)
            {

                game_textbox.Text = $"Dealer hidden card reveals a total of {dealer.TotalPoints} points. They have decided to Hit.";
                Thread.Sleep(1000);
            
                dealercard2 = deckofCards.GetCard();
                dealercard2_value = dealercard2.getCardValue(dealer.TotalPoints);
                dealerTextBox1.Text = dealercard2.DisplayCard(dealercard2_value);
                dealer.AddPoints(dealercard2_value);
                Thread.Sleep(1000);

            }

            if (dealer.CheckIfBust() == true)
            {
                // Dealer busts
                game_textbox.Text = $"Dealer busted! You won ${user.CurrentBet}.Click the Play Again button if you want to play again.. Otherwise, click Exit.";
                user.AddMoney(user.CurrentBet);
                playAgain_button.IsEnabled = true;
            }
            else if (dealer.TotalPoints > user.TotalPoints) 
            {
                // Dealer wins
                game_textbox.Text = $"Dealer won.. You lost ${user.CurrentBet}. Click the Play Again button if you want to play again.. Otherwise, click Exit.";
                user.LoseMoney(user.CurrentBet);
                playAgain_button.IsEnabled = true;
            }
            else
            {
                // User wins
                game_textbox.Text = $"Congrats! You won ${user.CurrentBet}! Click the Play Again button if you want to play again.. Otherwise, click Exit.";
                user.AddMoney(user.CurrentBet);
                playAgain_button.IsEnabled = true;
            }

        }

        private void PlaceBet_Click(object sender, RoutedEventArgs e)
        {
            double bet = 0;
            
            try
            {
                // Bet needs to be a positive non-zero number that is not greater than total amount of money
                bet = Convert.ToDouble(game_textbox.Text);
                if (bet <= 0 || bet > user.TotalMoney)
                    throw new Exception();
                game_textbox.IsReadOnly = true;
                BeginGame();
            }
            catch
            {
                if (bet > user.TotalMoney)
                {
                    string caption = "Error";
                    string messageBoxText = "You can't bet more money than you have!";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
                else
                {
                    string messageBoxText = "Please enter a positive non-zero number amount, either with a decimal or without. No special characters, including $, are allowed.";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
        }

        private void GameRules_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "For each game, both the dealer and you place your bet. You are first delt two cards face up, while the dealer recieves one card face up and" +
                " one card face down. You are then given a chance to draw more cards. You can either HIT or STAND. If choose HIT, you will be given an extra card. " +
                " Next, you can either choose HIT again or choose STAND if you do not wish to draw any more cards. You can choose HIT as many times as you'd like, but aim " +
                "to not bust (exceed a total of 21 points). If you bust, you immediately lose your bet. After you have either stood or busted, the dealer takes their turn. " +
                "The HIT and STAND rules are the same for the dealer as well. If the dealer reaches a valid hand (less than or equal to 21), their total card value is compared " +
                "to yours. If you score higher than the dealer, you win. If the dealer scores higher than you, you lose. If you tie with the dealer, your bet will be returned to you. " +
                "A perfect hand is the combination of an ace with a Ten, Jack, Queen, or King. This is known as BLACKJACK, and whoever draws this automatically wins.";
            string caption = "Game Rules";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void CheckMoney_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = $"Total Money (Current): ${user.TotalMoney}";
            string caption = "Game Rules";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
