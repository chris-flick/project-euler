using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiples_of_3_and_5 
    {
    class Program {

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

            Console.WriteLine(number);

            return 0;

        }
    }
}
