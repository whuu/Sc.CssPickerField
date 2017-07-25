using FluentAssertions;
using NSubstitute;
using SmartSitecore.CssPickerField.Cache;
using SmartSitecore.CssPickerField.Repositories;
using System.Collections.Generic;
using Xunit;

namespace SmartSitecore.CssPickerField.Tests.Cache
{
    public class CssCacheTest
    {
        [Fact]
        public void CacheTestTwice()
        {
            var repository = Substitute.For<ICssRepository>();
            var css = new List<string> { "t", "test", "te",  "include-test" };
            repository.GetStyles().Returns(css);

            var cache = new CssCache(1048576, repository);
            cache.Get("test").Should().BeInAscendingOrder("test", "test-include");
        }

        [Fact]
        public void CacheTestEmpty()
        {
            var repository = Substitute.For<ICssRepository>();
            var css = new List<string> { };
            repository.GetStyles().Returns(css);

            var cache = new CssCache(1048576, repository);
            cache.Get("test").Should().BeEmpty();
        }

        [Fact]
        public void CacheTestInside()
        {
            var repository = Substitute.For<ICssRepository>();
            var css = new List<string> { "t", "betested", "te" };
            repository.GetStyles().Returns(css);

            var cache = new CssCache(1048576, repository);
            cache.Get("test").Should().BeInAscendingOrder("test", "betested");
        }
    }
}
