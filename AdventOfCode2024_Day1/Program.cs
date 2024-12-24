using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024_Day1
{
    internal class Program
    {
        // Main class for Day 1 Solution
        public static void Main()
        {
            Console.WriteLine("Advent of Code: Day 1");
            
            // Get input
            Console.WriteLine("Filepath to input: ");
            string inputPath = Console.ReadLine();
            string locationLists = File.ReadAllText(inputPath);
            
            // Clean input
            List<List<int>> cleanedLists = CleanInput(locationLists);
            List<int> listLeft = cleanedLists[0];
            List<int> listRight = cleanedLists[1];
            
            // --- PART 1: Total Distance ---
            int totalDistance = 0;
            for (int n = 0; n < listLeft.Count; n++)
            {
                totalDistance += Math.Abs(listLeft[n] - listRight[n]);
            }
            
            Console.WriteLine("Total Distance: " + totalDistance);
            
            // --- PART 2: Similarity Score ---
            int similarityScore = 0;
            foreach (int leftLocation in listLeft)
            {
                IEnumerable<int> queryLeftInRight =
                    from rightLocation in listRight
                    where rightLocation == leftLocation
                    select rightLocation;

                similarityScore += leftLocation * queryLeftInRight.Count();
            }
            
            Console.WriteLine("Similarity Score: " + similarityScore);
        }
        
        public static List<List<int>> CleanInput(string input)
        {
            // Vars
            char[] splitValues = { ' ', '\n' };
            
            // Split by split options
            string[] splitLines = input.Split(splitValues, StringSplitOptions.RemoveEmptyEntries);
            int[] allLocations = Array.ConvertAll(splitLines, location => int.Parse(location));
            
            // Create sublists
            List<int> listA = allLocations.Where((x, i) => i % 2 == 0).ToList();
            List<int> listB = allLocations.Where((x, i) => i % 2 != 0).ToList();
            
            // Sort sublists
            listA.Sort();
            listB.Sort();
            
            return new List<List<int>> {listA, listB};
        }
    }
}