using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ObjectGraphCrawler.Configurations;
using ObjectGraphCrawler.Crawlers;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler
{
    public class ObjectCrawler
    {
        public IObjectCrawlerConfiguration Configuration { get; }
        private readonly IList<IObjectGraphVisitor> _visitors = new List<IObjectGraphVisitor>();
        private readonly HashSet<object> _crawledItems;
        public ObjectCrawler(IObjectCrawlerConfiguration configuration)
        {
            _crawledItems = new HashSet<object>(new ReferenceEqualityComparer());
            Configuration = configuration;
        }

        public ObjectCrawler()
        : this(new ObjectCrawlerConfiguration())
        {

        }

        public void Crawl(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Crawl(value.GetType(), null, value);
        }

        public void AddVisitor(IObjectGraphVisitor visitor)
        {
            _visitors.Add(visitor);
        }

        internal void AcceptVisitors(ICrawlToken token)
        {
            foreach (IObjectGraphVisitor visitor in _visitors)
                token.Accept(visitor);
        }

        internal void Crawl(Type type, ICrawlToken token, object value)
        {
            if (_crawledItems.Contains(value))
                return;
            _crawledItems.Add(value);
            CrawlingType crawlingType = Configuration.CrawlingTypeDetection.DetectType(type, token);
            ICrawler crawler;
            switch (crawlingType)
            {
                case CrawlingType.Reference:
                    crawler = new ReferenceCrawler(value, type, token, this);
                    break;
                case CrawlingType.Value:
                    crawler = new ValueCrawler(value, type, token, this);
                    break;
                case CrawlingType.Enumerable:
                    crawler = new EnumerableCrawler(value, type, token, this);
                    break;
                case CrawlingType.Dictionary:
                    crawler = new DictionaryCrawler(value, type, token, this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            crawler.Crawl();
        }
    }
    internal class ReferenceEqualityComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}
