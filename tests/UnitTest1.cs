using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace MSeifert.Linq.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Assert.Equal("Hello, world!", Class1.Text);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            Assert.Equal("Hallo, Welt!", Class1.Text);
        }
    }
}
