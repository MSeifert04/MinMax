using System;
using System.Collections.Generic;
using System.Linq;
using MSeifert.MinMax.Tests.TestData;
using MSeifert.MinMax.Tests.Util;
using Xunit;

namespace MSeifert.MinMax.Tests
{
    public class TestMinMaxBy2
    {
        [Fact]
        public void EmptyThrowsException()
        {
            var l = new List<ClassWithIntField>();
            var c = Comparer<int>.Default;
            Assert.Throws<InvalidOperationException>(() => l.MinMaxBy(i => i.Value, c));
        }

        [Fact]
        public void OnNullThrowsException()
        {
            List<ClassWithIntField> l = null;
            var c = Comparer<int>.Default;
            Assert.Throws<ArgumentNullException>(() => l.MinMaxBy(i => i.Value, c));
        }

        [Fact]
        public void FirstArgumentNullThrowsException()
        {
            var l = new List<ClassWithIntField> { new ClassWithIntField(1) };
            Func<ClassWithIntField, int> s = null;
            var c = Comparer<int>.Default;
            Assert.Throws<ArgumentNullException>(() => l.MinMaxBy(s, c));
        }

        [Fact]
        public void SecondArgumentNullThrowsException()
        {
            var l = new List<ClassWithIntField> { new ClassWithIntField(1) };
            IComparer<int> c = null;
            Assert.Throws<ArgumentNullException>(() => l.MinMaxBy(i => i.Value, c));
        }

        [Fact]
        public void LengthOneHasSame()
        {
            var l = new List<ClassWithIntField> { new ClassWithIntField(1) };
            var c = Comparer<int>.Default;
            var r = l.MinMaxBy(i => i.Value, c);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(1, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(LengthTwoIntegerLists))]
        public void LengthTwo(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var c = Comparer<int>.Default;
            var r = l.MinMaxBy(i => i.Value, c);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(2, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(LengthThreeIntegerLists))]
        public void LengthThree(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var c = Comparer<int>.Default;
            var r = l.MinMaxBy(i => i.Value, c);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(3, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(LengthFourIntegerLists))]
        public void LengthFour(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var c = Comparer<int>.Default;
            var r = l.MinMaxBy(i => i.Value, c);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(4, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(SameElementIntegerLists))]
        public void SameELements(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var c = Comparer<int>.Default;
            var r = l.MinMaxBy(i => i.Value, c);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(1, r.Maximum.Value);
        }
    }
}
