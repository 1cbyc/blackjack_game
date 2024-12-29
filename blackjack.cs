/* By Isaac Nsisong */
/* Instagram: @NsisongLabs */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsisongLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            // number of games
            int playCount = 100;
            
            Game game = new Game();
            int wins = 0;
            for (int i = 0; i < playCount; i++)
            {
                if (game.playGame())
                {
                    wins++;
                }
            }
            Console.Write("You got " + wins + " blackjacks");
        }
    }
    public class Game
    {
        Deck deck;
        int result;
        List<Card> hand;
        int acesInHand;

        public bool playGame() {
            bool isBlackJack = false;
            acesInHand = 0;
            deck = new Deck();
            deck.shuffle();
            result = 0;
            int cardNumber = 0;
            hand = new List<Card>();

            while (result < 21) {
                if (deck.getCards().ElementAt(cardNumber).getSecondCount() > 0) {
                    acesInHand++;
                }
                hand.Add(deck.getCards().ElementAt(cardNumber));
                result = calculateResult(hand); 
                cardNumber++;
            }
            if (result == 21) {
                isBlackJack = true;
            }
            return isBlackJack;
        }

        public int calculateResult(List<Card> cards) {
            int sum = 0;
            for (int j = acesInHand; j >= 0; j--) {
                sum = 0;
                for (int i = 0; i < cards.Count; i++) {
                    int smallAcecInHand = acesInHand;
                    if (cards.ElementAt(i).getSecondCount() > 0 && smallAcecInHand > 0) {
                        sum = sum + cards.ElementAt(i).getSecondCount();
                        smallAcecInHand--;
                    }
                    else
                    {
                        sum = sum + cards.ElementAt(i).getCount();
                    }
                }
                if (sum == 21) {
                    return sum;
                }
            }
            return sum;
        }
    }

    public class Card
    {
        int secondCount = -1;
        int count;
        string name;
        int[] counts = {11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11};
        string[] names = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        
        public Card(int num) {
            this.name = names[num];
            this.count = counts[num];
        }
        public Card(int num1, int num2) {
            this.name = names[num1];
            this.count = counts[num1];
            this.secondCount = counts[num2];
        }
        public string getName() {
            return name;
        }
        public int getCount() {
            return count;
        }
        public int getSecondCount() {
            return secondCount;
        }
    }
    
    public class Deck
    {
        List<Card> cards;
        static Random rnd = new Random();
        
        public Deck() {
            cards = new List<Card>();
            for (short a = 0; a <= 3; a++) {
                for (short b = 0; b <= 12; b++) {
                    if (b == 0) {
                        cards.Add(new Card(b, 13));
                    } else {
                        cards.Add(new Card(b));
                    }
                }
            }
        }
        public void shuffle() {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
        public List<Card> getCards() {
            return cards;
        }
        public Card getCard(int i) {
            return cards.ElementAt(i);
        }
    }
}
