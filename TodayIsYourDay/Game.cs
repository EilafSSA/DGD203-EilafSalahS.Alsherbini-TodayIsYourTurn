using System;
using System.Collections.Generic;

namespace GameProject
{
    public static class Game
    {
        private static (int X, int Y) playerPosition = (0, 0);
        private static List<Location> map = new List<Location>();
        private static Dictionary<(int, int), NPC> npcs = new Dictionary<(int, int), NPC>();

        public static void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("Starting a new game...");
            map = Map.LoadMap("mapdata.txt");
            npcs = Map.LoadNPCs("npcs.txt");
            playerPosition = (0, 0);
            GameLoop();
        }

        public static void LoadGame()
        {
            Console.Clear();
            playerPosition = SaveSystem.LoadGame();
            map = Map.LoadMap("mapdata.txt");
            npcs = Map.LoadNPCs("npcs.txt");
            Console.WriteLine($"Game Loaded! You are at ({playerPosition.X}, {playerPosition.Y}).");
            GameLoop();
        }

        private static void GameLoop()
        {
            Console.WriteLine("Use W/A/S/D to move. Type 'describe' for location info, 'talk' to speak with NPCs, 'save' to save, or 'exit' to quit.");

            while (true)
            {
                Console.Write($"\nYou are at ({playerPosition.X}, {playerPosition.Y}). Enter command: ");
                string input = Console.ReadLine().ToLower();

                if (input == "exit") return;
                if (input == "save") { SaveSystem.SaveGame(playerPosition); continue; }
                if (input == "describe") { DescribeLocation(); continue; }
                if (input == "talk") { TalkToNPC(); continue; }

                switch (input)
                {
                    case "w": Move(0, -1); break;
                    case "s": Move(0, 1); break;
                    case "a": Move(-1, 0); break;
                    case "d": Move(1, 0); break;
                    default: Console.WriteLine("Invalid command! Use W/A/S/D, 'describe', 'talk', 'save', or 'exit'."); break;
                }
            }
        }

        private static void Move(int dx, int dy)
        {
            int newX = playerPosition.X + dx;
            int newY = playerPosition.Y + dy;

            Location location = map.Find(l => l.X == newX && l.Y == newY);

            if (location == null)
            {
                Console.WriteLine("You cannot move there. It's empty space.");
            }
            else if (!location.Accessible)
            {
                Console.WriteLine($"You hit a wall: {location.Name}. {location.Dialogue}");
            }
            else
            {
                playerPosition = (newX, newY);
                Console.WriteLine($"You moved to {location.Name}. {location.Dialogue}");
            }
        }

        private static void DescribeLocation()
        {
            Location location = map.Find(l => l.X == playerPosition.X && l.Y == playerPosition.Y);
            if (location != null)
            {
                Console.WriteLine($"Location: {location.Name}");
                Console.WriteLine($"Description: {location.Description}");
            }
            else
            {
                Console.WriteLine("There's nothing notable here.");
            }
        }

        private static void TalkToNPC()
        {
            if (npcs.TryGetValue(playerPosition, out NPC npc))
            {
                Console.WriteLine($"{npc.Name} says: \"{npc.Dialogue}\"");
            }
            else
            {
                Console.WriteLine("There is no one here to talk to.");
            }
        }
    }
}

