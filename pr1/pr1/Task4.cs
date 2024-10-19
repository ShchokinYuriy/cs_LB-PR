using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class ArrayFilter : ITask
    {
        private int[] array;
        private int M;

        public ArrayFilter(int[] array, int M)
        {
            this.array = array;
            this.M = M;
        }

        public int[] FilterArray()
        {
            return array.Where(x => Math.Abs(x) > M).ToArray();
        }

        public void DisplayResults()
        {
            Console.WriteLine($"Threshold value M: {M}");
            Console.WriteLine("Array X:");
            Console.WriteLine(string.Join(" ", array));

            int[] Y = FilterArray();
            Console.WriteLine("Array Y:");
            Console.WriteLine(string.Join(" ", Y));
        }

        public void Execute()
        {
            DisplayResults();
        }
    }
}