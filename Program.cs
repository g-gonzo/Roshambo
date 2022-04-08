using System;


namespace Roshambo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt to user saying lets play a game...
            Console.WriteLine($"{GameLogic.TextArry[0]}");
            Console.WriteLine($"{GameLogic.TextArry[5]}");


            // While loop, running both methods...
            while (true)
            {
                GameLogic.HandGen();
                GameLogic.GetPlayersHand();
                GameLogic.CompareHands();
                Console.ReadLine();
            }

        }

    }
}

// Homework?
// Fix the space before the entry of number. (trim method?)...
// How to make the game exit? (new method with Exit Y/N?)...