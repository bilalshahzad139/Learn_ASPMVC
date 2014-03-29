using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQPrac
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * All LINQ query operations consist of three distinct actions:
             * - Obtain the data source.
             * - Create the query.
             * - Execute the query.
             */

            // The Three Parts of a LINQ Query: 
            //  1. Data source. 
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };


            /* We need to find even numbers from above array 
             One approach can be following, using a loop
             
             for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write("{0} ", numbers[i]);
                }
            }
            System.Console.WriteLine("");
             
              
             */

            
            // 2. Query creation. 
            // numQuery is an IEnumerable<int> 
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;
                

            

            // 3. Query execution. 
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }


            /*
             * Types that support IEnumerable<T> or 
             * a derived interface such as the generic IQueryable<T> are called queryable types.
             */

            System.Console.ReadKey();

        }
    }

    
}
