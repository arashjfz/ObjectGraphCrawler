namespace ObjectGraphCrawler.Configurations
{
    public class ObjectCrawlerConfiguration : IObjectCrawlerConfiguration
    {
        public ObjectCrawlerConfiguration()
        {
            FieldResolver = new FieldResolvingStrategy();
            PropertyResolver = new PropertyResolvingStrategy();
            CrawlingTypeDetection = new CrawlingTypeDetectionStrategy();
        }
        public IFieldResolvingStrategy FieldResolver { get; set; }
        public IPropertyResolvingStrategy PropertyResolver { get; set; }
        public ICrawlingTypeDetectionStrategy CrawlingTypeDetection { get; set; }
    }
}