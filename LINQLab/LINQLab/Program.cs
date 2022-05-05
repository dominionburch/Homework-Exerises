using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring an array of integer variables
            int[] nums = { 10, 2330, 112233, 12, 949, 3764, 2942, 523863 };
            int maximum, minimum, less10k2;

            //Finding maximum and minimum value within the array
            maximum = nums.Max();
            minimum = nums.Min();

            var less10k1 = nums.Where((x) => x < 10000).ToArray();
            less10k2 = less10k1.Max();

            var between = nums.Where((x) => (x >= 10) && (x <= 100)).ToArray();

            var betweenLarge = nums.Where((x) => (x <= 999999) && (x >= 100000)).ToArray();

            var evenNums = nums.Where((x) => x % 2 == 0).ToArray();

            Console.WriteLine($"Maximum number is: {maximum}");
            Console.WriteLine($"Minimum number is: {minimum}");
            Console.WriteLine($"Maximum less than 10000 is: {less10k2}");

            Console.Write($"Numbers between 10 and 100 are: ");
            foreach (int x in between)
                Console.Write($" {x}");

            Console.Write($"\nNumbers between 10,000 and 99,999 inclusive: ");
            foreach (var y in betweenLarge)
                Console.Write($" {y}");

            Console.Write($"\nAll even numbers are: ");
            foreach (int r in evenNums)
                Console.Write($" {r},");
        }
    }
}

