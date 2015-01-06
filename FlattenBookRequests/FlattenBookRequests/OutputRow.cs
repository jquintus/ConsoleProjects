using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlattenBookRequests
{
    public class OutputRow
    {
        public OutputRow()
        {
        }

        public OutputRow(InputRow r, string book)
        {
            Book = book.Trim();
            Address = r.Address;
            Address2 = r.Address2;
            BlogURL = r.BlogURL;
            City = r.City;
            EMailAddress = r.EMailAddress;
            Name = r.Name;
            NetGalleyEMailAddress = r.NetGalleyEMailAddress;
            State = r.State;
            Timestamp = r.Timestamp;
            ZipCode = r.ZipCode;
        }

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

        #region Converters

        public static IEnumerable<OutputRow> ConvertFromInput(IEnumerable<InputRow> requests)
        {
            return requests.SelectMany(r => ConvertFromInput(r));
        }

        public static IEnumerable<OutputRow> ConvertFromInput(InputRow r)
        {
            var middles = r.MiddleGrade.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var book in middles)
            {
                yield return new OutputRow(r, book);
            }

            var yas = r.YoungAdult.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var book in yas)
            {
                yield return new OutputRow(r, book);
            }

            var pictures = r.PictureBooks.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var book in pictures)
            {
                yield return new OutputRow(r, book);
            }
        }

        #endregion Converters
    }

    public class OutputRowMap : CsvClassMap<OutputRow>
    {
        public OutputRowMap()
        {
            Map(m => m.Timestamp).Name("Timestamp");
            Map(m => m.Name).Name("Name (First and Last)");
            Map(m => m.Address).Name("Address");
            Map(m => m.Address2).Name("Address 2 (Apt #, Floor, etc)");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.ZipCode).Name("Zip Code");
            Map(m => m.BlogURL).Name("Blog URL");
            Map(m => m.EMailAddress).Name("E-Mail Address");
            Map(m => m.NetGalleyEMailAddress).Name("NetGalley E-Mail Address");
            Map(m => m.Book).Name("Book");
        }
    }
}