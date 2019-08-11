using BenchmarkDotNet.Running;

namespace MiSe.MinMax.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark1>();
        }
    }
}
