using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackAssignment
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> PlayerHand { get; set; }


        public Player(string name)
        {
            Name = name;
            PlayerHand = new List<Card>();
        }

        public static void PrintPlayerHand(Player player)
        {
            foreach (var card in player.PlayerHand)
            {
                card.Printcard();
            }
        }
        public static void Print_PlayerHand(Player player)
        {
            foreach (var card in player.PlayerHand)
            {
                if (card.face == Face.Ace)
                {
                    card.facevalue = 1;
                }
                card.Printcard();
            }
        }
        public static int CalculatePlayerValue(Player player)
        {
            int handvalue = 0;
            foreach (var item in player.PlayerHand)
            {
                handvalue += item.facevalue;
            }
            return handvalue;
        }
        public static int Calculate(Player player)
        {
            int handvalue = 0;
            foreach (var item in player.PlayerHand)
            {
                if (item.face == Face.Ace)
                {
                    item.facevalue = 1;
                }
                handvalue += item.facevalue;
            }
            return handvalue;
        }
        //public static void Print_Card_And_Handvalue(Player player,int player_handvalue)
        //{
        //    PrintPlayerHand(player);
        //    player_handvalue = CalculatePlayerValue(player);
        //    Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");
        //}
        //public static void Printing_Card_And_Handvalue(Player player, int player_handvalue, Deck deck)
        //{
        //    player.PlayerHand.Add(deck.DealCard());
        //    Print_PlayerHand(player);
        //    player_handvalue = Calculate(player);
        //    Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");
        //}
        //public static void Print_Card_AndHandvalue(Player dealer, int player_handvalue)
        //{
        //    PrintPlayerHand(dealer);
        //    player_handvalue = CalculatePlayerValue(dealer);
        //    Console.WriteLine($"{dealer.Name} Hand Value is {player_handvalue}");
        //}
        //public static void Printing_Card_AndHandvalue(Player dealer, int player_handvalue, Deck deck)
        //{
        //    dealer.PlayerHand.Add(deck.DealCard());
        //    Print_PlayerHand(dealer);
        //    player_handvalue = Calculate(dealer);
        //    Console.WriteLine($"{dealer.Name} Hand Value is {player_handvalue}");
        //}


        public static int two_Ace(Player player)
        {
            int handvalue = 0;
            if (player.PlayerHand.ElementAt(0).facevalue == 11 && player.PlayerHand.ElementAt(1).facevalue == 11)
            {
                player.PlayerHand.ElementAt(0).facevalue = 11;
                player.PlayerHand.ElementAt(1).facevalue = 1;
                foreach (var item in player.PlayerHand)
                {
                    handvalue += item.facevalue;
                }
            }
            //foreach (var item in player.PlayerHand)
            //{
            //    handvalue += item.facevalue;
            //}
            //if (handvalue==22)
            //{
            //    handvalue = 12;
            //}
            return handvalue;

        }
    }
}
