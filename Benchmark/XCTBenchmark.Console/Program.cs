using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using XCTBenchmark.Helpers;

namespace XCTBenchmark.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = default(IConfig);
#if DEBUG
			config = new DebugInProcessConfig ();
#endif
			BenchmarkSwitcher.FromAssembly(typeof(BaseBenchmark).Assembly).Run(args, config);
		}
	}
}
