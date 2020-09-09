using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace XCTBenchmark.Benchmarks
{
	[MemoryDiagnoser]
	public class LoopsBench
	{
		public List<int> numbers = new List<int>(101);

		[Params(10, 100, 1000)]
		public int SizeNumbers { get; set; }

		[GlobalSetup]
		public void SetUp()
		{
			for (var i = 0; i < SizeNumbers; i++)
				numbers.Add(i);
		}

		[Benchmark(Baseline = true)]
		public void LoopUsingCount()
		{
			for (var i = 0; i < numbers.Count; i++)
			{
				_ = numbers[i];
			}
		}


		[Benchmark]
		public void LoopUsingLocalVar()
		{
			var size = numbers.Count;
			for (var i = 0; i < size; i++)
			{
				_ = numbers[i];
			}
		}
	}
}
