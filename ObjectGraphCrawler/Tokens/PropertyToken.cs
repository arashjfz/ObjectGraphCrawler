using System;
using System.Reflection;

namespace ObjectGraphCrawler.Tokens
{
    public class PropertyToken : CrawlToken
    {
        private readonly Func<object> _valueResolver;
        private readonly Action<object> _valueApplier;
        public PropertyInfo Property { get; }

        public PropertyToken(ICrawlToken parent, PropertyInfo property, Func<object> valueResolver, Action<object> valueApplier) : base(parent)
        {
            _valueResolver = valueResolver;
            _valueApplier = valueApplier;
            Property = property;
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
            visitor.VisitProperty(this);
        }
    }
}