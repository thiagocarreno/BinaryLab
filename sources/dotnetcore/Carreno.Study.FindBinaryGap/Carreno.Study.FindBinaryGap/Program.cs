using System;

namespace Carreno.Study.FindBinaryGap
{
    class Program
    {
        static void Main()
        {
            var solution = new Solution();
            var values = new int[] { 9, 529, 20, 15, 32, 1041 };

            foreach (var value in values)
            {
                var maxSequence = solution.solution(value);
                Console.WriteLine(maxSequence);
            }
            
            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int N)
        {
            var maxSequence = default(int);
            var parameterString = Convert.ToString(N, 2);
            var sequenceCount = default(int);

            for (var i = 0; i < parameterString.Length; i++)
            {
                if (parameterString[i] == '0')
                    sequenceCount++;
                else
                {
                    if (maxSequence < sequenceCount)
                    {
                        maxSequence = sequenceCount;
                        sequenceCount = default(int);
                    }
                }
            }

            return maxSequence;
        }
    }
}
