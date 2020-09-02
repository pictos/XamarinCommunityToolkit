using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCTBenchmark.Pages
{
	public partial class RunnerPage : ContentPage
	{
		readonly Type benchmarkType;

		public RunnerPage(Type benchmarkType)
		{
			this.benchmarkType = benchmarkType;
			Title = benchmarkType.Name;
			InitializeComponent();
		}

		async void Button_Clicked(object sender, EventArgs e)
		{
			SetIsRunning(true);
			try
			{
				var logger = new ActionLogger(SetSummary);
				var summary = await Task.Run(() => BenchmarkRunner.Run(benchmarkType, DefaultConfig.Instance.AddLogger(logger)));
				ConclusionHelper.Print(logger,
					summary.BenchmarksCases
						.SelectMany(benchmark => benchmark.Config.GetCompositeAnalyser().Analyse(summary))
						.Distinct()
						.ToList());
			}
			catch (Exception exc)
			{
				SetSummary("Unhandled exception: " + exc);
			}
			finally
			{
				SetIsRunning(false);
			}
		}

		void SetIsRunning(bool isRunning)
		{
			Indicator.IsRunning = isRunning;
			Run.IsVisible = !isRunning;
			if (isRunning)
			{
				Summary.Text = "";
			}
			ResizeSummary();
		}

		/// <summary>
		/// NOTE: called from background thread
		/// </summary>
		void SetSummary(string text) =>
			Device.BeginInvokeOnMainThread(() =>
			{
				Summary.Text = text;
				ResizeSummary();
			});

		void ResizeSummary()
		{
			Summary.WidthRequest = Summary.HeightRequest = -1;
			var size = Summary.Measure(double.MaxValue, double.MaxValue).Request;
			Summary.WidthRequest = size.Width;
			Summary.HeightRequest = size.Height;
			Scroller.ScrollToAsync(0, size.Height, false);
		}
	}

}