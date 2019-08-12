# The MinMax and MinMaxBy methods

The `MinMax` method can be used to calculate the minimum and maximum of a generic enumerable.

While this could be simply solved using the `Min` and `Max` method in `System.Linq` namespace
the implementation in this package calculates both quantities in a single-pass and requires fewer
comparisons.

There are two methods for calculating the minimum and maximum.

- `MinMax` determines the minimum and maximum of the items in the enumerable by comparing the items.
- `MinMaxBy` returns the minimum and maximum of the items in the enumerable by comparing the result
  of a selector function applied to the items.

Both methods have an overload accepting an comparer.

These methods available as static methods on a static class `MinMaxOps` (in the namespace
`MiSe.MinMax`) or as extension methods for `System.Collections.Generic.IEnumerable<T>` in the
`MiSe.MinMax.Extensions` namespace.

## Example usage

```csharp
using System;
using System.Collections.Generic;
using MiSe.MinMax.Extensions;

var l = new List<int> { 3, 2, 4, 6, 1, 4 };
var minmax = l.MinMax();
Console.WriteLine(minmax.Minimum); // 1
Console.WriteLine(minmax.Maximum); // 6
```

More examples can be found as [LINQPad](https://www.linqpad.net/) samples in the
[linqpad-samples directory](https://github.com/MSeifert04/MinMax/tree/master/linqpad-samples). If
you download the package with LINQPad the samples will be automatically available in LINQPad (in
["Samples" -> "Nuget"](https://www.linqpad.net/nugetsamples.aspx)).
