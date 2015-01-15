using CommandLine;
using CommandLine.Text;
using System.IO;

namespace AndroidIconResizer
{
    public class CommandLineOptions
    {
        [Option("include-xxxhdpi", DefaultValue = false, HelpText = "Include an xxxhdpi sized image.  Note that google only suggests this for launcher icons.  (http://developer.android.com/guide/practices/screens_support.html#xxxhdpi-note)")]
        public bool IncludeXxxhdpi { get; set; }

        public DirectoryInfo InputDir { get; set; }

        [Option('i', "input-dir", DefaultValue = ".", HelpText = "Location of the images to process.  Default value:  current directory.")]
        public string InputDirString
        {
            get { return InputDir.FullName; }
            set { InputDir = new DirectoryInfo(value); }
        }

        public FileInfo InputFile { get; set; }

        [Option('f', "file", HelpText = "A single file to process.  If present, this overwrites input-dir")]
        public string InputFileString
        {
            get { return InputFile.FullName; }
            set { InputFile = new FileInfo(value); }
        }

        public DirectoryInfo OutputDir { get; set; }

        [Option('o', "output-dir", DefaultValue = ".", HelpText = "Location of the output directory.  Default value:  current directory.")]
        public string OutputDirString
        {
            get { return OutputDir.FullName; }
            set { OutputDir = new DirectoryInfo(value); }
        }

        [Option('h', "height", DefaultValue = 100, HelpText = "The height of the output image in pixels in the MDPI folder.")]
        public int OutputHeight { get; set; }

        [Option('w', "width", DefaultValue = 100, HelpText = "The width of the output image in pixels in the MDPI folder.")]
        public int OutputWidth { get; set; }

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