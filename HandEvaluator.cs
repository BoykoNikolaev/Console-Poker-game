using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum Hand 
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind,
        StraightFlush
    }
    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }
    class HandEvaluator : Card
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadeSum;
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadeSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new HandValue();

        }

        public HandValue Handvalues 
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards 
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }
        
        public Hand EvaluateHand()
        {
            GetNumberOfSuit();
            if (StraightFlush())
                return Hand.StraightFlush;
            else if (FourOfAKind())
                return Hand.FourKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeOfAKind())
                return Hand.ThreeKind;
            else if (TwoPairs())
                return Hand.TwoPairs;
            else if (OnePair())
                return Hand.OnePair;

            //ako i dvamata nqmat nishto pecheli tozi s po-visoka karta
            handValue.Total = (int)cards[4].MyValue;
            return Hand.Nothing;
        }
        private void GetNumberOfSuit()
        {
            foreach(var element in cards)
            {
                if(element.MySuit == Card.SUIT.HEARTS)
                {
                    heartsSum++;
                }
                else if(element.MySuit == Card.SUIT.DIAMONDS)
                {
                    diamondSum++;
                }
                else if(element.MySuit == Card.SUIT.SPADES)
                {
                    spadeSum++;
                }
                else if(element.MySuit == Card.SUIT.CLUBS)
                {
                    clubSum++;
                }
            }
        }
        private bool StraightFlush()
        {
            if (heartsSum == 5 || diamondSum == 5 || spadeSum == 5 || clubSum == 5)
            {
                if (cards[0].MyValue == cards[1].MyValue + 1 &&
               cards[1].MyValue == cards[2].MyValue + 1 &&
               cards[2].MyValue == cards[3].MyValue + 1 &&
               cards[3].MyValue == cards[4].MyValue)
                {
                    //ako i dvamata imat takiva pecheli tozi s nai-visokata posledna karta
                    handValue.Total = (int)cards[4].MyValue;
                    return true;
                }
                
            }
            return false;
        }
        private bool FourOfAKind()
        {
            //if the first 4 cards, add values of the four cards and last is the highest.
            if(cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if(cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 4;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool FullHouse()
        {
            //proverqva pyrvo dali pyrvite 2 i poslednite 3 sa ednakvi
            //na else if proverqva obratnoto - dali pyrvite 3 i poslednite 2
            if(cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 2 + (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if(cards[3].MyValue == cards[4].MyValue && cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 3 + (int)cards[2].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool Flush()
        {
            //proverqva dali boite sa ednakvi
            if(heartsSum == 5 || diamondSum == 5 || spadeSum == 5 || clubSum == 5)
            {
                //ako ima flush pecheli igracha s po-visokata karta
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool Straight()
        {
            //ako sa 5 poredni karti
            if(cards[0].MyValue == cards[1].MyValue + 1 &&
               cards[1].MyValue == cards[2].MyValue + 1 &&
               cards[2].MyValue == cards[3].MyValue + 1 &&
               cards[3].MyValue == cards[4].MyValue)
            {
                //ako i dvamata imat takiva pecheli tozi s nai-visokata posledna karta
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool ThreeOfAKind()
        {
            //ako 3 karti sa ednakvi
            //po napisaniqt dolu nachin 3tata karta vinagi uchastva v kombinaciqta
            if(cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue ||
               cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if(cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }
        private bool TwoPairs()
        {
            //dali dve karti sa ednakvi*2 i nai-visoka karta v rykata
            //ako 1 i 2 && 3 i 4
            //ako 1 i 2 && 4 i 5
            //ako 2 i 3 && 4 i 5

            if(cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2 + (int)cards[3].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if(cards[0].MyValue == cards[1].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2 + (int)cards[4].MyValue * 2;
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            else if(cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 2 + (int)cards[4].MyValue * 2;
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }
        private bool OnePair()
        {
            //dali dve sa ednavki
            if(cards[0].MyValue == cards[1].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[3].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue * 2;
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            return false;
        }

    }

        


    
}
