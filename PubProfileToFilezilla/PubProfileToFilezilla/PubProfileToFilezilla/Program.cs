using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubProfileToFilezilla
{
    class Program
    {
        static void Main(string[] args)
        {
            var profile = new ProfileReader().Read("SampleInput.xml");

            Console.WriteLine("Done");
        }
    }
}
