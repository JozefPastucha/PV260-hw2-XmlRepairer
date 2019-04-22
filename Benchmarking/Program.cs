using BenchmarkDotNet.Running;
using System;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<XMLRepairerBenchmark>();
        }
    }
}
