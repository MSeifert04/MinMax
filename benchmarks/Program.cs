using BenchmarkDotNet.Running;

namespace MSeifert.MinMax.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark1>();
        }
    }
}
