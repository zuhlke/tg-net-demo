using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace PriceSnoop.Tests
{
    public class DummyTests
    {
        [Fact]
        public void DummyTest()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void DummyTestWithMoq()
        {
            var enumerable = new Mock<IEnumerable<int>>();
            enumerable
                .Setup(en => en.GetEnumerator())
                .Returns(new List<int> { 1, 3, 5 }.GetEnumerator());

            Assert.Equal(5, enumerable.Object.Last());
        }
    }
}
