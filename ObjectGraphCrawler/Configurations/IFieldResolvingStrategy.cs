using System;
using System.Collections.Generic;
using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Configurations
{
    public interface IFieldResolvingStrategy
    {
        IEnumerable<FieldInfo> GetFields(Type type, ICrawlToken crawlToken);
    }
}