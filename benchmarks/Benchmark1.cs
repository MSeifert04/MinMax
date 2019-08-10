using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;

namespace MSeifert.MinMax.Benchmarks
{
    [ClrJob(baseline: true), CoreJob]
    [RankColumn]
    public class Benchmark1
    {
        private List<int> _data;
        private Random _rng = new Random();

        //[Params(10, 1_000, 1_000_000)]
        [Params(10, 1_000_000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _data = new List<int>();
            for (var i = 0; i < N; i++)
            {
                var rnd = _rng.Next(0, N);
                _data.Add(rnd);
            }
        }

        [Benchmark(Baseline = true)]
        public int LinqMinAndMaxSeperate()
        {
            var min = _data.Min();
            var max = _data.Max();
            return min + max;
        }

        [Benchmark]
        public int MinMax()
        {
            var minmax = _data.MinMax();
            return minmax.Minimum + minmax.Maximum;
        }
    }
}
