using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PubProfileToFilezilla
{
    public class ProfileReader
    {


        public publishData Read(string path)
        {
            using (var reader = new FileStream(path, FileMode.Open))
            {
                return Read(reader);
            }
        }

        public publishData Read(Stream s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(publishData));

            var profile = serializer.Deserialize(s);
            return profile as publishData;
        }
    }
}
