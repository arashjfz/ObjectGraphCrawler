using System;
using System.Collections;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Crawlers
{
    class DictionaryCrawler : ICrawler
    {
        private readonly object _value;
        private readonly Type _type;
        private readonly ICrawlToken _parentToken;
        private readonly ObjectCrawler _objectCrawler;

        public DictionaryCrawler(object value, Type type, ICrawlToken parentToken, ObjectCrawler objectCrawler)
        {
            _value = value;
            _type = type;
            _parentToken = parentToken;
            _objectCrawler = objectCrawler;
        }
        public void Crawl()
        {
            DictionaryToken token = new DictionaryToken(_parentToken,_type,_value);
            _objectCrawler.AcceptVisitors(token);
            if(token.IgnoreCrawl)
                return;
            IDictionary dictionary = (IDictionary)_value;

            foreach (object key in dictionary.Keys)
            {
                _objectCrawler.Crawl(key.GetType(),token,key);
                var value = dictionary[key];
                _objectCrawler.Crawl(key.GetType(), token, value);
            }
        }
    }
}