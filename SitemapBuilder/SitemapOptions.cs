using System;
using System.Text;

namespace SitemapBuilder
{
    public class SitemapOptions
    {
        public String SitemapXmlName { get; set; }
        public Encoding Encoding { get; set; }

        public static SitemapOptions GetDefaults()
        {
            return new SitemapOptions
                       {
                           SitemapXmlName = "sitemap.xml",
                           Encoding = Encoding.UTF8
                       };
        }
    }
}