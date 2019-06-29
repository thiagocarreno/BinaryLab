using System;
using System.Text;

namespace Carreno.Study.ReformatPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var valuesTest = new string[] { "00-44 48 5555 8361", "0 - 22 1985--324", "555372654" };
            var solution = new Solution();

            foreach (var valueTest in valuesTest)
            {
                var reformattedString = solution.solution(valueTest);
                Console.WriteLine(reformattedString);
            }

            Console.ReadKey();
        }
    }

    class Solution
    {
        public string solution(string value)
        {
            var reformattedString = new StringBuilder();
            var numbers = value.Replace("-", "").Replace(" ", "");
            var blockLength = 3;
            var numberPerBlock = 0;
            var totalWritten = 0;

            foreach (var valueChar in numbers)
            {
                reformattedString.Append(valueChar);
                numberPerBlock++;
                totalWritten++;
                
                if (numberPerBlock == blockLength && (totalWritten < numbers.Length))
                {
                    reformattedString.Append('-');
                    blockLength = CalcBlockLength(totalWritten, numbers.Length);
                    numberPerBlock = 0;
                }
            }

            return reformattedString.ToString();
        }

        private static int CalcBlockLength(int totalWrote, int totalNumbers)
        {
            var reamainingNumbers = totalNumbers - totalWrote;
            if (reamainingNumbers > 2 && (reamainingNumbers - 3) == 1)
                return 2;
            else
                return 3;
        }
    }
}