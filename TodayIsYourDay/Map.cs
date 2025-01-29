using System;
using System.Collections.Generic;
using System.IO;

namespace GameProject
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
                    map.Add(new Location(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4] == "accessible", parts.Length == 6 ? parts[5] : ""));
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
