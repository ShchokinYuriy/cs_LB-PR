using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class Tringle : ITask
    {
        private int[] arr;

        public Tringle(int[] arr)
        {
            this.arr = arr;
        }

        public void CheackTringle()
        {
            if (arr[0] + arr[1] > arr[2] && arr[0] + arr[2] > arr[1] && arr[1] + arr[2] > arr[0])
            {
                Console.WriteLine("Tringle is valid :)");
            }
            else
            {
                Console.WriteLine("Tringle is not valid :(");
            }
        }

        public void TringleP()
        {
            if (arr[0] + arr[1] > arr[2] && arr[0] + arr[2] > arr[1] && arr[1] + arr[2] > arr[0])
            {
                float P = arr.Sum();
                Console.WriteLine("P = " + P);
            }
            else
            {
                Console.WriteLine("ERROR!!! ERROR!!!");
            }
        }

        public void TringleS()
        {
            if (arr[0] + arr[1] > arr[2] && arr[0] + arr[2] > arr[1] && arr[1] + arr[2] > arr[0])
            {
                float S = arr.Sum() / 2;
                S = (float)Math.Sqrt(S * (S - arr[0]) * (S - arr[1]) * (S - arr[2]));
                Console.WriteLine("S = " + S);
            }
            else
            {
                Console.WriteLine("ERROR!!! ERROR!!!");
            }
        }

        public void Execute()
        {
            CheackTringle();
            TringleP();
            TringleS();
        }
    }
}