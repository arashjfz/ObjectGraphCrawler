using System;
using System.Collections.Generic;
using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Configurations
{
    public class PropertyResolvingStrategy: IPropertyResolvingStrategy
    {
        public virtual IEnumerable<PropertyInfo> GetProperties(Type type, ICrawlToken crawlToken)
        {
            return type.GetProperties();
        }
    }
}