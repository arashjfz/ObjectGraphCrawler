using System;

namespace ObjectGraphCrawler.Tokens
{
    public class DictionaryToken : CrawlToken
    {
        public Type Type { get; }
        public object Value => GetValue();
        private readonly object _value;

        public DictionaryToken(ICrawlToken parent, Type type, object value) : base(parent)
        {
            Type = type;
            _value = value;
        }

        protected override object GetValue()
        {
            return _value;
        }


        public override void Accept(IObjectGraphVisitor visitor)
        {
            visitor.VisitDictionary(this);
        }
    }
}