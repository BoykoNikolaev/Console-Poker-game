using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(65, 40);
            Console.BackgroundColor = ConsoleColor.Gray;

            //remove scroll bars (buffer-a se naglasq s razmerite na prozoreca na konzolata
            Console.BufferWidth = 65;
            Console.BufferHeight = 40;
            Console.Title = "Poker Game";
            DealCards game = new DealCards();

            bool quit = false;
            while (!quit)
            {
                game.Deal();
                char selection = ' ';

                while(!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.SetCursorPosition(0, 27);
                    Console.WriteLine("Play Again? Y/N");
                    selection = char.Parse(Console.ReadLine().ToUpper());
                    if(selection == 'N')
                    {
                        quit = true;
                    }
                    else if(selection == 'Y')
                    {
                        quit = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }

                }
            }


            
            


            
        }
    }
}
