using System;
using System.IO;
using System.Linq;

namespace AndroidResourceChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = CommandLineOptions.Read(args);
            if (null == options) return;

            if (!options.ResouceDir.Exists)
            {
                Error("Directory does not exist:  {0}", options.ResouceDir.FullName);
                return;
            }

            Verify(options.ResouceDir);
        }

        public static void Verify(DirectoryInfo dir)
        {
            var sizes = Enum.GetValues(typeof(DrawableFolders)).Cast<DrawableFolders>();
            var resources = FindResourceDirectory(dir);
            if (resources == null) return;

            var folders = sizes.Select(s => new DrawableFolder(resources, s));

            foreach (var missing in folders.Where(f => !f.Exists && f.WarnIfMissing))
            {
                Warn("Missing drawable folder {0}", missing.ToString());
            }
            foreach (var error in DrawableFolder.FindErrors(folders))
            {
                Warn(error.ToString());
            }
        }

        private static void Error(string format, params string[] args)
        {
            Write(ConsoleColor.Red, format, args);
        }

        private static DirectoryInfo FindResourceDirectory(DirectoryInfo dir)
        {
            DirectoryInfo subDir = dir.GetDirectories("drawable", SearchOption.AllDirectories)
                                      .Where(d => d.Name == "drawable")
                                      .OrderBy(d => d.FullName.Length)
                                      .FirstOrDefault();
            if (subDir == null)
            {
                Error("Could not find drawable folders in {0}", dir.FullName);
                return null;
            }

            return subDir.Parent;
        }

        private static bool In(string search, params string[] list)
        {
            foreach (var item in list)
            {
                if (string.Compare(search, item, true) == 0) return true;
            }
            return false;
        }

        private static void Warn(string format, params string[] args)
        {
            Write(ConsoleColor.Yellow, format, args);
        }

        private static void Write(ConsoleColor fore, string format, params string[] args)
        {
            Write(fore, Console.BackgroundColor, format, args);
        }

        private static void Write(ConsoleColor fore, ConsoleColor back, string format, params string[] args)
        {
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;
            try
            {
                Console.BackgroundColor = back;
                Console.ForegroundColor = fore;
                Write(format, args);
            }
            finally
            {
                Console.BackgroundColor = currentBackground;
                Console.ForegroundColor = currentForeground;
            }
        }

        private static void Write(string format, params string[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}