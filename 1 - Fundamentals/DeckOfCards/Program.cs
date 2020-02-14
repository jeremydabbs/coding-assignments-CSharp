using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Card
    {
        public string StringVal;
        public string Suit;
        public int Val;
        public Card(string face, string suit, int val)
        {
            StringVal = face;
            Suit = suit;
            Val = val;
        }
    }
    public class Deck
    {
        public string[] suits = { "Diamonds", "Hearts", "Clubs", "Spades"};
        public string[] stringVals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        
        public List<Card> cards = new List<Card>();
        
        public Deck()
        {
            
        }
        public Deal()
        {

        }
        public Shuffle()
        {

        }
        public Reset()
        {

        }
    }
    public class Player
    {
        public string Name;
        public List<Card> Hand = new List<Card>();
        public Draw()
        {

        }
        public Discard()
        {

        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
