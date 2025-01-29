using System;
using System.IO;

namespace GameProject
{
    public static class SaveSystem
    {
        private static string saveFilePath = "savegame.txt";

        public static void SaveGame((int X, int Y) position)
        {
            File.WriteAllLines(saveFilePath, new string[] { position.X.ToString(), position.Y.ToString() });
            Console.WriteLine("Game Saved!");
        }

        public static (int X, int Y) LoadGame()
        {
            if (File.Exists(saveFilePath))
            {
                string[] lines = File.ReadAllLines(saveFilePath);
                return (int.Parse(lines[0]), int.Parse(lines[1]));
            }
            return (0, 0);
        }
    }
}
