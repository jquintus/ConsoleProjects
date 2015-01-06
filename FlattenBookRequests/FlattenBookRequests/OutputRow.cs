using CsvHelper.Configuration;

namespace FlattenBookRequests
{
    public class OutputRow
    {
        public string Address { get; set; }

        public string Address2 { get; set; }

        public string BlogURL { get; set; }

        public string Book { get; set; }

        public string City { get; set; }

        public string EMailAddress { get; set; }

        public string Name { get; set; }

        public string NetGalleyEMailAddress { get; set; }

        public string State { get; set; }

        public string Timestamp { get; set; }

        public string ZipCode { get; set; }
    }

    public class OutputRowMap : CsvClassMap<OutputRow>
    {
        public OutputRowMap()
        {
            Map(m => m.Name).Name("Name (First and Last)");
            Map(m => m.Address2).Name("Address 2 (Apt #, Floor, etc)");
            Map(m => m.ZipCode).Name("Zip Code");
            Map(m => m.BlogURL).Name("Blog URL");
            Map(m => m.EMailAddress).Name("E-Mail Address");
            Map(m => m.NetGalleyEMailAddress).Name("NetGalley E-Mail Address");
        }
    }
}