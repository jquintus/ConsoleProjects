using CommandLine;
using CommandLine.Text;
using System.IO;

namespace AndroidIconResizer
{
    public class CommandLineOption
    {
        public DirectoryInfo InputDir { get; set; }

        [Option('i', "input-dir", DefaultValue = ".", HelpText = "Location of the images to process.  Default value:  current directory.")]
        public string InputDirString
        {
            get { return InputDir.FullName; }
            set { InputDir = new DirectoryInfo(value); }
        }

        public DirectoryInfo OutputDir { get; set; }

        [Option('o', "output-dir", DefaultValue = ".", HelpText = "Location of the output directory.  Default value:  current directory.")]
        public string OutputDirString
        {
            get { return OutputDir.FullName; }
            set { OutputDir = new DirectoryInfo(value); }
        }

        [Option('h', "height", DefaultValue = 100, HelpText = "The height of the output image in pixels in the MDPI folder.  Default value:  100")]
        public int OutputHeight { get; set; }

        [Option('w', "width", DefaultValue = 100, HelpText = "The width of the output image in pixels in the MDPI folder.  Default value:  100")]
        public int OutputWidth { get; set; }

        public static CommandLineOption Read(string[] args)
        {
            var options = new CommandLineOption();
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