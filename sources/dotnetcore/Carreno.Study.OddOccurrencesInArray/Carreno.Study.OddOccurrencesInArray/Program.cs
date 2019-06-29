using System;
using System.Collections.Generic;
using System.Linq;

namespace Carreno.Study.OddOccurrencesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new int[] { 9, 3, 9, 3, 9, 7, 9 };
            var solution = new Solution();
            var unpairedValue = solution.solution(values);

            Console.Write(unpairedValue);
            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int[] values)
        {
            var valueList = values.ToList();
            var unpairedValue = 0;
            var index = 0;

            foreach (var value in valueList)
            {
                RemovePair(ref valueList, index);
                index++;
            }

            return unpairedValue;
        }

        private void RemovePair(ref List<int> valueList, int idx)
        {
            var remainingValues = (valueList.Count - (idx + 1));
            for (int j = idx; j < remainingValues; j++)
            {
                if (valueList.ElementAt(idx) == valueList.ElementAt(j))
                {
                    valueList.RemoveAt(idx);
                    valueList.RemoveAt(j);
                    break;
                }
            }
        }
    }
}