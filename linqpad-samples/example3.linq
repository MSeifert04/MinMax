<Query Kind="Program">
  <NuGetReference>MiSe.MinMax</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>MiSe.MinMax.Extensions</Namespace>
</Query>

void Main()
{
    var l = new List<Person>
    {
        new Person { Name = "Oliver", Age = 18 },
        new Person { Name = "Paul", Age = 18 },
        new Person { Name = "Kate", Age = 18 },
        new Person { Name = "Peter", Age = 18 }
    };
    var minmax = l.MinMaxBy(p => p.Age);
    minmax.Dump();
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"Person(Name={Name}, Age={Age})";
}
