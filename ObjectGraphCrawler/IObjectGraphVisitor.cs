using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler
{
    public interface IObjectGraphVisitor
    {
        void VisitProperty(PropertyToken property);
        void VisitField(FieldToken field);
        void VisitReference(ReferenceToken reference);
        void VisitValue(ValueToken valueToken);
        void VisitEnumerable(EnumerableToken enumerableToken);
        void VisitDictionary(DictionaryToken dictionary);
    }
}