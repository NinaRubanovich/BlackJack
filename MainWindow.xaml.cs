using System;
using System.Windows;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start_game_button.IsEnabled = false;
            money_textbox.FontSize= 32;

        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Start game by creating and showing game window
            GameWindow win = new GameWindow();
            win.Show();
            start_game_button.IsEnabled = false;

        }

        private void GameRules_Click(object sender, RoutedEventArgs e)
        {
            // Display game rules
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

        private void EnterMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Money has to be a positive, non-zero number
                double user_total_money = Convert.ToDouble(money_textbox.Text);
                if (user_total_money <= 0)
                    throw new Exception();
                start_game_button.IsEnabled = true;
            }
            catch
            {
                string messageBoxText = "Please enter a positive non-zero number amount, either with a decimal or without. No special characters, inclusing $, are allowed.";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }
    }
}
