using System;
using System.Collections.Generic;
using System.Linq;
using MSeifert.Linq.MinMax.Tests.TestData;
using MSeifert.Linq.MinMax.Tests.Util;
using Xunit;

namespace MSeifert.Linq.MinMax.Tests
{
    public class TestMinMaxBy1
    {
        [Fact]
        public void EmptyThrowsException()
        {
            var l = new List<ClassWithIntField>();
            Assert.Throws<InvalidOperationException>(() => l.MinMaxBy(i => i.Value));
        }

        [Fact]
        public void OnNullThrowsException()
        {
            List<ClassWithIntField> l = null;
            Assert.Throws<ArgumentNullException>(() => l.MinMaxBy(i => i.Value));
        }

        [Fact]
        public void ArgumentNullThrowsException()
        {
            var l = new List<ClassWithIntField> { new ClassWithIntField(1) };
            Func<ClassWithIntField, int> s = null;
            Assert.Throws<ArgumentNullException>(() => l.MinMaxBy(s));
        }

        [Fact]
        public void LengthOneHasSame()
        {
            var l = new List<ClassWithIntField> { new ClassWithIntField(1) };
            var r = l.MinMaxBy(i => i.Value);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(1, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(LengthTwoIntegerLists))]
        public void LengthTwo(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var r = l.MinMaxBy(i => i.Value);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(2, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(LengthThreeIntegerLists))]
        public void LengthThree(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var r = l.MinMaxBy(i => i.Value);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(3, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(LengthFourIntegerLists))]
        public void LengthFour(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var r = l.MinMaxBy(i => i.Value);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(4, r.Maximum.Value);
        }

        [Theory]
        [ClassData(typeof(SameElementIntegerLists))]
        public void SameELements(List<int> raw)
        {
            var l = raw.Select(i => new ClassWithIntField(i)).ToList();
            var r = l.MinMaxBy(i => i.Value);
            Assert.Equal(1, r.Minimum.Value);
            Assert.Equal(1, r.Maximum.Value);
        }
    }
}
