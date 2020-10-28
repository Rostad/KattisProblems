using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while((input = Console.ReadLine()) != null)
            {
                string[] splitInput = input.Split(new char[] {' '}, StringSplitOptions.None);
                int dice1 = int.Parse(splitInput[0]);
                int dice2 = int.Parse(splitInput[1]);
                int[] sums = CalculateLikelySumOutcome(dice1, dice2);
                WriteSums(sums);
            }
        }

        private static int[] CalculateLikelySumOutcome(int dice1, int dice2)
        {
            if(dice1 == dice2)
            {
                return new int[] { dice1 + 1 };
            }

            int smallestDice = Math.Min(dice1, dice2);
            int largestDice = Math.Max(dice1, dice2);

            int arraySize = (largestDice - smallestDice) + 1;

            int[] sums = new int[arraySize];

            int k = 1;
            for (int i = 0; i < arraySize; i++) 
            {
                sums[i] = smallestDice + k++;
            }

            return sums;
        }

        private static void WriteSums(int[] sums)
        {
            foreach(int i in sums)
            {
                Console.WriteLine(i + Environment.NewLine);
            }
        }
    }

    
}
