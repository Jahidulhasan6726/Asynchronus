using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_01_EviTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// for even number
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Run(i);
                }
            }

            //for odd number
            for (int i = 1; i <= 20; i++)
                {
                    if (i % 2 == 1)
                    {
                        Run1(i);
                    }
                }

            Console.ReadKey();
        }
        static void Run(int n)
        {
            Task.Run(() =>
            {
                return OddNumber(n);
            }).ContinueWith(t =>
            {
                Console.WriteLine($"{n}!={t.Result}");
            });
        }
        static async Task<long> OddNumber(int n)
        {
            int fact = 1;
            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    fact = fact * i;
                }
            });
            return fact;
        }

        static void Run1(int n)
        {
            Task.Run(() =>
            {
                return EvenNumber(n);
            }).ContinueWith(t =>
            {
                Console.WriteLine($"{n}!={t.Result}");
            });
        }
        static async Task<long> EvenNumber(int n)
        {
            int fact = 1;
            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    fact = fact * i;
                }
            });
            return fact;
        }
    }
}
