using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DealCards : DeckOfCards
    {
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
            sortedComputerHand = new Card[5];
        }

        public void Deal()
        {
            setUpDeck();  //syzdava testeto i go razmesva
            getHand();
            sortCards();
            DisplayCards();
            evaluateHands();
        }
        public void getHand()
        {
            //5 karti za playerHand
            for(int i = 0; i <5; i++)
            {
                playerHand[i] = GetDeck[i];
            }

            //5 karti za computerHand     i e ravno na 5, za da dade sledvashtite 5 karti sled gorniq for loop
            for(int i = 5; i < 10; i++)
            {
                computerHand[i-5] = GetDeck[i];
            }
        }

        //podrejda kartite v dvete ryce
        public void sortCards()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.MyValue
                              select hand;

            var queryComputer = from hand in computerHand
                                orderby hand.MyValue
                                select hand;

            var index = 0;
            foreach(var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            index = 0;
            foreach(var element in queryComputer.ToList())
            {
                sortedComputerHand[index] = element;
                index++;
            }
        }

        //pokazva kartite na konzolata
        public void DisplayCards()
        {
            Console.Clear();   
            int x = 0;    //x poziciqta na kursora, mastim na lqvo i dqsno
            int y = 1;    //y poziciqta na kursora, mestim nagore i nadolu

            //player hand
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("PLAYER'S HAND");
            for (int i = 0;i< sortedPlayerHand.Length; i++)
            {
                DrawCard.DrawCardOutline(x, y);
                DrawCard.DrawCardSuitAndValue(sortedPlayerHand[i], x, y);
                x++;

            }
            y = 14;   //kartata e visoka 10 i za tova  mestim kursora s 14
            x = 0;    //restartirame poziciqta lqvo/dqsno, za da pechata ot nachaloto s novite y koordinati

            //computer hand
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("COMPUTER'S HAND");
            y = 15;
            for(int i = 0; i< sortedComputerHand.Length; i++)
            {
                DrawCard.DrawCardOutline(x, y);
                DrawCard.DrawCardSuitAndValue(sortedComputerHand[i], x, y);
                x++;
            }
        }
        public void evaluateHands()
        {
            //create player's and computer's evaluation objects;(podavame podredenata ryka na konstructora)
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            HandEvaluator computerHandEvaluator = new HandEvaluator(sortedComputerHand);

            //get the player and computer hands
            Hand playerHand = playerHandEvaluator.EvaluateHand();
            Hand computerHand = computerHandEvaluator.EvaluateHand();

            //display the hands
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("Your hand: " + playerHand);
            Console.WriteLine("\n");
            Console.WriteLine("Computer's hand: " + computerHand);

            //pokazva pobeditelq
            if(playerHand > computerHand)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("YOU WIN!!!");
            }
            else if(computerHand > playerHand)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("COMPUTER WINS.");
            }
            else  //ako rycete sa ednakvi
            {
                //pyrvo proverqva ako imat ednakvi kombinacii
                if(playerHandEvaluator.Handvalues.Total > computerHandEvaluator.Handvalues.Total)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YOU WIN!!!");
                }
                else if(playerHandEvaluator.Handvalues.Total < computerHandEvaluator.Handvalues.Total)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("COMPUTER WINS.");
                }
                //ako i se stigne do visoka karta
                else if(playerHandEvaluator.Handvalues.HighCard > computerHandEvaluator.Handvalues.HighCard)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YOU WIN!!!");
                }
                else if(playerHandEvaluator.Handvalues.HighCard < computerHandEvaluator.Handvalues.HighCard)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("COMPUTER WINS.");
                }
                else
                {
                    Console.WriteLine("DRAW! No one wins.");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
