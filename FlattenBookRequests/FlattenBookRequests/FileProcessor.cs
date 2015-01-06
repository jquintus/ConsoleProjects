using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlattenBookRequests
{
    public class FileProcessor
    {
        public void Process(string input, string output)
        {
            using (var textReader = new StreamReader(input))
            using (var reader = new CsvReader(textReader))
            using (var textWriter = new StreamWriter(output))
            using (var writer = new CsvWriter(textWriter))
            {
                ConfigureCsv(reader.Configuration);
                ConfigureCsv(writer.Configuration);

                reader.Configuration.RegisterClassMap<InputRowMap>();
                writer.Configuration.RegisterClassMap<OutputRowMap>();

                var requests = reader.ReadAll<InputRow>();
                IEnumerable<OutputRow> outputRows = OutputRow.ConvertFromInput(requests);
                writer.WriteHeader<OutputRow>();
                writer.WriteRecords(outputRows.OrderBy(r => r.Book));
            }
        }

        private static void ConfigureCsv(CsvHelper.Configuration.CsvConfiguration csv)
        {
            csv.HasHeaderRecord = true;
            csv.IgnoreBlankLines = true;
            csv.IgnoreHeaderWhiteSpace = true;
            csv.SkipEmptyRecords = true;
            csv.TrimFields = true;
            csv.IgnoreHeaderWhiteSpace = false;
        }
    }
}