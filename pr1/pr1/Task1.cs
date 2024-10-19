using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pr1
{
    class NumbersOfDiapasone : ITask
    {
        private int[] arr;
        private int n;
        private Random random = new Random();

        public NumbersOfDiapasone(int[] arr, int n)
        {
            this.arr = arr;
            this.n = n;
        }

        public void RandomArr()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10, 40);
            }
        }

        public void CheckDiapasone()
        {
            foreach (int value in arr)
            {
                Console.WriteLine(value + (value > 0 && value < n ? " true" : " false"));
            }
        }

        public void Execute()
        {
            RandomArr();
            CheckDiapasone();
        }
    }
}