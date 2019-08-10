using System;
using System.Collections.Generic;
using System.Linq;

namespace MSeifert.Linq.MinMax.Samples
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Example1();
            Example2();
            Example3();
            Example4();
            Example5();
            Example6();
        }

        public static void Example1()
        {
            var l = new List<int> { 3, 2, 4, 6, 1, 4 };
            var minmax = l.MinMax();
            Console.WriteLine(minmax.Minimum);
            Console.WriteLine(minmax.Maximum);
        }

        public static void Example2()
        {
            var l = new List<Person>
            {
                new Person { Name = "Oliver", Age = 22 },
                new Person { Name = "Paul", Age = 32 },
                new Person { Name = "Kate", Age = 26 },
                new Person { Name = "Peter", Age = 18 }
            };
            var minmax = l.MinMaxBy(p => p.Age);
            Console.WriteLine(minmax.Minimum);
            Console.WriteLine(minmax.Maximum);
        }

        public static void Example3()
        {
            var l = new List<Person>
            {
                new Person { Name = "Oliver", Age = 18 },
                new Person { Name = "Paul", Age = 18 },
                new Person { Name = "Kate", Age = 18 },
                new Person { Name = "Peter", Age = 18 }
            };
            var minmax = l.MinMaxBy(p => p.Age);
            Console.WriteLine(minmax.Minimum);
            Console.WriteLine(minmax.Maximum);
        }

        public static void Example4()
        {
            var l = new List<int> { 3, 2, 4, 6, 1, 4 };
            var minmax = MinMaxExt.MinMax(l);
            Console.WriteLine(minmax.Minimum);
            Console.WriteLine(minmax.Maximum);
        }

        public static void Example5()
        {
            var l = new List<IntegerWithComparisonCount>
            {
                new IntegerWithComparisonCount(3),
                new IntegerWithComparisonCount(2),
                new IntegerWithComparisonCount(4),
                new IntegerWithComparisonCount(6),
                new IntegerWithComparisonCount(1),
                new IntegerWithComparisonCount(4),
                new IntegerWithComparisonCount(3),
                new IntegerWithComparisonCount(2),
                new IntegerWithComparisonCount(4),
                new IntegerWithComparisonCount(6),
                new IntegerWithComparisonCount(1),
                new IntegerWithComparisonCount(4)
            };
            l.MinMax();
            Console.WriteLine(IntegerWithComparisonCount.NumberOfComparisons);
            IntegerWithComparisonCount.ResetNumberOfComparisons();

            l.Min();
            l.Max();
            Console.WriteLine(IntegerWithComparisonCount.NumberOfComparisons);
        }

        public static void Example6()
        {
            var l = new List<string> { "a", "Z" };
            var minmax = l.MinMax(StringComparer.Ordinal);
            Console.WriteLine(minmax.Minimum);
            Console.WriteLine(minmax.Maximum);
        }
    }

    public class IntegerWithComparisonCount : IComparable<IntegerWithComparisonCount>
    {
        public int Value { get; set; }

        public static int NumberOfComparisons { get; private set; }

        public static void ResetNumberOfComparisons()
        {
            NumberOfComparisons = 0;
        }

        public IntegerWithComparisonCount(int value)
        {
            Value = value;
        }
        public int CompareTo(IntegerWithComparisonCount other)
        {
            NumberOfComparisons++;
            return Value.CompareTo(other.Value);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString() => $"Person(Name={Name}, Age={Age})";
    }
}
