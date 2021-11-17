using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfireDemo.Demo
{
    public interface IDemoService
    {
        void RunDemoTask();

        void RunFibDemo(int fibParam);
    }
    public class DemoService : IDemoService
    {
        public void RunDemoTask()
        {
            Console.WriteLine("This is a recurring task that runs every minute from the Demo service.");
        }

        public void RunFibDemo(int fibParam)
        {
            Console.WriteLine("This is the Fibonacci background job demo, calculating Fib {0} ", fibParam.ToString());
            
            if (fibParam < 45) {

                Fibonacci_Recursive(fibParam);

            }
            else
            {
                Console.WriteLine(fibParam.ToString() + " is too great to calculate.  Choose a number < 45");

            }
        }


        public static int FibonacciSeries(int n)
        {
            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   
            return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
        }
        public static void Fibonacci_Recursive(int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write("{0} ", FibonacciSeries(i));
            }
        }

    }
}
