using System;
using System.IO;

namespace FlattenBookRequests
{
    internal class Program
    {
        public const string DEFAULT_INPUT_FILE = "books.csv";
        public const string DEFAULT_OUTPUT_FILE = "flattened_books.csv";

        public static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            string input = GetInputFilePath(args);
            string output = GetOutputFilePath(args);

            FileProcessor fp = new FileProcessor();
            fp.Process(input, output);
        }

        private static string GetInputFilePath(string[] args)
        {
            string input = null;
            if (args != null && args.Length > 0)
            {
                input = args[0];
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                input = DEFAULT_INPUT_FILE;
                Console.WriteLine("Using default input file:  {0}", input);
            }
            if (!File.Exists(input))
            {
                throw new Exception("Cannot find the input file specified:  " + input);
            }

            return input;
        }

        private static string GetOutputFilePath(string[] args)
        {
            string output = null;
            if (args != null && args.Length > 0)
            {
                output = args[0];
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                output = DEFAULT_OUTPUT_FILE;
                Console.WriteLine("Using default output file:  {0}", output);
            }

            return output;
        }
    }
}