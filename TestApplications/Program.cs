using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitemapBuilder.Model;

namespace TestApplications
{
    class Program
    {
        static void Main(string[] args)
        {
            SitemapBuilder.SitemapBuilder.GenerateSitemapXml(
                new SitemapEntry(),
                new SitemapEntry("1"),
                new SitemapEntry("2"),
                new SitemapEntry("2"),
                new SitemapEntry("3"),
                new SitemapEntry("4", DateTime.Now, ChangeFrequencyEnum.Hourly, 0.5),
                new SitemapEntry("5", DateTime.Now, ChangeFrequencyEnum.Weekly)
            );

            Stream s = SitemapBuilder.SitemapBuilder.GenerateSitemapStream(
                new SitemapEntry(),
                new SitemapEntry("1"),
                new SitemapEntry("2"),
                new SitemapEntry("2"),
                new SitemapEntry("3"),
                new SitemapEntry("4", DateTime.Now, ChangeFrequencyEnum.Hourly, 0.5),
                new SitemapEntry("5", DateTime.Now, ChangeFrequencyEnum.Weekly)
            );
        }
    }
}
