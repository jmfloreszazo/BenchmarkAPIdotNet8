using Benchmark;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<testAPIBenchmark>();
Console.WriteLine(summary);