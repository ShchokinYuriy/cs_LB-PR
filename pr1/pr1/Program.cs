using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pr1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr1 = new int[46];
            int[] tringle = new int[3] { 3, 4, 5 };
            int n = 27;

            var numbersTask = new NumbersOfDiapasone(arr1, n);
            var triangleTask = new Tringle(tringle);
            var bigArrayTask = new BigArray(arr1);
            var arrayFilterTask = new ArrayFilter(arr1, n);

            List<ITask> tasks = new List<ITask>
            {
                numbersTask,
                triangleTask,
                bigArrayTask,
                arrayFilterTask
            };

            foreach (var task in tasks)
            {
                task.Execute();
                Console.WriteLine(); 
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
