using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SitemapBuilder.Model
{
    [XmlRoot(ElementName = "urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapContainer
    {
        public SitemapContainer()
        {
            Entries = new List<SitemapEntry>();
        }
        
        [XmlElement(ElementName = "url", IsNullable = false)]
        public List<SitemapEntry> Entries { get; set; }

        public bool AddEntry(SitemapEntry entry)
        {
            if (!string.IsNullOrEmpty(entry.Location) && Entries.All(e => e.Location != entry.Location))
            {
                Entries.Add(entry);
                return true;
            }

            return false;
        }

        public void AddEntries(params SitemapEntry[] entries)
        {
            foreach (var sitemapEntry in entries)
            {
                AddEntry(sitemapEntry);
            }
        }

        public SitemapEntry this[int index]
        {
            get { return Entries[index]; }
        }

        public SitemapEntry this[string key]
        {
            get { return Entries.FirstOrDefault(e => e.Location == key); }
        }
    }
}