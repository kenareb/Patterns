namespace BlackBoardDemo
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            // Set up an array of random data:
            int length = 1000;

            if (args.Length > 0)
            {
                int cmdArg;

                if (int.TryParse(args[0], out cmdArg))
                {
                    length = cmdArg;
                }
            }

            Random rng = new Random((int)(DateTime.UtcNow.Ticks));
            var input = new int[length];
            for (int i = 0; i < length; i++)
            {
                input[i] = rng.Next();
            }

            // Initialize mergesort with blackboard implementation:
            var mergesort = new MergeSort();

            // Sort the data:
            var sorted = mergesort.Sort(input);

            // Due to visualization limitations, we're simply outputting only small arrays:
            if (length <= 20)
            {
                Console.WriteLine("Input:");
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(input[i]);
                }

                Console.WriteLine();
                Console.WriteLine("Sorted:");
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(sorted[i]);
                }
            }
            else
            {
                Console.WriteLine($"Sorted {length} items");
            }

            Console.ReadLine();
        }
    }
}