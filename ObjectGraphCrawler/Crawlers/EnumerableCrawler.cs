using System;
using System.Collections;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Crawlers
{
    class EnumerableCrawler : ICrawler
    {
        private readonly object _value;
        private readonly Type _type;
        private readonly ICrawlToken _parentToken;
        private readonly ObjectCrawler _objectCrawler;

        public EnumerableCrawler(object value, Type type, ICrawlToken parentToken, ObjectCrawler objectCrawler)
        {
            _value = value;
            _type = type;
            _parentToken = parentToken;
            _objectCrawler = objectCrawler;
        }
        public void Crawl()
        {
            EnumerableToken token = new EnumerableToken(_parentToken,_type,_value);
            _objectCrawler.AcceptVisitors(token);
            if(token.IgnoreCrawl)
                return;
            foreach (var item in (IEnumerable)_value)
            {
                if(item == null)
                    continue;
                _objectCrawler.Crawl(item.GetType(), token, item);
            }
        }
    }
}