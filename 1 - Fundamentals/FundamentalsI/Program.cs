using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a Loop that prints all values from 1-255");
            for (int i=1; i<=25; i++){
            Console.WriteLine(i);
            }

            Console.WriteLine("Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both");
            for (int i=1; i<=100; i++){
            if (i%3==0 || i%5==0) {
                if (i%3==0 && i%5==0){
                continue;
                }
                Console.WriteLine(i);
            }
            }

            Console.WriteLine("Modify the previous loop to print 'Fizz' for multiples of 3, 'Buzz' for multiples of 5, and 'FizzBuzz' for numbers that are multiples of both 3 and 5");
            for (int i=1; i<=100; i++){
            if (i%3==0 && i%5==0) {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            if (i%3==0) {
                Console.WriteLine("Fizz");
                continue;
            }
            if (i%5==0) {
                Console.WriteLine("Buzz");
                continue;
            }
            }

            Console.WriteLine("Previous example using a While loop");
            int j=1;
            while (j<=100){
            if (j%3==0 && j%5==0) {
                Console.WriteLine("FizzBuzz");
                j = j+1;
                continue;
            }
            if (j%3==0) {
                Console.WriteLine("Fizz");
                j = j+1;
                continue;
            }
            if (j%5==0) {
                Console.WriteLine("Buzz");
                j = j+1;
                continue;
            }
            j=j+1;
            }
        }
    }
}
