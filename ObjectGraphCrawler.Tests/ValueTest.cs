using System;
using FluentAssertions;
using ObjectGraphCrawler.Tests.Doubles;
using Xunit;

namespace ObjectGraphCrawler.Tests
{
    public class ValueTest
    {
        [Fact]
        public void structures_should_be_detected_as_value()
        {
            DateTime dateTime = DateTime.Now;
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor = new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(dateTime);

            visitor.Value?.Type.Should().Be<DateTime>();
        }
        [Fact]
        public void string_should_be_detected_as_value()
        {
            string value = "some string";
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor = new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(value);

            visitor.Value?.Type.Should().Be<string>();
        }
    }
}
