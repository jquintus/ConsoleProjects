using ImageMagick;
using System;
using System.IO;

namespace AndroidIconResizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = CommandLineOptions.Read(args);
            if (null == options) return;

            MakeDestinationDirectories(options);

            var files = GetFiles(options);
            foreach (var file in files)
            {
                ResizeFile(options, file);
            }
        }

        private static FileInfo[] GetFiles(CommandLineOptions options)
        {
            if (options.InputFile != null)
            {
                return new FileInfo[] { options.InputFile };
            }
            else
            {
                return options.InputDir.GetFiles("*.png");
            }
        }

        private static void MakeDestinationDirectories(CommandLineOptions options)
        {
            MkDir(options.OutputDir.FullName, "res");

            foreach (var size in ImageSize.GetSizes(options))
            {
                MkDir(options.OutputDir.FullName, "res", size.Name);
            }
        }

        private static void MkDir(params string[] paths)
        {
            var dir = Path.Combine(paths);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private static void ResizeFile(CommandLineOptions options, FileInfo inputFile)
        {
            Console.WriteLine("Resizing {0}", inputFile);

            foreach (var imageSize in ImageSize.GetSizes(options))
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