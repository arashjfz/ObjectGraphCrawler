using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ObjectGraphCrawler.Tests.Doubles;
using Xunit;

namespace ObjectGraphCrawler.Tests
{
    public class CollectionTest
    {
        [Fact]
        public void enumerable_should_be_detected()
        {
            List<int> someList = new List<int>();
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor = new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(someList);

            visitor.Enumerable?.Type.Should().NotBeNull().And.Be<List<int>>();
        }
        [Fact]
        public void dictionary_should_be_detected()
        {
            Dictionary<int,int> someDictionary = new Dictionary<int, int>();
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor = new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(someDictionary);

            visitor.Enumerable?.Type.Should().NotBeNull().And.Be<Dictionary<int, int>>();
        }
    }
}
