using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubProfileToFilezilla
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var profile = new ProfileReader().Read("SampleInput.xml");
            var zilla = Converter.Convert(profile);

            new FileZillaWriter().Write(zilla, "output.xml");

            Console.WriteLine("Done");
        }
    }
}
