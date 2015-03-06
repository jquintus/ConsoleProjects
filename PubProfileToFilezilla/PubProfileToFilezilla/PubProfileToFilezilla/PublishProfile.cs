using System.Xml.Serialization;

namespace PubProfileToFilezilla
{
    public enum PublishMethod
    {
        FTP,
        MSDeploy,
    }

    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class publishData
    {
        [XmlElementAttribute("publishProfile")]
        public publishDataPublishProfile[] publishProfile { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class publishDataPublishProfile
    {
        [XmlAttributeAttribute()]
        public string controlPanelLink { get; set; }

        [XmlAttributeAttribute()]
        public string destinationAppUrl { get; set; }

        [XmlAttributeAttribute()]
        public string ftpPassiveMode { get; set; }

        [XmlAttributeAttribute()]
        public string hostingProviderForumLink { get; set; }

        [XmlAttributeAttribute()]
        public string msdeploySite { get; set; }

        [XmlAttributeAttribute()]
        public string profileName { get; set; }

        [XmlAttributeAttribute()]
        public PublishMethod publishMethod { get; set; }

        [XmlAttributeAttribute()]
        public string publishUrl { get; set; }

        [XmlAttributeAttribute()]
        public string SQLServerDBConnectionString { get; set; }

        [XmlAttributeAttribute()]
        public string userName { get; set; }

        [XmlAttributeAttribute()]
        public string userPWD { get; set; }

        [XmlAttributeAttribute()]
        public string webSystem { get; set; }
    }
}