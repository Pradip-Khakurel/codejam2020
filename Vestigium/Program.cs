using System;
using System.Collections.Generic;
using System.Linq;

namespace Vestigium
{
    class Solution
    {
        private static int _n;
        private static int[,] _matrix;

        static void Main(string[] args) {

            var T = int.Parse(Console.ReadLine());

            for (int t = 1; t <= T; t++) {
                _n = int.Parse(Console.ReadLine());
                _matrix = new int[_n,_n];
                
                for (int i = 0; i < _n; i++)
                {
                    var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    for (int j = 0; j < _n; j++)
                    {
                        _matrix[i, j] = nums[j];
                    }
                }

                var result = Compute();

                Console.WriteLine($"Case #{t}: {result.Item1} {result.Item2} {result.Item3}");
            }
        }

        private static Tuple<int, int, int> Compute() {
            var trace = ComputeTrace();
            var rowDups = ComputeRowDuplicates();
            var colDups = ComputeColumnDuplicates();

            return new Tuple<int, int, int>(trace, rowDups, colDups);
        }

        private static int ComputeTrace()  {
            var sum = 0;

            for(int i=0,j=0; i<_n; i++,j++) 
                sum += _matrix[i,j];

            return sum;
        }

        private static int ComputeRowDuplicates() {
            int count = 0;
            for (int i = 0; i < _n; i++) {
                var set = new HashSet<int>();
                for (int j = 0; j < _n; j++) {
                    if(!set.Add(_matrix[i,j])) {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        private static int ComputeColumnDuplicates() {
            int count = 0;
            for (int i = 0; i < _n; i++) {
                var set = new HashSet<int>();
                for (int j = 0; j < _n; j++) {
                    if(!set.Add(_matrix[j,i])) {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }
    }
}
