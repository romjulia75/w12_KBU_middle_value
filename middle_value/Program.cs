using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace middle_value
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Exercise W12.1--1
            Write a method that returns the middle value of 3 integers: public int Middle(int x, int y) {…}
            */
            // example>>>>>  int result = Middle(5, 4, 6);
            Console.WriteLine("Middle of (5, 4, 6) is {0}", MiddleVaerdi(5, 4, 6));
            Console.WriteLine("Middle of (9, 8, 7) is {0}", MiddleVaerdi(9, 8, 7));
            Console.WriteLine("Middle of (3, 4, 4) is {0}", MiddleVaerdi(3, 4, 4));
            Console.WriteLine("Middle of (6, 5, 2) is {0}", MiddleVaerdi(6, 5, 2));
            Console.WriteLine("Middle of (0, 5, 3) is {0}\n", MiddleVaerdi(0, 5, 3));
            Console.ReadKey();

            /* Exercise W12.2--2
            Let double x be a variable in a program.
            At a certain point in the program we want to investigate whether x equals the average of the numbers in an integer array: int[] t.
            How can you do that using an assert statement?
            */
            int[] array2 = { 1, 2, 3, 4, 5 };
            double x = 4;
            Console.WriteLine("{0} equals the average: {1}\n", x, MiddleCheck(array2, x));
            MiddleCheck_Assert(array2, x);
            Console.ReadKey();


            /* Exercise W12.2--3
            The method "pubic int Median(int[] b)" returns the median of the numbers in b (b is not empty).
            Write an "assert" statement that checks if the methods work correctly.
            */
            int[] array3 = { 7, 2, 9, 4, 5 };
            var median = Median(array3);
            Console.Write("Median = " + median );
            Console.WriteLine("\tAssert = " + array3.ToList().Sum() / array3.Length);
            Debug.Assert(median == array3.ToList().Sum() / array3.Length, "Method 'Median' does not work correctly");

            //Exercise W12.2--3-middle-element
            //int medium = MediumAssert(new int[] { 9, 2, 9, 5, 4 });
            median = Median_Middle_Element(array3);
            Console.WriteLine("Median_Middle_Element = " + median);
            Debug.Assert(Median_Middle_Element(array3) == 2, "Method 'Median' does not work correctly");

            Console.ReadKey();
        }

        //Exercise W12.1--1
        public static int MiddleVaerdi(int a, int b, int c)
        {
            int res = 0;

            if (a >= b && b >= c || c >= b && b >= a) res = b;
            if (a >= c && c >= b || b >= c && c >= a) res = c;
            if (c >= a && a >= b || b >= a && a >= c) res = a;
            return res;
        }

        //Exercise W12.2--2
        public static bool MiddleCheck(int[] array, double x)
        {
            bool b = false;
            double sum = 0;
            double average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                average = sum / array.Length;
            }
            if (x == average)
                b = true;
            return b;
        }

        public static void MiddleCheck_Assert(int[] liste, double x)
        {
            var sum = 0;
            foreach (var i in liste)
            {
                sum += i;
            }

            Debug.Assert(x == sum / liste.Length, string.Format("{0} is not equal the average of the numbers in array", x));
        }

        //Exercise W12.2--3
        public static int Median(int[] b)
        {
            var sum = 0;
            //var sum = 100;
            foreach (int item in b) sum += item;
            return sum / b.Length;            
        }

        //Exercise W12.2--3-middle-element
        public static int Median_Middle_Element(int[] b)
        {
            int amount = b.Length; ;
            int medium = 0;
            if (b != null)
            {
                if (b.Length % 2 != 0)
                {
                    amount = b.Length + 1;
                }
                medium = amount / 2;
            }
            return medium;
        }

    }
}
