using System;
using System.Collections.Generic;
using MSeifert.Linq.MinMax.Tests.TestData;
using Xunit;

namespace MSeifert.Linq.MinMax.Tests
{
    public class TestMinMax1
    {
        [Fact]
        public void EmptyThrowsException()
        {
            var l = new List<int>();
            var c = Comparer<int>.Default;
            Assert.Throws<InvalidOperationException>(() => l.MinMax(c));
        }

        [Fact]
        public void OnNullThrowsException()
        {
            List<int> l = null;
            var c = Comparer<int>.Default;
            Assert.Throws<ArgumentNullException>(() => l.MinMax(c));
        }

        [Fact]
        public void ArgumentNullThrowsException()
        {
            var l = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => l.MinMax(null));
        }

        [Fact]
        public void LengthOneHasSame()
        {
            var l = new List<int> { 1 };
            var c = Comparer<int>.Default;
            var r = l.MinMax(c);
            Assert.Equal(1, r.Minimum);
            Assert.Equal(1, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(LengthTwoIntegerLists))]
        public void LengthTwo(List<int> l)
        {
            var c = Comparer<int>.Default;
            var r = l.MinMax(c);
            Assert.Equal(1, r.Minimum);
            Assert.Equal(2, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(LengthThreeIntegerLists))]
        public void LengthThree(List<int> l)
        {
            var c = Comparer<int>.Default;
            var r = l.MinMax(c);
            Assert.Equal(1, r.Minimum);
            Assert.Equal(3, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(LengthFourIntegerLists))]
        public void LengthFour(List<int> l)
        {
            var c = Comparer<int>.Default;
            var r = l.MinMax(c);
            Assert.Equal(1, r.Minimum);
            Assert.Equal(4, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(SameElementIntegerLists))]
        public void SameELements(List<int> l)
        {
            var c = Comparer<int>.Default;
            var r = l.MinMax(c);
            Assert.Equal(1, r.Minimum);
            Assert.Equal(1, r.Maximum);
        }
    }
}
