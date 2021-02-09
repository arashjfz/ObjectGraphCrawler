using ObjectGraphCrawler.Tokens;

namespace ObjectGraphCrawler
{
    public class ObjectGraphVisitor : IObjectGraphVisitor
    {
        public virtual void VisitProperty(PropertyToken property)
        {
            
        }

        public virtual void VisitField(FieldToken field)
        {
            
        }

        public virtual void VisitReference(ReferenceToken reference)
        {
            
        }

        public virtual void VisitValue(ValueToken valueToken)
        {
            
        }

        public virtual void VisitEnumerable(EnumerableToken enumerableToken)
        {
            
        }

        public virtual void VisitDictionary(DictionaryToken dictionary)
        {
            
        }
    }
}