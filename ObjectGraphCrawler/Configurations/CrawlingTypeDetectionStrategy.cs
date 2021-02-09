using System;
using System.Collections;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Configurations
{
    public class CrawlingTypeDetectionStrategy: ICrawlingTypeDetectionStrategy
    {
        private bool IsNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        private bool IsValue(Type type)
        {
            return type.IsValueType || type == typeof(string) || IsNullable(type);
        }
        public virtual CrawlingType DetectType(Type type, ICrawlToken token)
        {
            if (IsValue(type))
                return CrawlingType.Value;
            if (typeof(IDictionary).IsAssignableFrom(type))
                return CrawlingType.Dictionary;
            if (typeof(IEnumerable).IsAssignableFrom(type))
                return CrawlingType.Enumerable;
            return CrawlingType.Reference;
        }
    }
}