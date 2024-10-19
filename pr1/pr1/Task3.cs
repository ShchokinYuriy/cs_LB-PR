using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class BigArray : ITask
    {
        private int[] arr;
        private Random random = new Random();

        public BigArray(int[] arr)
        {
            this.arr = arr;
        }

        public void GenerateArray()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, arr.Length);
            }
        }

        public void ShowArray()
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }

        public void ShowMin()
        {
            int min = arr.Min();
            Console.WriteLine("Minimal number = " + min);
        }

        public void ShowMax()
        {
            int max = arr.Max();
            Console.WriteLine("Maximal number = " + max);
        }

        public void Execute()
        {
            GenerateArray();
            ShowArray();
            ShowMin();
            ShowMax();
        }
    }
}