using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Card
    {
       public string vals;
       public string suits;
       public int numerical_value;
       public Card(string val, string suit, int num_value){
           vals = val;
           suits = suit;
           numerical_value = num_value;
       }
    }//end of card class
    public class Deck
    {  
        public List<Card> deck = new List<Card>(); 
        public string[] face = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        public string[] suit = {"Clubs", "Spades", "Hearts", "Diamonds"};
        public Deck(){
            makeDeck();
        }
        public void makeDeck(){
            for (int i = 0; i < suit.Length; i++){
                for (int j = 0; j < face.Length; j++){
                    deck.Add(new Card(face[j], suit[i], j +1));
                } 
            }
        }
        public void printCards(){
            foreach(Card card in this.deck){
                System.Console.WriteLine("Card: " + card.vals + " of " + card.suits + " = " + card.numerical_value );
            } 
        }
        public void shuffle(){
            Random rnd = new Random();
            int n = deck.Count;
            while (n > 1){
                int k = rnd.Next(n--);
                Card temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }
        public Card deal(){
            Card tCard = deck[0];
            deck.RemoveAt(0);
            // System.Console.WriteLine(tCard.vals + " of " + tCard.suits);
            return tCard;
        }
        public void reset(){
            deck.Clear();
            makeDeck();
        }   
    }//end of Deck class
    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public Player(string pName){
            name = pName;
        }
        public void draw(Deck deck1){
          Card newCard = deck1.deal();
          hand.Add(newCard);
        }
        public void showHand(){
            foreach(Card card in this.hand){
                System.Console.WriteLine(card.vals + " of " + card.suits);
            } 
        }
        public bool Discard(Card card){
            if(hand.Contains(card)){
                hand.Remove(card);
                System.Console.WriteLine(card.vals + " of " + card.suits);
                return true;
            }
            return false;    
        }
        public Card cardToDiscard(){
            System.Console.WriteLine("this is the card to be discarded " + hand[0].vals + " of " + hand[0].suits);
            return hand[0];
        }       
    }//end of Player class
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck myDeck = new Deck();
            Player player1 = new Player("Fred");
            System.Console.WriteLine(player1.name);
            myDeck.shuffle();
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.showHand();
            player1.Discard(player1.cardToDiscard());
            System.Console.WriteLine("*********************************");
            player1.showHand();
            myDeck.printCards();
            System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            myDeck.reset();
            myDeck.printCards();
            System.Console.WriteLine("``````````````````````````````````````````");
            myDeck.reset();
            myDeck.printCards();
        }
    }
}
