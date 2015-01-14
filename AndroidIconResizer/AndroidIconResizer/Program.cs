using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIconResizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            MakeDestinationDirectories(dir);



            var files = dir.GetFiles("*.png");
            foreach (var file in files)
            {
                ResizeFile(file);
            }
        }

        private static void MakeDestinationDirectories(DirectoryInfo dir)
        {
            MkDir(dir, @"\res");
            MkDir(dir, @"\res\drawable-hdpi");
            MkDir(dir, @"\res\drawable-ldpi");
            MkDir(dir, @"\res\drawable-mdpi");
            MkDir(dir, @"\res\drawable-xhdpi");
            MkDir(dir, @"\res\drawable-xxhdpi");
            MkDir(dir, @"\res\drawable-xxxhdpi");
        }

        private static void MkDir(DirectoryInfo basedir, string subdir)
        {
            string dir = basedir.FullName + subdir;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private static void ResizeFile(FileInfo file)
        {
            Console.WriteLine("Resizing {0}", file);
        }
    }
}
