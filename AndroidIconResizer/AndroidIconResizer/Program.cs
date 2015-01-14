using ImageMagick;
using System;
using System.IO;

namespace AndroidIconResizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = CommandLineOption.Read(args);
            if (null == options) return;

            MakeDestinationDirectories(options.OutputDir);

            var files = options.InputDir.GetFiles("*.png");
            foreach (var file in files)
            {
                ResizeFile(options.OutputDir, file, options.Size);
            }
        }

        private static void MakeDestinationDirectories(DirectoryInfo dir)
        {
            MkDir(dir, @"\res");

            foreach (var size in ImageSize.Sizes)
            {
                MkDir(dir, @"\res\" + size.Name);
            }
        }

        private static void MkDir(DirectoryInfo basedir, string subdir)
        {
            string dir = basedir.FullName + subdir;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private static void ResizeFile(DirectoryInfo outputDir, FileInfo inputFile, int size)
        {
            Console.WriteLine("Resizing {0}", inputFile);

            foreach (var imageSize in ImageSize.Sizes)
            {
                FileInfo outputFile = new FileInfo(Path.Combine(outputDir.FullName,"res", imageSize.Name, inputFile.Name));
                using (var image = new MagickImage(inputFile))
                {
                    int newSize = (int)(size * imageSize.Ratio);
                    image.Resize(newSize, newSize);
                    image.Write(outputFile);
                }
            }
        }
    }
}