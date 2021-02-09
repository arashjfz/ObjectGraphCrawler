namespace ObjectGraphCrawler.Tokens
{
    public interface ICrawlToken
    {
        ICrawlToken Parent { get; }
        object Value { get; }
        bool IgnoreCrawl { get; set; }
        void Accept(IObjectGraphVisitor visitor);
    }
}