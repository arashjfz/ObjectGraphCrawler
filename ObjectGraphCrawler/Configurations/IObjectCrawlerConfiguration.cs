namespace ObjectGraphCrawler.Configurations
{
    public interface IObjectCrawlerConfiguration
    {
        IFieldResolvingStrategy FieldResolver { get; }
        IPropertyResolvingStrategy PropertyResolver { get; }
        ICrawlingTypeDetectionStrategy CrawlingTypeDetection { get; }
    }
}