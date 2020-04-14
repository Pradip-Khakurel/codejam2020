using System;
using System.Text;

namespace Resab
{
    class Solution
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ');

            int T = int.Parse(arr[0]);
            int b = int.Parse(arr[1]);
            var builder = new StringBuilder();

            for (int t = 0; t < T; t++)
            {
                for (int i = 0; i < 150; i++)
                {
                    int j = i % 10;
                    if (j == 0) builder.Clear();
                    Console.WriteLine(j+1);
                    builder.Append(Console.ReadLine());
                }

                Console.WriteLine(builder.ToString());
                if(Console.ReadLine() != "Y") return;
            }
        }
    }
}
