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
                ResizeFile(options, file);
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

        private static void ResizeFile(CommandLineOption options, FileInfo inputFile)
        {
            Console.WriteLine("Resizing {0}", inputFile);

            foreach (var imageSize in ImageSize.Sizes)
            {
                FileInfo outputFile = new FileInfo(Path.Combine(options.OutputDir.FullName, "res", imageSize.Name, inputFile.Name));
                using (var image = new MagickImage(inputFile))
                {
                    int newWidth = (int)(options.OutputWidth * imageSize.Ratio);
                    int newHeight = (int)(options.OutputHeight * imageSize.Ratio);
                    image.Resize(newWidth, newHeight);
                    image.Write(outputFile);
                }
            }
        }
    }
}