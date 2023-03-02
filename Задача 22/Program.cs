//using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Func<Task<int[]>, int[]> func2 = new Func<Task<int[]>, int[]>(SumArray);
            Task<int[]> task2 = task1.ContinueWith<int[]>(func2);

            Func<Task<int[]>, int[]> func3 = new Func<Task<int[]>, int[]>(MaxArray);
            Task<int[]> task3 = task2.ContinueWith<int[]>(func3);

            task1.Start();
                        
            
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[100];
            Random random= new Random();
            for (int i = 0; i < 10; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }



        static int[] SumArray(Task<int[]> task)
        {

            int[] array = task.Result;
            Random random= new Random();
            int S = 0;
            for (int i = 0; i < 10; i++)
            {
                array[i] = random.Next(0, 100);
                S += array[i];
    Console.WriteLine("{0} ", array[i]);
}
            Console.WriteLine();
            Console.WriteLine(S);
return array;
        }


        static int[] MaxArray(Task<int[]> task)
        {
            int[] array = task.Result;
            Random random = new Random();
            
            for (int i = 0; i < 100; i++)
            {
                array[i] = random.Next(0, 100);
                
                Console.WriteLine("{0} ", array[i]);
            }
            Console.WriteLine();
            int max = array[0];
            foreach (int a in array)
            {
                if (a>max) max = a;
            }
            Console.WriteLine(max);
            return array;
        }

    }
}