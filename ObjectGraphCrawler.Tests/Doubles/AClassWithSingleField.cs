namespace ObjectGraphCrawler.Tests.Doubles
{
    public class AClassWithSingleField
    {
        private int _singleField;
    }
    public class AClassWithSelfReference
    {
        public AClassWithSelfReference Self { get; set; }
    }
}