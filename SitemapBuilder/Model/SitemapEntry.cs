using System;
using System.Xml.Serialization;

namespace SitemapBuilder.Model
{
    public class SitemapEntry
    {
        public SitemapEntry()
        {
            LastModified = null;
            ChangeFrequency = null;
            Priority = null;
        }

        public SitemapEntry(string url)
        {
            Location = url;
        }

        public SitemapEntry(string url, DateTime lastModified, ChangeFrequencyEnum changeFrequency)
        {
            Location = url;
            LastModified = lastModified.ToString("yyyy-MM-dd");
            ChangeFrequency = changeFrequency.ToString().ToLower();
        }

        public SitemapEntry(string url, DateTime lastModified, ChangeFrequencyEnum changeFrequency, double priority)
        {
            Location = url;
            LastModified = lastModified.ToString("yyyy-MM-dd");
            ChangeFrequency = changeFrequency.ToString().ToLower();
            if (priority < 0 || priority > 1) priority = 0.5;
            Priority = System.Math.Round(priority, 1).ToString().Replace(",", ".");
        }

        [XmlElement(ElementName = "loc")]
        public string Location { get; set; }

        [XmlElement(ElementName = "lastmod")]
        public string LastModified { get; set; }

        [XmlElement(ElementName = "changefreq")]
        public string ChangeFrequency { get; set; }

        [XmlElement(ElementName = "priority")]
        public string Priority { get; set; }
    }
}