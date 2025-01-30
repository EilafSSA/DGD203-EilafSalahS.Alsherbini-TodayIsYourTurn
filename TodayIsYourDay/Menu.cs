using System;

namespace TodayIsYourDay
{
    public static class Menu
    {
        public static void Starting_Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
        ___  _____ __  __   __ __   __  _   __  __   __ __  _  _ ___   _____ _  _ ___ __  _  ___ 
        |// |_   _/__\| _\ /  \\ `v' / | |/' _/ \ `v' //__\| || | _ \ |_   _| || | _ \  \| | |// 
              | || \/ | v | /\ |`. .'  | |`._`.  `. .'| \/ | \/ | v /   | | | \/ | v / | ' |     
              |_| \__/|__/|_||_| !_!   |_||___/   !_!  \__/ \__/|_|_\   |_|  \__/|_|_\_|\__|     
                  
                  ");

                Console.WriteLine(@"       
                
                1. New Game
                
                2. Load Save
                
                3. Credits!
                
                0. No it isn't (Exit)");

                string picked = Console.ReadLine();
                switch (picked)
                {
                    case "1":
                        Game.StartNewGame();
                        break;
                    case "2":
                        Game.LoadGame();
                        break;
                    case "3":
                        ShowCredits();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Pick between 1, 2, or 0.");
                        break;
                }
            }
        }

        private static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine(@"
            Credits: Developed by Eilaf Salah S. Alsherbini
            ");
            Console.WriteLine("ASCII TEXT from https://patorjk.com/software/taag/");
            Starting_Menu();
        }
    }
}
