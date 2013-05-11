using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SitemapBuilder.Model;

namespace SitemapBuilder
{
    public sealed class SitemapBuilder
    {
        public static void GenerateSitemapXml(params SitemapEntry[] entries)
        {
            if (entries.Length == 0) return;

            var options = SitemapOptions.GetDefaults();

            var container = new SitemapContainer();
            container.AddEntries(entries);

            var serializer = new XmlSerializer(typeof(SitemapContainer));
            serializer.Serialize(new XmlTextWriter(options.SitemapXmlName, options.Encoding), container);
        }

        public static Stream GenerateSitemapStream(params SitemapEntry[] entries)
        {
            if (entries.Length == 0) return null;

            var container = new SitemapContainer();
            container.AddEntries(entries);

            Stream stream = new MemoryStream();

            var serializer = new XmlSerializer(typeof(SitemapContainer));
            serializer.Serialize(stream, container);
            return stream;
        }
    }
}