using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DeckOfCards : Card
    {
        const int NUM_OF_CARDS = 52;
        private Card[] deck;  //array of all playing cards

        public DeckOfCards()
        {
            deck = new Card[NUM_OF_CARDS];
        }

        public Card[] GetDeck { get { return deck; } }  //get current deck


        //create deck of 52 cards, 13 values with each 4 suits
        public void setUpDeck()
        {
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }
            shuffleCards();
        }
        //shuffle the deck
        public void shuffleCards()
        {
            Random sluchaino = new Random();
            Card temp;

            //razmesva 1000 pyti
            for(int shuffletimes = 0; shuffletimes <1000; shuffletimes++)
            {
                for(int i = 0; i < NUM_OF_CARDS; i++)
                {
                    //swap the cards
                    int secondCardIndex = sluchaino.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;

                }
            }
        }
        
        

    }
}
