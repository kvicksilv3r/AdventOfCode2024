using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc24
{
    class Day2
    {
        public static void Solve()
        {
            var input = File.ReadAllLines("D2.txt").Select(e => e.Split(" ").Select(int.Parse).ToArray()).ToArray();
            int matches = 0;

            //Jesus christ here we go
            foreach (var row in input)
            {
                int[] dummy = new int[row.Length];
                row.CopyTo(dummy, 0);

                Array.Sort(dummy);

                if (dummy.SequenceEqual(row))
                {
                    matches += DistanceChecker(row);
                    continue;
                }

                Array.Reverse(dummy);

                if (dummy.SequenceEqual(row))
                {
                    matches += DistanceChecker(row);
                    continue;
                }
            }
            // Jesus ends here

            Console.WriteLine("Fuck you: " + matches);
        }

        private static int DistanceChecker(int[] row)
        {
            var dist = 0;
            for (int i = 0; i < row.Length - 1; i++)
            {
                dist = Math.Abs(row[i] - row[i + 1]);
                if (dist > 3 || dist == 0)
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
