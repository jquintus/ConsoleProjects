using System.IO;
using System.Xml.Serialization;

namespace PubProfileToFilezilla
{
    public class FileZillaWriter
    {
        public void Write(FileZilla3 zilla, string path)
        {
            using (var s = new FileStream(path, FileMode.OpenOrCreate))
            {
                Write(zilla, s);
            }
        }

        public void Write(FileZilla3 zilla, Stream s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FileZilla3));

            serializer.Serialize(s, zilla);
        }
    }
}