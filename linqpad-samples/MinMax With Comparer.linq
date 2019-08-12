<Query Kind="Program">
  <NuGetReference>MiSe.MinMax</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>MiSe.MinMax.Extensions</Namespace>
</Query>

void Main()
{
    var l = new List<string> { "a", "Z" };
    var minmax = l.MinMax();
    minmax.Dump();
	
    minmax = l.MinMax(StringComparer.Ordinal);
    minmax.Dump();
}