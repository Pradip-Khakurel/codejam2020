using System;
using System.Linq;

namespace BlindFoldedBullsEye
{
    class Program
    {
        class Point
        {
            public int x { get; set; }
            public int y { get; set; }
        }
        
        static string CENTER = "CENTER";
        static string MISS = "MISS";

        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var T = arr[0];
            var A = arr[1];
            var B = arr[2]; 

            for (int t = 1; t <= T; t++)
            {
                Answer();               
            }
        }

        static void Answer()
        {
            var max = (int)Math.Pow(10, 9);
            var half = max / 2;
            var candidates = new [] 
            {
                new Point() { x = 0, y = 0 },
                new Point() { x = half, y = half },
                new Point() { x = half, y = -half },
                new Point() { x = -half, y = -half },
                new Point() { x = -half, y = half },
            };

            Point hit = null;
            String ans = null;
            
            foreach (var pt in candidates)
            {
                Console.WriteLine($"{pt.x} {pt.y}");
                ans = Console.ReadLine();
                if(ans == CENTER) return;
                if(ans == MISS) continue;
                hit = pt;
                break;
            }

            //left
            int lo = -max, hi = hit.x;
            int left=lo;
            while(lo < hi) {
                left = MidFloor(lo, hi);
                Console.WriteLine($"{left} {hit.y}");
                ans = Console.ReadLine();
                if(ans == CENTER) return;
                if(ans == MISS) lo = left+1;
                else hi = left;
            }

            lo = hit.x; hi = max;
            int right=lo;
            while(lo < hi) {
                right = MidCeiling(lo, hi);
                Console.WriteLine($"{right} {hit.y}");
                ans = Console.ReadLine();
                if(ans == CENTER) return;
                if(ans == MISS) hi = right-1;
                else lo = right;
            }

            lo = hit.y; hi = max;
            int top=lo;
            while(lo < hi) {
                top = MidCeiling(lo, hi);
                Console.WriteLine($"{hit.x} {top}");
                ans = Console.ReadLine();
                if(ans == CENTER) return;
                if(ans == MISS) hi = top-1;
                else lo = top;
            }

            lo = -max; hi = hit.y;
            int down=lo;
            while(lo < hi) {
                down = MidFloor(lo, hi);
                Console.WriteLine($"{hit.x} {down}");
                ans = Console.ReadLine();
                if(ans == CENTER) return;
                if(ans == MISS) lo = down+1;
                else hi = down;
            }

            candidates = new[] {
                new Point() { x = MidFloor(left, right), y = MidCeiling(down, top) },
                new Point() { x = MidCeiling(left, right), y = MidFloor(down, top) },
                new Point() { x = MidCeiling(left, right), y = MidCeiling(down, top) },
                new Point() { x = MidFloor(left, right), y = MidFloor(down, top) },
            };

            foreach (var pt in candidates)
            {
                Console.WriteLine($"{pt.x} {pt.y}");
                ans = Console.ReadLine();
                if(ans == CENTER) return;
            }

            Console.WriteLine($"{MidFloor(left, right)} {MidFloor(down, top)}");
            Console.ReadLine();
        }

        static int MidFloor(double lo, double hi) {
            return (int)Math.Floor(lo + (hi-lo)/2);
        }

        static int MidCeiling(double lo, double hi) {
            return (int)Math.Ceiling(lo + (hi-lo)/2);
        }
    }
}
