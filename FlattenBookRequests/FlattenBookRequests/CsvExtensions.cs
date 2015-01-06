using CsvHelper;
using System.Collections.Generic;

namespace FlattenBookRequests
{
    public static class CsvExtensions
    {
        public static IEnumerable<T> ReadAll<T>(this CsvReader csv)
        {
            while (csv.Read())
            {
                yield return csv.GetRecord<T>();
            }
        }
    }
}