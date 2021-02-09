using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Crawlers
{
    public class PropertyCrawler:ICrawler
    {
        private readonly object _declaringValue;
        private readonly PropertyInfo _property;
        private readonly ICrawlToken _parentToken;
        private readonly ObjectCrawler _objectCrawler;

        public PropertyCrawler(object declaringValue, PropertyInfo property,ICrawlToken parentToken,ObjectCrawler objectCrawler)
        {
            _declaringValue = declaringValue;
            _property = property;
            _parentToken = parentToken;
            _objectCrawler = objectCrawler;
        }
        public void Crawl()
        {
            PropertyToken token = new PropertyToken(_parentToken,_property,() => _property.GetValue(_declaringValue),o => _property.SetValue(_declaringValue, o));
            _objectCrawler.AcceptVisitors(token);
            if (token.IgnoreCrawl)
                return;
            _objectCrawler.Crawl(token.Property.PropertyType,token,token.Value);
        }
    }
}