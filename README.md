Object graph crawler is as simple library that can be used to crawl a graph of object and intersept it using the visitor pattern


**Build status:**
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/arashjfz/ObjectGraphCrawler/.NET)

How to Use
<br />
The entry point for crawling is ***ObjectCrawler*** class 
```csharp
ObjectCrawler crawler = new ObjectCrawler();
```
Then simply add A visitor. Visitors can be inherited from ***ObjectGraphVisitor*** class. then by overriding each visiting methods it is possible to inspect crawling tokens
```csharp
crawler.AddVisitor(visitor);
```
Finally use ***crawl*** method of ***crawler*** to start crawling

```csharp
crawler.Crawl(someObjectToCrawl);
```
