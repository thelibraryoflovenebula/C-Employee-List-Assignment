using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("PROGRAM STARTED");
            


            int[] unsorted = { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            //int[] sorted = new int[unsorted.Length];
            
            foreach(var item in unsorted)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();


            for (int i = 0; i < unsorted.Length; i++)
            {
                int min;
                int temp;

                for (int j = i + 1; j < unsorted.Length; j++)
                {
                    min = unsorted[i];
                    if (min > unsorted[j])
                    {
                        min = unsorted[j]; //store new minimum
                        temp = unsorted[i]; //store temp to put where current

                        unsorted[i] = min; // switch new lowest 
                        unsorted[j] = temp; //switch old place

                    }
                }
            }

            foreach (var item in unsorted)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
            Console.ReadKey();


        }

    }
}
