using System;
using System.Collections.Generic;
using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Configurations
{
    public interface IPropertyResolvingStrategy
    {
        IEnumerable<PropertyInfo> GetProperties(Type type, ICrawlToken crawlToken);
    }
}