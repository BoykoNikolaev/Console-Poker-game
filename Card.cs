using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card
    {
        public enum SUIT 
        {
            HEARTS,
            CLUBS,
            SPADES,
            DIAMONDS
        }

        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT,
            NINE, TEN, JACK, QUEEN, KING, ACE
        }

        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }
    }
}
