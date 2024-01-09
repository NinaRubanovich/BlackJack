using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    public struct Card
	{
		private String face;
		private String suit;
		public string Face
		{
			get { return face; }
			set { face = value; }
		}
		public String Suit
		{
			get { return suit; }
			set { suit = value; }
		}

        public int getCardValue(int total_points)
        {
      
            if (this.Face.Equals("Ace"))
            {
                if (total_points <= 10) return 11;
                else return 1;
            }
            switch (this.Face)
            {
                case "Deuce":
                    return 2;
                case "Three":
                    return 3;
                case "Four":
                    return 4;
                case "Five":
                    return 5;
                case "Six":
                    return 6;
                case "Seven":
                    return 7;
                case "Eight":
                    return 8;
                case "Nine":
                    return 9;
                case "Ten":
                    return 10;
                case "Jack":
                    return 10;
                case "Queen":
                    return 10;
                case "King":
                    return 10;
            }
            // 0 will be returned if there is an error
            return 0;
        }

        public string DisplayCard(int card_value)
        {
            // Returns a string to display the card in a nice way
            switch (this.Face)
            {
                case "Ace":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                     |\n\n|                           |\n\n|                           |\n\n|           {Suit}             |\n\n|                           |\n\n|                           |\n\n|                     {card_value}  |\n\n __   __   __   __   __    \n";
                case "Deuce":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|           {Suit}             |\n\n|                          |\n\n|                          |\n\n|                          |\n\n|           {Suit}             |\n\n|                     {card_value}    |\n\n __   __   __   __   __   \n";
                case "Three":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|           {Suit}             |\n\n|                          |\n\n|           {Suit}             |\n\n|                         |\n\n|           {Suit}             |\n\n|                     {card_value}   |\n\n __   __   __   __   __   \n";
                case "Four":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|      {Suit}            {Suit}   |\n\n|                            |\n\n|                           |\n\n|                           |\n\n|     {Suit}             {Suit}   |\n\n|                     {card_value}   |\n\n __   __   __   __   __   \n";
                case "Five":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                       |\n\n|     {Suit}            {Suit}      |\n\n|                           |\n\n|           {Suit}             |\n\n|                          |\n\n|     {Suit}             {Suit}    |\n\n|                     {card_value}   |\n\n __   __   __   __   __   \n";
                case "Six":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|     {Suit}            {Suit}      |\n\n|                            |\n\n|     {Suit}            {Suit}     |\n\n|                           |\n\n|     {Suit}             {Suit}    |\n\n|                     {card_value}   |\n\n __   __   __   __   __   \n";
                case "Seven":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                       |\n\n|     {Suit}            {Suit}     |\n\n|           {Suit}              |\n\n|     {Suit}            {Suit}     |\n\n|                           |\n\n|     {Suit}             {Suit}    |\n\n|                     {card_value}    |\n\n __   __   __   __   __   \n";
                case "Eight":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                       |\n\n|     {Suit}            {Suit}      |\n\n|           {Suit}               |\n\n|     {Suit}            {Suit}      |\n\n|           {Suit}               |\n\n|     {Suit}             {Suit}     |\n\n|                     {card_value}     |\n\n  __   __   __   __   __   \n";
                case "Nine":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|     {Suit}            {Suit}     |\n\n|           {Suit}              |\n\n|     {Suit}      {Suit}       {Suit}   |\n\n|           {Suit}              |\n\n|     {Suit}             {Suit}    |\n\n|                     {card_value}    |\n\n __   __   __   __   __   \n";
                case "Ten":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|     {Suit}      {Suit}       {Suit}    |\n\n|           {Suit}               |\n\n|     {Suit}            {Suit}       |\n\n|           {Suit}               |\n\n|     {Suit}      {Suit}        {Suit}   |\n\n|                     {card_value}    |\n\n __   __   __   __   __   \n";
                case "Jack":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|            {Suit}             |\n\n|        _____            |\n\n|             |             |\n\n|             |             |\n\n|          (__/            |\n\n|                     {card_value}   |\n\n__   __   __   __   __   \n";
                case "Queen":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|                            |\n\n|    / \\ / \\ / \\ / \\     |\n\n|    \\      {Suit}      /      |\n\n|       - - - - -         |\n\n|                           |\n\n|                     {card_value}  |\n\n  __   __   __   __   __   \n";
                case "King":
                    return $"__ __   __   __   __   __\n\n|   {card_value}                      |\n\n|           _               |\n\n|          /   \\            |\n    / \\  /     \\  / \\      \n|                          |\n    |       {Suit}          |\n|                         |\n    \\ _   _ _   _  /        \n|                          |\n\n|                   {card_value}    |\n\n __   __   __   __   __   \n";
            }
            return "ERROR";
        }
    }

	public class DeckofCards
	{
		private readonly string[] face = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
		private readonly string[] suit = { "♥", "◆", "♣", "♠" };
		private List<Card> cards;

        public DeckofCards()
		{
			this.cards = new List<Card>();
			FillDeck();
			Shuffle();
		}

		private void FillDeck()
		{
			// The card list gets filled with 52 cards
			var rand = new Random();
			for (int i=0; i<52; i++)
			{
				var card = new Card();
				card.Face = face[i % face.Length];
				card.Suit = suit[i % suit.Length];
				cards.Add(card);
			}
		}

		private void Shuffle()
		{
            // Using the Fisher-Yates Shuffling Algorithm, the cards are shuffled into randomized order
            int j = 0;
			var rand = new Random();
		
			for (int i=cards.Count-1; i>=0; i--) 
			{
				j = rand.Next() % (i + 1);
				var temp = cards[i];
				cards.RemoveAt(i);
				cards.Insert(j, temp);
			}
		}

		public Card GetCard()
		{
			Card temp = cards.First();
			cards.RemoveAt(0);
			return temp;
		}
		public void RestartGame()
		{
			cards.Clear();
			FillDeck();
			Shuffle();
		}


		
	}
}



