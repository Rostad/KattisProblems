using System;
using System.IO;

namespace KattisProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.CalculateBestSequence();
            
        }

        private void CalculateBestSequence()
        {
            string commercialInput = Console.ReadLine();
            string[] commercialSplit = commercialInput.Split(new char[] { ' ' }, StringSplitOptions.None);
            int commercialAmount = int.Parse(commercialSplit[0]);
            int commercialCost = int.Parse(commercialSplit[1]);
            int[] watchers = GetAmountOfStudentWatchers(commercialAmount);
            for (int i = 0; i < commercialAmount; i++)
            {
                watchers[i] = watchers[i] - commercialCost;
            }
            
            Console.WriteLine(MaxSubArraySum(watchers, commercialAmount));

            
        }

        private int[] GetAmountOfStudentWatchers(int amount)
        {
            string input = Console.ReadLine();
            string[] inputSplit = input.Split(new char[] { ' ' }, StringSplitOptions.None);
            int[] amountOfWatchers = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                amountOfWatchers[i] = int.Parse(inputSplit[i]);
            }

            return amountOfWatchers;

        }

        private int MaxSubArraySum(int[] array, int size)
        {
            int maxHitherto = 0, maxEndingHere = 0;

            for(int i = 0; i < size; i++)
            {
                maxEndingHere += array[i];
                if(maxEndingHere < 0)
                {
                    maxEndingHere = 0;
                } else if(maxHitherto < maxEndingHere)
                {
                    maxHitherto = maxEndingHere;
                }
            }

            return maxHitherto;
        }

    }
}
