using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc24
{
	class Day1
	{
		public static void Solve()
		{
			int totalDistance = 0;
			int similarity = 0;

			List<int> left = new List<int>();
			List<int> right = new List<int>();

			var rawInput = File.ReadAllLines(@"..\..\..\D1.txt");

			foreach (var entry in rawInput)
			{
				var temp = entry.Split("   ");
				left.Add(Convert.ToInt32(temp[0]));
				right.Add(Convert.ToInt32(temp[1]));
			}

			left.Sort();
			right.Sort();

			//Part 1
			for (int i = 0; i < left.Count; i++)
			{
				totalDistance += (int)MathF.Abs(left[i] - right[i]);
			}

			//Part 2
			foreach (var entry in left)
			{
				similarity += entry * right.FindAll(n => n == entry).Count;
			}

			Console.WriteLine("Distance: " + totalDistance);
			Console.WriteLine("Similarity " + similarity);
		}
	}
}
