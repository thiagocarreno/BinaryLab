using System;
using System.Linq;

namespace Carreno.Study.SoldierRank
{
    class Program
    {
        static void Main()
        {
            var solution = new Solution();
            var ranks = new int[][]
            {
                new int[] { 3, 4, 3, 0, 2, 2, 3, 0, 0 },
                new int[] { 4, 2, 0 }
            };

            foreach (var rank in ranks)
            {
                var total = solution.solution(rank);
                Console.WriteLine(total);
            }

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int[] ranks)
        {
            var soliderRank = ranks.OrderBy(i => i);
            var groupSoldier = ranks.Where(i => i > soliderRank.First() && i < soliderRank.Max())
                .GroupBy(i => i).Select(g => new {
                    Value = g.Key,
                    Count = g.Count()
                });

            if (groupSoldier.Count() > 1)
                return groupSoldier.Sum(i => i.Count);
            else
                return 0;
        }
    }
}