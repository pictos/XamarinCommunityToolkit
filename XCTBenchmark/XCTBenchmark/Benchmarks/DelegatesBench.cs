using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace XCTBenchmark.Benchmarks
{
	[MemoryDiagnoser]
	public class DelegatesBench
	{
		Action action = () =>
		{
			if (DateTime.Now.Ticks < 0)
				Console.WriteLine("Helloe");
		};

		public static void RunAction(Action action)
		{
			action();
		}

		[Benchmark]
		public void NormalCall()
		{
			RunAction(action);
		}

		[Benchmark]
		public void LambdalCall()
		{
			RunAction(() => action());
		}
	}
}
