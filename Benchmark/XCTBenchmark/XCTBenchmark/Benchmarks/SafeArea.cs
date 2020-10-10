using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace XCTBenchmark.Benchmarks
{
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class SafeAreaBench
	{
		Thickness initialMargin, insets;
		View element;
		SafeArea safeArea;

		[GlobalSetup]
		public void Setup()
		{
			initialMargin = new Thickness(10);
			insets = new Thickness(1);
			element = new Label
			{
				Margin = new Thickness(5)
			};
			safeArea = new SafeArea(true);
		}

		[Benchmark(Baseline = true)]
		public void UsingLocalToAccessProperty()
		{
			initialMargin = element.Margin;

			element.Margin = new Thickness(
				initialMargin.Left + (safeArea.Left ? insets.Left : 0),
				initialMargin.Top + (safeArea.Top ? insets.Top : 0),
				initialMargin.Right + (safeArea.Right ? insets.Right : 0),
				initialMargin.Bottom + (safeArea.Bottom ? insets.Bottom : 0));
		}

		[Benchmark]
		public void AccessPropertyDirectly()
		{
			initialMargin = element.Margin;

			element.Margin = new Thickness(
				element.Margin.Left + (safeArea.Left ? insets.Left : 0),
				element.Margin.Top + (safeArea.Top ? insets.Top : 0),
				element.Margin.Right + (safeArea.Right ? insets.Right : 0),
				element.Margin.Bottom + (safeArea.Bottom ? insets.Bottom : 0));
		}
	}
}
