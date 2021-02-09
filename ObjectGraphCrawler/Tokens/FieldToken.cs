using System;
using System.Reflection;

namespace ObjectGraphCrawler.Tokens
{
    public class FieldToken : CrawlToken
    {
        private readonly Func<object> _valueResolver;
        private readonly Action<object> _valueApplier;
        public FieldInfo Field { get; }

        public FieldToken(ICrawlToken parent, FieldInfo field, Func<object> valueResolver, Action<object> valueApplier) : base(parent)
        {
            _valueResolver = valueResolver;
            _valueApplier = valueApplier;
            Field = field;
        }

        protected override object GetValue()
        {
            return _valueResolver();
        }
        public object Value
        {
            get => GetValue();
            set => _valueApplier(value);
        }

        public override void Accept(IObjectGraphVisitor visitor)
        {
            visitor.VisitField(this);
        }
    }
}