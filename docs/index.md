# The MinMax and MinMaxBy extension methods

These extension methods can be used to calculate the minimum and maximum of a generic
enumerable.

The System.Linq contains implementations that calculate the minimum and maximum separately,
however the implementation in this package calculates them in a single-pass and requires
less comparisons.

```csharp
using MSeifert.Linq.MinMax;

var l = new List<int> { 3, 2, 4, 6, 1, 4 };
var minmax = l.MinMax();
Console.WriteLine(minmax.Minimum); // 1
Console.WriteLine(minmax.Maximum); // 6
```

The MinMaxBy method allows to sort the objects by some selector function:

```csharp
using MSeifert.Linq.MinMax;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"Person(Name:{Name}, Age={Age})";
}

var l2 = new List<Person>
{
    new Person { Name = "Oliver", Age = 22 },
    new Person { Name = "Paul", Age = 32 },
    new Person { Name = "Kate", Age = 26 },
    new Person { Name = "Peter", Age = 18 }
};
var minmax2 = l2.MinMaxBy(p => p.Age);
Console.WriteLine(minmax2.Minimum); // Person(Name:Peter, Age=18)
Console.WriteLine(minmax2.Maximum); // Person(Name:Paul, Age=32)
```
