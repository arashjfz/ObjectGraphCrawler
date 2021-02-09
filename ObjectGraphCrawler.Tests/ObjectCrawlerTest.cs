using System;
using FluentAssertions;
using Xunit;

namespace ObjectGraphCrawler.Tests
{
    public class ObjectCrawlerTest
    {
        [Fact]
        public void null_value_cannot_be_crawled()
        {
            ObjectCrawler objectCrawler = new ObjectCrawler();

            Action action = () => objectCrawler.Crawl(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
