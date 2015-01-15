using System;
using System.IO;
using System.Linq;

namespace AndroidResourceChecker
{
    public class Program
    {
        private static int _errors;
        private static int _warnings;

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
                Warn("Missing drawable folder {0}", missing);
            }
            foreach (var error in DrawableFolder.FindErrors(folders))
            {
                Warn(error.ToString());
            }

            if (_warnings == 0 && _errors == 0)
            {
                Write("Success");
            }
            else
            {
                Write(string.Empty);
                Write("Completed with");
                Error("    {0} error(s)", _errors);
                 Warn("    {0} warnings(s)", _warnings);
            }
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

        #region Logging

        private static void Error(string format, params object[] args)
        {
            Write(ConsoleColor.Red, format, args);
        }

        private static void Warn(string format, params object[] args)
        {
            _warnings++;
            Write(ConsoleColor.Yellow, format, args);
        }

        private static void Write(ConsoleColor fore, string format, params object[] args)
        {
            Write(fore, Console.BackgroundColor, format, args);
        }

        private static void Write(ConsoleColor fore, ConsoleColor back, string format, params object[] args)
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

        private static void Write(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        #endregion Logging
    }
}