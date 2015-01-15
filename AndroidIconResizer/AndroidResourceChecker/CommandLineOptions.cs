using CommandLine;
using CommandLine.Text;
using System.IO;

namespace AndroidResourceChecker
{
    public class CommandLineOptions
    {
        public DirectoryInfo ResouceDir { get; set; }

        [Option('r', "resource-dir", DefaultValue = ".", HelpText = "Location of the resource directory")]
        public string ResouceDirString
        {
            get { return ResouceDir.FullName; }
            set { ResouceDir = new DirectoryInfo(value); }
        }

        public static CommandLineOptions Read(string[] args)
        {
            var options = new CommandLineOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                return options;
            }
            else
            {
                return null;
            }
        }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}