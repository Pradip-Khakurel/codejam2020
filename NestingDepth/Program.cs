using System;
using System.Text;
using System.Linq;

namespace NestingDepth
{
    class Solution
    {
        static void Main(string[] args)
        {
            var T = int.Parse(Console.ReadLine());

            for (int t = 1; t <= T; t++)
            {
                var nums = Console.ReadLine().ToArray().Select(c => (int)Char.GetNumericValue(c)).ToArray();
                Console.WriteLine($"Case #{t}: {Calculate(nums)}");
            }
        }

        static string Calculate(int[] array)
        {
            int depth = 0;
            StringBuilder builder = new StringBuilder();

            foreach (var x in array)
            {
                while (x > depth)
                {
                    builder.Append('(');
                    depth++;
                }

                while (x < depth)
                {
                    builder.Append(')');
                    depth--;
                }

                builder.Append(x);
            }

               while (depth > 0)
                {
                    builder.Append(')');
                    depth--;
                }

            return builder.ToString();
        }
    }
}
