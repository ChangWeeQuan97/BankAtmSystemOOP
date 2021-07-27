using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int player_handvalue=0,dealer_handvalue = 0;
            while (true)
            {
                string hit = "HIT", stand = "STAND";
                string yes = "Y", no = "N";
                
                Deck deck = new Deck();
                deck.CreateDeck();
                
                
                other_method.yellow_text("       Welcome to BlackJack Game", "\nPlease enter your name: ");
                Player player = new Player(Console.ReadLine());
                Console.WriteLine(deck.deck.Count() + " Card");
                deck.Shuffle();
                Console.WriteLine("Shuffling....");
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine($"{player.Name}'s Hand Card");
                player.PlayerHand.Add(deck.DealCard());
                player.PlayerHand.Add(deck.DealCard());
                Thread.Sleep(1000);
                Player.PrintPlayerHand(player);
                player_handvalue = Player.CalculatePlayerValue(player);
                Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");
                //Player.Print_Card_And_Handvalue(player, player_handvalue);

                Player dealer = new Player("Dealer");
                Console.WriteLine($"{dealer.Name}'s Hand Card");
                dealer.PlayerHand.Add(deck.DealCard());
                //Player.PrintPlayerHand(dealer);
                dealer.PlayerHand.Add(deck.DealCard());
                dealer.PlayerHand[0].Printcard();
                other_method.red_text("<Hidden Card>");
                Thread.Sleep(1000);
                dealer_handvalue = Player.CalculatePlayerValue(dealer);
                Console.WriteLine($"{dealer.Name} Hand Value is Unknown");

                if (player_handvalue == 21)
                {
                    Console.WriteLine($"{player.Name} got BLACKJACK, {player.Name} won");
                }
                else if (dealer_handvalue == 21)
                {
                    Player.PrintPlayerHand(dealer);
                    player_handvalue = Player.CalculatePlayerValue(dealer);
                    Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                    Console.WriteLine($"{dealer.Name} got BLACKJACK, {dealer.Name} won");
                }
                else if (dealer_handvalue == 21 && player_handvalue == 21)
                {
                    Player.PrintPlayerHand(dealer);
                    player_handvalue = Player.CalculatePlayerValue(dealer);
                    Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                    Console.WriteLine($"{player.Name} and {dealer.Name} are both got BLACKJACK");
                    Console.WriteLine("This match is draw.");
                }
                else if (player_handvalue < 16)
                {
                    while (true)
                    {
                        Console.WriteLine("Minimum card value is 16, Please type HIT to get a card.");
                        string opt = Console.ReadLine();
                        if (opt != hit.ToLower())
                        {
                            Console.WriteLine($"Please select {hit} or {stand} ");
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                player.PlayerHand.Add(deck.DealCard());
                                Player.Print_PlayerHand(player);
                                player_handvalue = Player.Calculate(player);
                                Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");

                                //Player.Printing_Card_And_Handvalue(player,player_handvalue,deck);
                                Thread.Sleep(1000);
                                if (player_handvalue >= 16 && player_handvalue <= 21)
                                {
                                    break;
                                }
                                else if (player_handvalue > 21)
                                {
                                    break;
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        Console.WriteLine($"{player.Name} WON cause of Five Card Charlie");
                                        break;
                                    }
                                }
                            }
                            if (player_handvalue >= 16 && player_handvalue <= 21 && player.PlayerHand.Count() > 4)
                            {
                                break;
                            }
                            else if (player_handvalue >= 16 && player_handvalue <= 21)
                            {
                                Console.WriteLine($"{hit} or {stand}");
                                string hit_stand = Console.ReadLine();

                                if (hit_stand == stand.ToLower())
                                {
                                    if (dealer_handvalue < 16)
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            dealer.PlayerHand.Add(deck.DealCard());
                                            Player.Print_PlayerHand(dealer);
                                            dealer_handvalue = Player.Calculate(dealer);
                                            Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");

                                            //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                            Thread.Sleep(1000);
                                            if (dealer_handvalue > 21)
                                            {
                                                break;
                                            }
                                            else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (i > 1)
                                                {
                                                    Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                    break;
                                                }
                                            }
                                        }
                                        if (dealer_handvalue >= 16 && dealer_handvalue <= 21 && dealer.PlayerHand.Count() > 4)
                                        {
                                            break;
                                        }
                                        if (dealer_handvalue > 21)
                                        {
                                            Console.WriteLine($"{dealer.Name} busted, {player.Name} won");
                                            break;
                                        }
                                        else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                        {
                                            if (dealer_handvalue > player_handvalue)
                                            {
                                                Console.WriteLine($"{dealer.Name} won");
                                                break;
                                            }
                                            else if (dealer_handvalue == player_handvalue)
                                            {
                                                Console.WriteLine("This match is draw.");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{player.Name} won");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (dealer_handvalue>=16 && dealer_handvalue<=21)
                                        {
                                            Player.PrintPlayerHand(dealer);
                                            dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                            Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                            //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);
                                            if (dealer_handvalue > player_handvalue)
                                            {
                                                Console.WriteLine($"{dealer.Name} won");
                                                break;
                                            }
                                            else if (dealer_handvalue == player_handvalue)
                                            {
                                                Console.WriteLine("This match is draw.");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{player.Name} won");
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    player.PlayerHand.Add(deck.DealCard());
                                    Player.Print_PlayerHand(player);
                                    player_handvalue = Player.Calculate(player);
                                    Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");
                                    //Player.Printing_Card_And_Handvalue(player,player_handvalue,deck);

                                    if (player_handvalue > 21)
                                    {
                                        if (dealer_handvalue < 16)
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                dealer.PlayerHand.Add(deck.DealCard());
                                                Player.Print_PlayerHand(dealer);
                                                dealer_handvalue = Player.Calculate(dealer);
                                                Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                                //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                                Thread.Sleep(1000);
                                                if (dealer_handvalue > 21)
                                                {
                                                    break;
                                                }
                                                else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    if (i > 1)
                                                    {
                                                        Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                        break;
                                                    }
                                                }
                                            }
                                            if (dealer_handvalue >= 16 && dealer_handvalue <= 21 && dealer.PlayerHand.Count() > 4)
                                            {
                                                break;
                                            }
                                            if (dealer_handvalue > 21)
                                            {
                                                Console.WriteLine($"{player.Name} and {dealer.Name} are both busted");
                                                Console.WriteLine("This match is draw.");
                                                break;
                                            }
                                            else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                            {
                                                Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                                break;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Player.PrintPlayerHand(dealer);
                                            dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                            Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                            //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);
                                            Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{hit} or {stand}");
                                        hit_stand = Console.ReadLine();

                                        if (hit_stand == stand.ToLower())
                                        {
                                            if (dealer_handvalue < 16)
                                            {
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    dealer.PlayerHand.Add(deck.DealCard());
                                                    Player.Print_PlayerHand(dealer);
                                                    dealer_handvalue = Player.Calculate(dealer);
                                                    Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");

                                                    //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                                    Thread.Sleep(1000);
                                                    if (dealer_handvalue > 21)
                                                    {
                                                        break;
                                                    }
                                                    else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (i > 1)
                                                        {
                                                            Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (dealer_handvalue >= 16 && dealer_handvalue <= 21 && dealer.PlayerHand.Count() > 4)
                                                {
                                                    break;
                                                }
                                                if (dealer_handvalue > 21)
                                                {
                                                    Console.WriteLine($"{dealer.Name} busted, {player.Name} won");
                                                    break;
                                                }
                                                else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                                {
                                                    if (dealer_handvalue > player_handvalue)
                                                    {
                                                        Console.WriteLine($"{dealer.Name} won");
                                                        break;
                                                    }
                                                    else if (dealer_handvalue == player_handvalue)
                                                    {
                                                        Console.WriteLine("This match is draw.");
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"{player.Name} won");
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Player.PrintPlayerHand(dealer);
                                                dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                                Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                                //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);
                                                if (dealer_handvalue > player_handvalue)
                                                {
                                                    Console.WriteLine($"{dealer.Name} won");
                                                    break;
                                                }
                                                else if (dealer_handvalue == player_handvalue)
                                                {
                                                    Console.WriteLine("This match is draw.");
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"{player.Name} won");
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            player.PlayerHand.Add(deck.DealCard());
                                            Player.Print_PlayerHand(player);
                                            player_handvalue = Player.Calculate(player);
                                            Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");
                                            //Player.Printing_Card_And_Handvalue(player,player_handvalue,deck);

                                            if (player_handvalue > 21)
                                            {
                                                if (dealer_handvalue < 16)
                                                {
                                                    for (int i = 0; i < 3; i++)
                                                    {
                                                        dealer.PlayerHand.Add(deck.DealCard());
                                                        Player.Print_PlayerHand(dealer);
                                                        dealer_handvalue = Player.Calculate(dealer);
                                                        Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                                        //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                                        Thread.Sleep(1000);
                                                        if (dealer_handvalue > 21)
                                                        {
                                                            break;
                                                        }
                                                        else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            if (i > 1)
                                                            {
                                                                Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    if (dealer_handvalue >= 16 && dealer_handvalue <= 21 && dealer.PlayerHand.Count() > 4)
                                                    {
                                                        break;
                                                    }
                                                    if (dealer_handvalue > 21)
                                                    {
                                                        Console.WriteLine($"{player.Name} and {dealer.Name} are both busted");
                                                        Console.WriteLine("This match is draw.");
                                                        break;
                                                    }
                                                    else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                                    {
                                                        Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    Player.PrintPlayerHand(dealer);
                                                    dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                                    Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                                    //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);
                                                    Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{player.Name} WON cause of Five Card Charlie");
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (player_handvalue > 21)
                            {
                                if (dealer_handvalue < 16)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        dealer.PlayerHand.Add(deck.DealCard());
                                        Player.Print_PlayerHand(dealer);
                                        dealer_handvalue = Player.Calculate(dealer);
                                        Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                        //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                        Thread.Sleep(1000);
                                        if (dealer_handvalue > 21)
                                        {
                                            break;
                                        }
                                        else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            if (i > 1)
                                            {
                                                Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                break;
                                            }
                                        }
                                    }
                                    if (dealer_handvalue >= 16 && dealer_handvalue <= 21 && dealer.PlayerHand.Count() > 4)
                                    {
                                        break;
                                    }
                                    else if (dealer_handvalue > 21)
                                    {
                                        Console.WriteLine($"{player.Name} and {dealer.Name} are both busted");
                                        Console.WriteLine("This match is draw.");
                                        break;
                                    }
                                    else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                    {
                                        Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if(dealer_handvalue >16 ) 
                                    {
                                        Player.PrintPlayerHand(dealer);
                                        dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                        Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                        //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);
                                        Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine($"{hit} or {stand}");
                        string opt = Console.ReadLine();

                        if (opt == hit.ToLower())
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                player.PlayerHand.Add(deck.DealCard());
                                Player.Print_PlayerHand(player);
                                player_handvalue = Player.Calculate(player);
                                Console.WriteLine($"{player.Name} Hand Value is {player_handvalue}");
                                //Player.Printing_Card_And_Handvalue(player, player_handvalue, deck);
                                Thread.Sleep(1000);
                                if (player_handvalue > 21)
                                {
                                    break;
                                }
                                else if (player_handvalue >= 16 && player_handvalue <= 21)
                                {
                                    break;
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        Console.WriteLine($"{player.Name} WON cause of Five Card Charlie");
                                        break;
                                    }
                                }
                            }
                            if(player_handvalue >= 16 && player_handvalue <= 21 && player.PlayerHand.Count() > 4)
                            {
                                break;
                            }
                            if (player_handvalue > 21)
                            {
                                if (dealer_handvalue < 16)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        dealer.PlayerHand.Add(deck.DealCard());
                                        Player.Print_PlayerHand(dealer);
                                        dealer_handvalue = Player.Calculate(dealer);
                                        Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                        //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                        Thread.Sleep(1000);
                                        if (dealer_handvalue > 21)
                                        {
                                            break;
                                        }
                                        else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            if (i > 1)
                                            {
                                                Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                break;
                                            }
                                        }
                                    }
                                    if (dealer_handvalue > 21)
                                    {
                                        Console.WriteLine($"{player.Name} and {dealer.Name} are both busted");
                                        Console.WriteLine("This match is draw.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                        break;
                                    }
                                }
                                else
                                {
                                    Player.PrintPlayerHand(dealer);
                                    dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                    Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                    //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);
                                    Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
                                    break;
                                }
                            }
                            else if(player_handvalue >= 16 && player_handvalue <= 21)
                            {
                                Console.WriteLine($"{hit} or {stand}");
                                string hit_stand = Console.ReadLine();

                                if (hit_stand == stand.ToLower())
                                {
                                    if (dealer_handvalue < 16)
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            dealer.PlayerHand.Add(deck.DealCard());
                                            Player.Print_PlayerHand(dealer);
                                            dealer_handvalue = Player.Calculate(dealer);
                                            Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                            //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                            Thread.Sleep(1000);
                                            if (dealer_handvalue > 21)
                                            {
                                                break;
                                            }
                                            else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (i > 1)
                                                {
                                                    Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                                    break;
                                                }
                                            }
                                        }
                                        if (dealer_handvalue > 21)
                                        {
                                            Console.WriteLine($"{dealer.Name} busted, {player.Name} won");
                                            break;
                                        }
                                        else
                                        {
                                            if (dealer_handvalue == player_handvalue)
                                            {
                                                Console.WriteLine("This match is draw.");
                                                break;
                                            }
                                            else if (dealer_handvalue > player_handvalue)
                                            {
                                                Console.WriteLine($"{dealer.Name} won");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{player.Name} won");
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Player.PrintPlayerHand(dealer);
                                        dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                        Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                        //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);

                                        if (player_handvalue == dealer_handvalue)
                                        {
                                            Console.WriteLine("This match is draw.");
                                            break;
                                        }
                                        else if (player_handvalue > dealer_handvalue)
                                        {
                                            Console.WriteLine($"{player.Name} won");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{dealer.Name} won");
                                            break;
                                        }
                                    }
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (opt == stand.ToLower())
                        {
                            if (dealer_handvalue < 16)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    dealer.PlayerHand.Add(deck.DealCard());
                                    Player.Print_PlayerHand(dealer);
                                    dealer_handvalue = Player.Calculate(dealer);
                                    Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                    //Player.Printing_Card_AndHandvalue(dealer, dealer_handvalue, deck);
                                    Thread.Sleep(1000);
                                    if (dealer_handvalue > 21)
                                    {
                                        break;
                                    }
                                    else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (i > 1)
                                        {
                                            Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
                                            break;
                                        }
                                    }
                                }
                                if (dealer_handvalue >= 16 && dealer_handvalue <= 21 && dealer.PlayerHand.Count() > 4)
                                {
                                    break;
                                }
                                else if (dealer_handvalue > 21)
                                {
                                    Console.WriteLine($"{dealer.Name} busted, {player.Name} won");
                                    break;
                                }
                                else if (dealer_handvalue >= 16 && dealer_handvalue <= 21)
                                {
                                    if (dealer_handvalue == player_handvalue)
                                    {
                                        Console.WriteLine("This match is draw.");
                                        break;
                                    }
                                    else if (dealer_handvalue > player_handvalue)
                                    {
                                        Console.WriteLine($"{dealer.Name} won");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{player.Name} won");
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Player.PrintPlayerHand(dealer);
                                dealer_handvalue = Player.CalculatePlayerValue(dealer);
                                Console.WriteLine($"{dealer.Name} Hand Value is {dealer_handvalue}");
                                //Player.Print_Card_AndHandvalue(dealer, dealer_handvalue);

                                if (player_handvalue == dealer_handvalue)
                                {
                                    Console.WriteLine("This match is draw.");
                                    break;
                                }
                                else if (player_handvalue > dealer_handvalue)
                                {
                                    Console.WriteLine($"{player.Name} won");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{dealer.Name} won");
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Do you want to play again? (Y/N)");
                string yn = Console.ReadLine();

                if (yn == yes.ToLower())
                {
                    Console.Clear();

                }
                else if (yn == no.ToLower())
                {
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
