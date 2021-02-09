namespace ObjectGraphCrawler.Tokens
{
    public abstract class CrawlToken : ICrawlToken
    {
        protected CrawlToken(ICrawlToken parent)
        {
            Parent = parent;
        }

        public ICrawlToken Parent { get; }
        object ICrawlToken.Value => GetValue();
        public bool IgnoreCrawl { get; set; }
        protected abstract object GetValue();
        public abstract void Accept(IObjectGraphVisitor visitor);
    }
}