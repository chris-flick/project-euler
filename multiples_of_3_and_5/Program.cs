using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiples_of_3_and_5 
    {
    class Program {

        /// <summary>
        /// Iteratively sums multiples of 3 and 5, while also making sure to exclude the overlapping of numbers that are multiples of both 3 and 5
        /// </summary>
        /// <param name="n">the number to sum all multiples of 3 and 5 for</param>
        /// <returns></returns>
        static double bruteForceSummation(int n) {
            int summation = 0;

            int k = 1;
            while (k < n) {

                int currentMultipleOf3 = k * 3;
                int currentMultipleOf5 = k * 5;

                // add multiple of 3 to sum. 
                // Has a check to make sure this number isn't also a multiple of 5 in order to prevent summing the same number twice
                if (currentMultipleOf3 < n && currentMultipleOf3 % 5 != 0) {
                    summation += currentMultipleOf3;
                }

                if (currentMultipleOf5 < n) {
                    summation += currentMultipleOf5;
                }

                if (currentMultipleOf3 >= n && currentMultipleOf5 >= n) {
                    break;
                }

                k++;
            }

            return summation;
        }

        /// <summary>
        /// This solution utilizes this summation theorem: https://en.wikipedia.org/wiki/1_%2B_2_%2B_3_%2B_4_%2B_%E2%8B%AF
        /// 
        /// Since Sn = (n * (n+1)) / 2,
        /// we can multiple the formula for Sn by 3 or 5 to sum only multiples of 3 or 5, 
        /// but then we have to divide n by 3 or 5 in order to stay within the original boundaries.
        /// 
        /// Sn = 1 + 2 + 3 + ... + (n - 1) + n = (n * (n+1)) / 2
        /// 3Sn = 3 + 6 + 9 + ... + 3(n - 1) + 3n = 3 * (n * (n+1)) / 2
        /// 
        /// To stay within boundaries of the original n, we need to divide n by 3. Instead of iterating all the way to 1000, we would iterate to 1000 / 3,
        /// 3 * ( (n/3) * ( (n/3) + 1) ) / 2
        /// 
        /// Ex: 3 * ( (1000/3) * ( (1000/3) + 1) ) / 2
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        static double summationTheorem(int n, int multiple) {
            double summation = 0;
            int reducedN = (int) n / multiple;

            summation = multiple * ((reducedN * (reducedN + 1)) / 2);

            return summation;

        }

        /// <summary>
        /// 
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// 
        /// </summary>
        /// <param name="args">The number to find the sum of all the multiples of 3 or 5 for.</param>
        /// <returns></returns>
        static int Main(string[] args) {

            // validate that user provided a value
            if (args.Length == 0) {
                Console.WriteLine("Please provide an Integer value greater than 0.");
                return -1;
            }

            // validate that provided value is an integer
            int number = -1;
            try {
                number = int.Parse(args[0]);
            } catch (Exception ex) {
                Console.WriteLine(args[0] + " is not a valid integer value.");
                return -1;
            }

            // validate that integer provided is not negative or zero
            if (number <= 0) {
                Console.WriteLine("The number provided has to be greater than 0.");
                return -1;
            }

            double summation = bruteForceSummation(number);
            Console.WriteLine(summation);

            // need to sum (multiples of 3 + multiples of 5 - multiples of 15) to remove duplicates counts of numbers that are multiples of both 3 and 5
            double sn = summationTheorem(1000, 3) + summationTheorem(1000, 5) - summationTheorem(1000, 15);
            Console.WriteLine(sn);

            return 0;

        }
    }
}
