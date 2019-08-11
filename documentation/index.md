# The MinMax and MinMaxBy methods

These methods can be used to calculate the minimum and maximum of a generic enumerable.

The `System.Linq` namespace contains implementations that calculate the minimum and maximum separately,
however the implementation in this package calculates both quantities in a single-pass and requires
less comparisons.

```csharp
using System;
using System.Collections.Generic;
using MiSe.MinMax.Extensions;

var l = new List<int> { 3, 2, 4, 6, 1, 4 };
var minmax = l.MinMax();
Console.WriteLine(minmax.Minimum); // 1
Console.WriteLine(minmax.Maximum); // 6
```

The MinMaxBy method allows to sort the objects by some selector function:

```csharp
using System;
using System.Collections.Generic;
using MiSe.MinMax.Extensions;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"Person(Name={Name}, Age={Age})";
}

var l = new List<Person>
{
    new Person { Name = "Oliver", Age = 22 },
    new Person { Name = "Paul", Age = 32 },
    new Person { Name = "Kate", Age = 26 },
    new Person { Name = "Peter", Age = 18 }
};
var minmax = l.MinMaxBy(p => p.Age);
Console.WriteLine(minmax.Minimum); // Person(Name=Peter, Age=18)
Console.WriteLine(minmax.Maximum); // Person(Name=Paul, Age=32)
```

Both return the first encountered minimum and maximum.

```csharp
using System;
using System.Collections.Generic;
using MiSe.MinMax.Extensions;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"Person(Name={Name}, Age={Age})";
}

var l = new List<Person>
{
    new Person { Name = "Oliver", Age = 18 },
    new Person { Name = "Paul", Age = 18 },
    new Person { Name = "Kate", Age = 18 },
    new Person { Name = "Peter", Age = 18 }
};
var minmax = l.MinMaxBy(p => p.Age);
Console.WriteLine(minmax.Minimum); // Person(Name=Oliver, Age=18)
Console.WriteLine(minmax.Maximum); // Person(Name=Oliver, Age=18)
```

One can also use the non-extension methods:

```csharp
using System;
using System.Collections.Generic;
using MiSe.MinMax;

var l = new List<int> { 3, 2, 4, 6, 1, 4 };
var minmax = MinMaxOps.MinMax(l);
Console.WriteLine(minmax.Minimum); // 1
Console.WriteLine(minmax.Maximum); // 6
```
