using FluentAssertions;
using ObjectGraphCrawler.Tests.Doubles;
using Xunit;

namespace ObjectGraphCrawler.Tests
{
    public class ReferenceTest
    {
        [Fact]
        public void a_simple_object_should_be_detected_as_reference()
        {
            object o = new object();
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor =new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(o);

            visitor.Reference?.Type.Should().NotBeNull().And.Be<object>();
        }
        [Fact]
        public void property_should_be_detected_on_reference()
        {
            AClassWithSingleProperty classWithSingleProperty = new AClassWithSingleProperty();
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor =new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(classWithSingleProperty);

            visitor.Reference?.Type.Should().Be<AClassWithSingleProperty>();
            visitor.Property.Should().NotBeNull();
            visitor.Property.Property.Name.Should().Be(nameof(AClassWithSingleProperty.SingleProperty));
        }
        [Fact]
        public void field_should_be_detected_on_reference()
        {
            AClassWithSingleField classWithSingleField = new AClassWithSingleField();
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor =new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(classWithSingleField);

            visitor.Reference?.Type.Should().Be<AClassWithSingleField>();
            visitor.Field.Should().NotBeNull();
            visitor.Field.Field.Name.Should().Be("_singleField");
        }

        [Fact]
        public void self_reference_should_not_cause_stack_overflow()
        {
            AClassWithSelfReference classWithSelfReference = new AClassWithSelfReference();
            classWithSelfReference.Self = classWithSelfReference;
            ObjectCrawler crawler = new ObjectCrawler();
            ObjectGraphVisitorVisitorStub visitor = new ObjectGraphVisitorVisitorStub();
            crawler.AddVisitor(visitor);

            crawler.Crawl(classWithSelfReference);

            visitor.Reference?.Type.Should().Be<AClassWithSelfReference>();
            visitor.Property.Should().NotBeNull();
            visitor.Property.Property.Name.Should().Be(nameof(AClassWithSelfReference.Self));
        }
    }
}
