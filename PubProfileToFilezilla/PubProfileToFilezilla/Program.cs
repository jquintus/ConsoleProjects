using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubProfileToFilezilla
{
    public class Program
    {
        public const string USAGE = @"
USAGE
    pubToFz path_to_input [path_to_output]

If path_to_output is omitted, the file is saved as filezilla.xml in the current directory

Example
    pubToFz c:\users\myName\downloads\file.publishProfile


";
        public static void Main(string[] args)
        {
            try
            {
            string input = GetInput(args);
            string output = GetOutput(args);

            if (input == null || output == null)
            {
                Console.WriteLine(USAGE);
                return;
            }

                var profile = new ProfileReader().Read(input);
                var zilla = Converter.Convert(profile);

                new FileZillaWriter().Write(zilla, output);

                Console.WriteLine("completed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error processing the files");
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetOutput(string[] args)
        {
            return GetArg(args, 1) ?? "filezilla.xml";
        }

        private static string GetInput(string[] args)
        {
            return GetArg(args, 0);
        }

        private static string GetArg(string[] args, int position)
        {
            if (args == null || args.Length <= position) return null;

            return args[position];
        }
    }
}
