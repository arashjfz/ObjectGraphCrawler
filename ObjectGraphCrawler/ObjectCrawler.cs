using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ObjectGraphCrawler
{
    public class ObjectCrawler
    {
        private readonly IObjectCrawlerConfiguration _configuration;
        private IList<IObjectGraphVisitor> _visitors = new List<IObjectGraphVisitor>();
        public ObjectCrawler(IObjectCrawlerConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Crawl(object value)
        {
            var type = value.GetType();
        }

        public void AddVisitor(IObjectGraphVisitor visitor)
        {
            _visitors.Add(visitor);
        }

        private void AcceptVisitors(ICrawlToken token)
        {
            foreach (IObjectGraphVisitor visitor in _visitors)
                token.Accept(visitor);
        }

    }


    public interface IFieldResolvingStrategy
    {
        IEnumerable<FieldInfo> GetFields(Type type, ICrawlToken crawlToken);
    }
    public interface IPropertyResolvingStrategy
    {
        IEnumerable<PropertyInfo> GetProperties(Type type, ICrawlToken crawlToken);
    }

    public interface IObjectCrawlerConfiguration
    {
        IFieldResolvingStrategy FieldResolver { get; }
        IPropertyResolvingStrategy PropertyResolver { get; }
    }


    public interface ICrawlToken
    {
        ICrawlToken Parent { get; }
        object Value { get; }
        void Accept(IObjectGraphVisitor visitor);
    }
    public abstract class CrawlToken : ICrawlToken
    {
        protected CrawlToken(ICrawlToken parent)
        {
            Parent = parent;
        }

        public ICrawlToken Parent { get; }
        object ICrawlToken.Value => GetValue();
        protected abstract object GetValue();
        public abstract void Accept(IObjectGraphVisitor visitor);
    }
    public class ReferenceToken : CrawlToken
    {
        private readonly object _value;

        public ReferenceToken(ICrawlToken parent, Type type,object value) : base(parent)
        {
            _value = value;
        }

        protected override object GetValue()
        {
            return _value;
        }
        public object Value => GetValue();

        public override void Accept(IObjectGraphVisitor visitor)
        {
            visitor.VisitReference(this);
        }
    }
    public class PropertyToken : CrawlToken
    {
        private readonly Func<object> _valueResolver;
        private readonly Action<object> _valueApplier;
        public PropertyInfo Property { get; }

        public PropertyToken(ICrawlToken parent, PropertyInfo property,Func<object> valueResolver,Action<object> valueApplier) : base(parent)
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


    public interface IObjectGraphVisitor
    {
        void VisitProperty(PropertyToken property);
        void VisitField(FieldToken field);
        void VisitReference(ReferenceToken reference);
    }

}
