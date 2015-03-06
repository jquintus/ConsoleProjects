using System.Xml.Serialization;

namespace PubProfileToFilezilla
{
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class FileZilla3
    {
        public FileZilla3Servers Servers { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class FileZilla3Servers
    {
        public FileZilla3ServersServer Server { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class FileZilla3ServersServer
    {
        public int BypassProxy { get; set; }
        public string Comments { get; set; }
        public string EncodingType { get; set; }
        public string Host { get; set; }
        public string LocalDir { get; set; }
        public int Logontype { get; set; }
        public int MaximumMultipleConnections { get; set; }
        public string Name { get; set; }
        public FileZilla3ServersServerPass Pass { get; set; }
        public string PasvMode { get; set; }
        public int Port { get; set; }
        public int Protocol { get; set; }
        public string RemoteDir { get; set; }
        public int SyncBrowsing { get; set; }
        public int TimezoneOffset { get; set; }
        public int Type { get; set; }
        public string User { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class FileZilla3ServersServerPass
    {
        [XmlAttributeAttribute()]
        public string encoding { get; set; }
        [XmlTextAttribute()]
        public string Value { get; set; }
    }
}
