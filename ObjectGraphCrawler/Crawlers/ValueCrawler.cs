using System;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Crawlers
{
    class ValueCrawler : ICrawler
    {
        private readonly object _value;
        private readonly Type _type;
        private readonly ICrawlToken _parentToken;
        private readonly ObjectCrawler _objectCrawler;

        public ValueCrawler(object value, Type type, ICrawlToken parentToken, ObjectCrawler objectCrawler)
        {
            _value = value;
            _type = type;
            _parentToken = parentToken;
            _objectCrawler = objectCrawler;
        }
        public void Crawl()
        {
            ValueToken token = new ValueToken(_parentToken,_type,_value);
            _objectCrawler.AcceptVisitors(token);
        }
    }
}