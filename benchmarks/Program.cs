using BenchmarkDotNet.Running;

namespace MSeifert.Linq.MinMax.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark1>();
        }
    }
}
