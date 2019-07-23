using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSeifert.Linq.Samples
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(Class1.Text);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            Console.WriteLine(Class1.Text);
        }
    }
}
