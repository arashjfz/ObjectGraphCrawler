using System;
using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Crawlers
{
    public class ReferenceCrawler : ICrawler
    {
        private readonly object _value;
        private readonly Type _type;
        private readonly ICrawlToken _parentToken;
        private readonly ObjectCrawler _objectCrawler;

        public ReferenceCrawler(object value, Type type, ICrawlToken parentToken, ObjectCrawler objectCrawler)
        {
            _value = value;
            _type = type;
            _parentToken = parentToken;
            _objectCrawler = objectCrawler;
        }

        public void Crawl()
        {
            ReferenceToken token = new ReferenceToken(_parentToken, _type, _value);
            _objectCrawler.AcceptVisitors(token);
            if(token.IgnoreCrawl)
                return;
            CrawlProperties(token);
            CrawlFields(token);
        }

        private void CrawlProperties(ReferenceToken token)
        {
            foreach (PropertyInfo propertyInfo in _objectCrawler.Configuration.PropertyResolver.GetProperties(_type, token))
            {
                PropertyCrawler crawler = new PropertyCrawler(_value,propertyInfo,token,_objectCrawler);
                crawler.Crawl();
            }
        }

        private void CrawlFields(ReferenceToken token)
        {
            foreach (FieldInfo fieldInfo in _objectCrawler.Configuration.FieldResolver.GetFields(_type, token))
            {
                FieldCrawler crawler = new FieldCrawler(_value, fieldInfo, token, _objectCrawler);
                crawler.Crawl();
            }
        }
    }
}