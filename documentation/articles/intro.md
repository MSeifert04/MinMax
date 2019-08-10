# Less comparisons than Min and Max individually

The MinMax methods approximately need one and a half comparisons per element. This differs from
using Min and Max which both need 1 comparison per element and thus 2 comparisons per element
when using both.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

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
Console.WriteLine(IntegerWithComparisonCount.NumberOfComparisons);  // 17
IntegerWithComparisonCount.ResetNumberOfComparisons();

l.Min();
l.Max();
Console.WriteLine(IntegerWithComparisonCount.NumberOfComparisons);  // 22
```

The number of needed comparisons 17 / 22 is approximately the 3/4 we would expect.