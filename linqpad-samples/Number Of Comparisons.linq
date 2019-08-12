<Query Kind="Program">
  <NuGetReference>MiSe.MinMax</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>MiSe.MinMax.Extensions</Namespace>
</Query>

void Main()
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
    IntegerWithComparisonCount.NumberOfComparisons.Dump();
    IntegerWithComparisonCount.ResetNumberOfComparisons();

    l.Min();
    l.Max();
    IntegerWithComparisonCount.NumberOfComparisons.Dump();
}



internal class IntegerWithComparisonCount : IComparable<IntegerWithComparisonCount>
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