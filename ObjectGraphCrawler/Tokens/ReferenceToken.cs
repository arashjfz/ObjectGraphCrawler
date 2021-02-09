using System;

namespace ObjectGraphCrawler.Tokens
{
    public class ReferenceToken : CrawlToken
    {
        public Type Type { get; }
        public object Value => GetValue();
        private readonly object _value;

        public ReferenceToken(ICrawlToken parent, Type type, object value) : base(parent)
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
            visitor.VisitReference(this);
        }
    }
}