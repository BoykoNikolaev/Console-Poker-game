using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DrawCard
    {
        


        //draw cards outlines
        public static void DrawCardOutline(int xCoordinate, int yCoordinate) 
        {
            Console.ForegroundColor = ConsoleColor.White;

            int x = xCoordinate * 12;
            int y = yCoordinate;
            Console.SetCursorPosition(x, y);
            Console.Write(" __________\n");   //goren krai na kartata
 
            for(int i = 0;i<10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if(i != 9)
                {
                    Console.WriteLine("|          |");  //lqva i dqsna strana na kartata
                }
                else
                {
                    Console.WriteLine("|__________|");  //dolen krai na kartata
                }
            }
            

        }
        
        //risuva boqta i stoinostta na kartata(primer ACE OF SPADES)
        public static void DrawCardSuitAndValue(Card card, int xCoordinate, int yCoordinate)
        {
            string cardSuit = "";
            int x = xCoordinate * 12;
            int y = yCoordinate;

            //HEARTS i DIAMONDS sa cherveni, CLUBS i SPADES sa cherni
            switch (card.MySuit) 
            {
                case Card.SUIT.HEARTS:
                    cardSuit = "\u2665";
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.DIAMONDS:
                    cardSuit = "\u2666";
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.CLUBS:
                    cardSuit = "\u2663";
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Card.SUIT.SPADES:
                    cardSuit = "\u2660";
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            //display the encoded character and value of the card
            Console.SetCursorPosition(x+4, y+6);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 3, y + 8);
            Console.Write(card.MyValue);

        }

    }
}
