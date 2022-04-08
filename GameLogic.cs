using System;
using System.Collections.Generic;

namespace Roshambo
{
    public class GameLogic
    {
        // Game player variables creating class objects...
        static Player Player1 = new Player();
        static Player Player2 = new Player();

        // Array holding the text strings...
        public static string[] TextArry = new string[]
        {
            "Let's play a game of Rochambeau.", // 0
            "---------- Player 1 : Winner!",                   // 1
            "---------- Player 2 : Winner!",                   // 2
            "---------- Looks like its a tie !",              // 3
            "----- What hand do you want to play? Rock = 1, Paper = 2, Scissors = 3 ? or E to Exit Game", // 4
            "********************************************************************************************", // 5
            "Press Enter to continue..."// 6
        };

        // Method for random hand generation used for the Player 2 or (computer)...
        public static void HandGen() 
        {

            Random md = new Random();  // Called the random method, instanciated an object...

            int index = md.Next(1,4);       //  Because we added the Unknown to Enum, we changed this from Max to Min, requiring the two argumments...
            HandState computerHand = (HandState)index; // HandState is the Enum...

            Player2.CurrentHand = computerHand;

            //Console.WriteLine($"Showing Player 2's Hand (Random Computer):- {computerHand}");  // This was just for more visual during dev...

        }

        public static void GetPlayersHand()
        {
            while (Player1.CurrentHand == HandState.Unknown)
            {
                Console.Write($"{TextArry[4]}");        // Write vs WriteLine - in this case it just looks better, less confusion for user...

                string Player1Hand = Console.ReadLine();

                // Homework #1 - Added trim method to Player1Hand in each... There probably is a better way reduce this, looking into that...
                if (Player1Hand.Trim() == "1" || Player1Hand.Trim() == "2" || Player1Hand.Trim() == "3")
                {
                    Player1.CurrentHand = (HandState)int.Parse(Player1Hand);  // Player1Hand is a string, needed to convert to int, HandState is an Enum, int code Jiu-Jitsu...
                }                                                             // this is very consise compared to original if else maze....
                else if (Player1Hand.Trim() == "E" || Player1Hand.Trim() == "e")
                {
                    ExitGame();
                }
                else if (Player1Hand == "")
                {
                    Console.WriteLine("Oops use a 1, 2 or 3, or E to Exit Game");
                }

                Console.WriteLine($"Player 1's - Hand is : {Player1.CurrentHand}");
                Console.WriteLine($"Player 2's - Hand is : {Player2.CurrentHand}");
                Console.WriteLine($"{TextArry[5]}");
            }

        }

        public static void CompareHands()  
        {

            if (Player1.CurrentHand == Player2.CurrentHand)
            {
                Console.WriteLine($"{TextArry[3]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else if (Player1.CurrentHand == HandState.Paper && Player2.CurrentHand == HandState.Rock) // Player1 wins
            {
                Console.WriteLine($"{TextArry[1]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else if (Player1.CurrentHand == HandState.Scissors && Player2.CurrentHand == HandState.Paper) // Player1 wins
            {
                Console.WriteLine($"{TextArry[1]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else if (Player1.CurrentHand == HandState.Rock && Player2.CurrentHand == HandState.Scissors) // Player1 wins
            {
                Console.WriteLine($"{TextArry[1]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else if (Player1.CurrentHand == HandState.Rock && Player2.CurrentHand == HandState.Paper) // Player2 wins
            {
                Console.WriteLine($"{TextArry[2]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else if (Player1.CurrentHand == HandState.Paper && Player2.CurrentHand == HandState.Scissors) // Player2 wins
            {
                Console.WriteLine($"{TextArry[2]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else if (Player1.CurrentHand == HandState.Scissors && Player2.CurrentHand == HandState.Rock) // Player2 wins
            {
                Console.WriteLine($"{TextArry[2]}");
                Console.WriteLine($"{TextArry[6]}");
            }
            else
            {
                Console.WriteLine("Not sure who won this one...");
                Console.WriteLine($"{TextArry[6]}");
            }

            Reset(); // Could also be placed in Program.cs and called from there...
        }

        public static void Reset()
        {
            Player1.CurrentHand = HandState.Unknown;
            Player2.CurrentHand = HandState.Unknown;
        }

        public static void ExitGame()
        {
            Environment.Exit(-1);
        }

    }
}
