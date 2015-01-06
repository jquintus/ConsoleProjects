using CsvHelper.Configuration;

namespace FlattenBookRequests
{
    public class InputRow
    {
        public string Address { get; set; }

        public string Address2 { get; set; }

        public string BlogURL { get; set; }

        public string City { get; set; }

        public string EMailAddress { get; set; }

        public string MiddleGrade { get; set; }

        public string Name { get; set; }

        public string NetGalleyEMailAddress { get; set; }

        public string PictureBooks { get; set; }

        public string State { get; set; }

        public string Timestamp { get; set; }

        public string YoungAdult { get; set; }

        public string ZipCode { get; set; }
    }

    public class InputRowMap : CsvClassMap<InputRow>
    {
        public InputRowMap()
        {
            Map(m => m.Name).Name("Name (First and Last)");
            Map(m => m.Address2).Name("Address 2 (Apt #, Floor, etc)");
            Map(m => m.Timestamp).Name("Timestamp");
            Map(m => m.State).Name("State");
            Map(m => m.City).Name("City");
            Map(m => m.Address).Name("Address");
            Map(m => m.ZipCode).Name("Zip Code");
            Map(m => m.BlogURL).Name("Blog URL");
            Map(m => m.EMailAddress).Name("E-Mail Address");
            Map(m => m.NetGalleyEMailAddress).Name("NetGalley E-Mail Address");
            Map(m => m.PictureBooks).Name("Picture Books");
            Map(m => m.MiddleGrade).Name("Middle Grade");
            Map(m => m.YoungAdult).Name("Young Adult");
        }
    }
}