using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BenchmarkDotNet.Running;

namespace MSeifert.Linq.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark1>();
        }
    }
}
