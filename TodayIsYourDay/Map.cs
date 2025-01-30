using System;
using System.Collections.Generic;
using System.IO;

namespace TodayIsYourDay
{
    public static class Map
    {
        public static List<Location> LoadMap(string filePath)
{
    List<Location> map = new List<Location>();

    foreach (string line in File.ReadLines(filePath))
    {
        string[] parts = line.Split(',');

        if (parts.Length >= 5)
        {
            string name = parts[0].Trim();
            string description = parts[1].Trim();
            int x, y;

            // ✅ Properly parse X & Y (including negative numbers)
            if (!int.TryParse(parts[2], out x) || !int.TryParse(parts[3], out y))
            {
                Console.WriteLine($"Error: Invalid coordinates in map data -> {line}");
                continue; // Skips the broken line instead of crashing
            }

            bool accessible = parts[4].Trim().ToLower() == "accessible";
            string dialogue = parts.Length >= 6 ? parts[5].Trim() : "";

            map.Add(new Location(name, description, x, y, accessible, dialogue));
        }
        else
        {
            Console.WriteLine($"Error: Malformed entry in map data -> {line}");
        }
    }
    return map;
}


        public static Dictionary<(int, int), NPC> LoadNPCs(string filePath)
        {
            Dictionary<(int, int), NPC> npcs = new Dictionary<(int, int), NPC>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(',');
                npcs[(int.Parse(parts[1]), int.Parse(parts[2]))] = new NPC(parts[0], parts[3]);
            }
            return npcs;
        }
    }
}
