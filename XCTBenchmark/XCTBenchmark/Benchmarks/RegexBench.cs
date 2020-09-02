using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace XCTBenchmark.Benchmarks
{
	[MemoryDiagnoser]
	public class RegexBench
	{
		public static string strToTest = "#xamarinForms!";
		public static string pattern = @"[@]\w+";

		public Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline);

		public Lazy<Regex> lazyRegex = new Lazy<Regex>(() => new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline));

		[Benchmark(Baseline = true)]
		public static bool RegexStringTest() =>
			Regex.IsMatch(strToTest, pattern, RegexOptions.Singleline);

		[Benchmark]
		public bool RegexCompiledTest() =>
			 regex.IsMatch(strToTest);

		[Benchmark]
		public bool RegexLazyTest() =>
			lazyRegex.Value.IsMatch(strToTest);
	}
}
