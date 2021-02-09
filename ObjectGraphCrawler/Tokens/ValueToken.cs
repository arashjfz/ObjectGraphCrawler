using System;

namespace ObjectGraphCrawler.Tokens
{
    public class ValueToken : CrawlToken
    {
        public Type Type { get; }
        public object Value => GetValue();
        private readonly object _value;

        public ValueToken(ICrawlToken parent, Type type, object value) : base(parent)
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
            visitor.VisitValue(this);
        }
    }
}