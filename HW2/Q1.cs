using System;
using System.Diagnostics;

namespace HW2 {
    class Q1 {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            int trials = 1;
            long overheadTime, totalTime;
            double workTime, prev = 0;
            Console.WriteLine("k\tTime\tRatio");

            for (int k = 1; k <= 55; k++) {
                Console.Write($"{k}\t");

                sw.Start();
                while (sw.ElapsedMilliseconds < 1000)
                    ;

                sw.Restart();
                for (int i = 0; i < trials; i++) {
                    Fibonacci(k);
                }

                totalTime = sw.ElapsedMilliseconds;

                sw.Restart();
                for (int i = 0; i < trials; i++)
                    ;

                overheadTime = sw.ElapsedMilliseconds;
                workTime = ((totalTime - overheadTime) / ((double) trials)) / 1000;
                Console.Write($"{workTime}\t");
                Console.WriteLine($"{(prev == 0.0 ? 0 : workTime / prev)}");
                prev = workTime;
            }

            Console.WriteLine("done");
            Console.Read();
        }

        static long Fibonacci(long k) {
            if (k == 0 || k == 1) {
                return 1;
            }
            else {
                return Fibonacci(k - 1) + Fibonacci(k - 2);
            }
        }
    }
}
