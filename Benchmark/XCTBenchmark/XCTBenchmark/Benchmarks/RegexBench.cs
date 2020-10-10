using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using XCTBenchmark.Helpers;

namespace XCTBenchmark.Benchmarks
{
	[MemoryDiagnoser]
	public class RegexBench : BaseBenchmark
	{
		public string strToTest = "#xamarinForms!";
		public string pattern = @"[@]\w+";

		public Regex regex;

		public Lazy<Regex> lazyRegex;

		[GlobalSetup]
		public void SetUp()
		{
			regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline);
			lazyRegex = new Lazy<Regex>(() => new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline));
		}

		[Benchmark(Baseline = true)]
		public bool RegexStringTest() =>
			Regex.IsMatch(strToTest, pattern, RegexOptions.Singleline);

		[Benchmark]
		public bool RegexCompiledTest() =>
			 regex.IsMatch(strToTest);

		[Benchmark]
		public bool RegexLazyTest() =>
			lazyRegex.Value.IsMatch(strToTest);
	}
}
