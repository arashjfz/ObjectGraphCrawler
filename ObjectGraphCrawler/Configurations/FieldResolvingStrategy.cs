using System;
using System.Collections.Generic;
using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Configurations
{
    public class FieldResolvingStrategy: IFieldResolvingStrategy
    {
        public virtual IEnumerable<FieldInfo> GetFields(Type type, ICrawlToken crawlToken)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.NonPublic|BindingFlags.Instance);
        }
    }
}