using System;
using System.Collections.Generic;

namespace MSeifert.Linq.MinMax.Samples
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var l = new List<int> { 3, 2, 4, 6, 1, 4 };
            var minmax = l.MinMax();
            Console.WriteLine(minmax.Minimum); // 1
            Console.WriteLine(minmax.Maximum); // 6

            var l2 = new List<Person>
            {
                new Person { Name = "Oliver", Age = 22 },
                new Person { Name = "Paul", Age = 32 },
                new Person { Name = "Kate", Age = 26 },
                new Person { Name = "Peter", Age = 18 }
            };
            var minmax2 = l2.MinMaxBy(p => p.Age);
            Console.WriteLine(minmax2.Minimum); // 1
            Console.WriteLine(minmax2.Maximum); // 6
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString() => $"Person(Name:{Name}, Age={Age})";
    }
}
