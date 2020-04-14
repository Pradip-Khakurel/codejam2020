using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ParentingPartnering
{
    class Solution
    {
        public class Activity
        {
            public int Id { get; set; }
            public int Start { get; set; }
            public int End { get; set; }
            public char X { get; set; }
        }

        static void Main(string[] args)
        {
            var T = int.Parse(Console.ReadLine());

            for (int t = 1; t <= T; t++)
            {
                var n = int.Parse(Console.ReadLine());
                var activities = new Activity[n];

                for (int i = 0; i < n; i++)
                {
                    var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    activities[i] = new Activity()
                    {
                        Start = arr[0],
                        End = arr[1],
                        Id = 1
                    };
                }

                if (Compute(activities.OrderBy(a => a.Start).ToArray()))
                {
                    var result = activities.OrderBy(a => a.Id).Select(a => a.X).ToArray();
                    Console.WriteLine($"Case #{t}: {new string(result)}");
                }
                else {
                    Console.WriteLine($"Case #{t}: IMPOSSIBLE");
                }
            }
        }

        static bool Compute(Activity[] activities)
        {
            int c = 0, j = 0;

            foreach (var act in activities)
            {
                int? diffc = act.Start >= c ? act.Start - c : new int?();
                int? diffj = act.Start >= j ? act.Start - j : new int?();

                if (!diffc.HasValue && !diffj.HasValue) return false;

                if (!diffj.HasValue || diffc >= diffj)
                {
                    act.X = 'C';
                    c = act.End;
                }
                else
                {
                    act.X = 'J';
                    j = act.End;
                }
            }

            return true;
        }
    }
}
