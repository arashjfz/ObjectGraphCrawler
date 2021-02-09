using System;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Configurations
{
    public interface ICrawlingTypeDetectionStrategy
    {
        CrawlingType DetectType(Type type, ICrawlToken token);
    }
}