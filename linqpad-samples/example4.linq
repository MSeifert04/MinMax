<Query Kind="Program">
  <NuGetReference>MiSe.MinMax</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>MiSe.MinMax</Namespace>
</Query>

void Main()
{
    var l = new List<int> { 3, 2, 4, 6, 1, 4 };
    var minmax = MinMaxOps.MinMax(l);
    minmax.Dump();
}
