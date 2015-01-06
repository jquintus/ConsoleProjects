using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenBookRequests
{
    public class FileProcessor
    {
        public void Process(string input, string output)
        {

            using (var textReader = new StreamReader(input))
            using (CsvReader reader = new CsvReader(textReader))
            {
                reader.Configuration.HasHeaderRecord = true;
                reader.Configuration.IgnoreBlankLines = true;
                reader.Configuration.IgnoreHeaderWhiteSpace = true;
                reader.Configuration.SkipEmptyRecords = true;
                reader.Configuration.TrimFields = true;
                reader.Configuration.IgnoreHeaderWhiteSpace = false;
                
                reader.Configuration.RegisterClassMap<InputRowMap>();


                var requests = reader.ReadAll<InputRow>();

                foreach (var req in requests)
                {
                    Console.WriteLine(req.Name);
                }

            }
        }
    }
}
