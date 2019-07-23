using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BenchmarkDotNet.Attributes;

namespace MSeifert.Linq.Benchmarks
{
    [ClrJob(baseline: true), CoreJob]
    [RPlotExporter, RankColumn]
    public class Benchmark1
    {
        private List<int> data;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = Enumerable.Range(0, N).ToList();
        }

        [Benchmark(Baseline = true)]
        public int Option1()
        {
            var sum_ = 0;
            foreach (var item in data)
            {
                sum_ += item;
            }
            return sum_;
        }

        [Benchmark]
        public int Option2()
        {
            var sum_ = 0;
            for (var index = 0; index < data.Count; index++)
            {
                sum_ += data[index];
            }
            return sum_;
        }

        [Benchmark]
        public string Option3()
        {
            return Class1.Text;
        }
    }
}
