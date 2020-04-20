using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Expogo
{
    public class Solution
    {
        static long _x;
        static long _y;

        public static void Main(string[] args)
        {
            var T = int.Parse(Console.ReadLine());

            for (int t = 1; t <= T; t++)
            {
                var array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                _x = array[0];
                _y = array[1];

                Console.WriteLine($"Case #{t}: {Bfs()}");
            }
        }

        static string Bfs() 
        {
            var queue = new Queue<Tuple<long, long>>();
            var paths = new Queue<string>();
            var iter = new Queue<int>();
            var origin = new Tuple<long, long>(0, 0);

            queue.Enqueue(origin);
            iter.Enqueue(0);
            paths.Enqueue("");

            while(queue.Any()) 
            {
                var cur = queue.Dequeue();                
                var i = iter.Dequeue();                           
                var path = paths.Dequeue();
                var jump = (long)Math.Pow(2, i);

                if(cur.Item1 == _x && cur.Item2 == _y) return path;

                foreach (var nei in GetNeighbors(cur.Item1, cur.Item2, jump))
                {            
                    var nextPath = path+Recompute(cur, nei, jump); 
                    paths.Enqueue(nextPath);
                    queue.Enqueue(nei);
                    iter.Enqueue(i+1);
                }
            }

            return "IMPOSSIBLE";
        }

        static string Recompute(Tuple<long, long> cur, Tuple<long, long> next, long jump) 
        {
            if(next.Item1 == cur.Item1 && next.Item2+jump == cur.Item2) {
                return "S";
            }
            else if(next.Item1 == cur.Item1 && next.Item2-jump == cur.Item2) {
                return "N";
            }
            else if(next.Item1-jump == cur.Item1 && next.Item2 == cur.Item2) {
                return "E";
            }
            else {
                return "W";
            }  
        }

        static List<Tuple<long, long>> GetNeighbors(long x, long y, long jump)
        { 
            var list = new List<Tuple<long, long>>(4);

            list.Add(new Tuple<long, long>(x+jump, y));
            list.Add(new Tuple<long, long>(x-jump, y));
            list.Add(new Tuple<long, long>(x, y+jump));
            list.Add(new Tuple<long, long>(x, y-jump));            

            return list.Where(_ => Abs(_.Item1) <= 100 && Abs(_.Item2) <= 100).ToList();
        }

        private static long Abs(long val)
        {
            return (long)Math.Abs(val);
        }
    }
}
