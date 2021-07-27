using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAssignment
{
    class Card
    {
        public Suit suit { get; set; }
        public Face face { get; set; }
        public int facevalue { get; set; }


        public Card(Suit suit, Face face)
        {
            this.suit = suit;
            this.face = face;

            switch (face)
            {
                case Face.Two:
                    facevalue = 2;
                    break;
                case Face.Three:
                    facevalue = 3;
                    break;
                case Face.Four:
                    facevalue = 4;
                    break;
                case Face.Five:
                    facevalue = 5;
                    break;
                case Face.Six:
                    facevalue = 6;
                    break;
                case Face.Seven:
                    facevalue = 7;
                    break;
                case Face.Eight:
                    facevalue = 8;
                    break;
                case Face.Nine:
                    facevalue = 9;
                    break;
                case Face.Ten:
                case Face.Jack:
                case Face.Queen:
                case Face.King:
                    facevalue = 10;
                    break;
                case Face.Ace:
                    facevalue = 11;
                    break;
            }
        }

        public void Printcard()
        {
            //Console.WriteLine($"{suit} {face} {facevalue}");
            Console.WriteLine($"{suit} {face}");
        }
    }
    public enum Suit
    {
        Spade, Heart, Club, Diamond
    }
   


    public enum Face
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
}
