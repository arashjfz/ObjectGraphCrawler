using System;
using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler.Tests.Doubles
{
    public class ObjectGraphVisitorVisitorStub : IObjectGraphVisitor
    {
        public PropertyToken Property { get; private set; }
        public FieldToken Field { get; private set; }
        public ReferenceToken Reference { get; private set; }
        public ValueToken Value { get; private set; }
        public EnumerableToken Enumerable { get; private set; }
        public DictionaryToken Dictionary { get; private set; }
        public void VisitProperty(PropertyToken property)
        {
            Property = property;
        }

        public void VisitField(FieldToken field)
        {
            Field = field;
        }

        public void VisitReference(ReferenceToken reference)
        {
            Reference = reference;
        }

        public void VisitValue(ValueToken value)
        {
            Value = value;
        }

        public void VisitEnumerable(EnumerableToken enumerable)
        {
            Enumerable = enumerable;
        }

        public void VisitDictionary(DictionaryToken dictionary)
        {
            Dictionary = dictionary;
        }
    }
}