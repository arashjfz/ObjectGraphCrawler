using System.Reflection;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Crawlers
{
    public class FieldCrawler : ICrawler
    {
        private readonly object _declaringValue;
        private readonly FieldInfo _field;
        private readonly ICrawlToken _parentToken;
        private readonly ObjectCrawler _objectCrawler;

        public FieldCrawler(object declaringValue, FieldInfo field,ICrawlToken parentToken,ObjectCrawler objectCrawler)
        {
            _declaringValue = declaringValue;
            _field = field;
            _parentToken = parentToken;
            _objectCrawler = objectCrawler;
        }
        public void Crawl()
        {
            FieldToken token = new FieldToken(_parentToken,_field,() => _field.GetValue(_declaringValue),o => _field.SetValue(_declaringValue, o));
            _objectCrawler.AcceptVisitors(token);
            if (token.IgnoreCrawl)
                return;
            _objectCrawler.Crawl(token.Field.FieldType, token, token.Value);
        }
    }
}