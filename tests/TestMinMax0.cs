﻿using System;
using System.Collections.Generic;
using MiSe.MinMax.Extensions;
using MiSe.MinMax.Tests.TestData;
using Xunit;

namespace MiSe.MinMax.Tests
{
    public class TestMinMax0
    {
        [Fact]
        public void EmptyThrowsException()
        {
            var l = new List<int>();
            Assert.Throws<InvalidOperationException>(() => l.MinMax());
        }

        [Fact]
        public void OnNullThrowsException()
        {
            List<int> l = null;
            Assert.Throws<ArgumentNullException>(() => l.MinMax());
        }

        [Fact]
        public void LengthOneHasSame()
        {
            var l = new List<int> { 1 };
            var r = l.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(1, r.Maximum);
        }

        [Fact]
        public void WithArray()
        {
            var a = new[] { 1, 2, 3 };
            var r = a.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(3, r.Maximum);
        }

        [Fact]
        public void WithQueue()
        {
            var a = new Queue<int> (new[] { 1, 2, 3 });
            var r = a.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(3, r.Maximum);
        }

        [Fact]
        public void WithHashSet()
        {
            var a = new HashSet<int> { 1, 2, 3 };
            var r = a.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(3, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(LengthTwoIntegerLists))]
        public void LengthTwo(List<int> l)
        {
            var r = l.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(2, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(LengthThreeIntegerLists))]
        public void LengthThree(List<int> l)
        {
            var r = l.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(3, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(LengthFourIntegerLists))]
        public void LengthFour(List<int> l)
        {
            var r = l.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(4, r.Maximum);
        }

        [Theory]
        [ClassData(typeof(SameElementIntegerLists))]
        public void SameELements(List<int> l)
        {
            var r = l.MinMax();
            Assert.Equal(1, r.Minimum);
            Assert.Equal(1, r.Maximum);
        }
    }
}
