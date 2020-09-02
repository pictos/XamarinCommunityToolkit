using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XCTBenchmark.Benchmarks;
using XCTBenchmark.Pages;

namespace XCTBenchmark
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new[]
			{
				typeof (RegexBench),
			};
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item is Type benchmarkType)
			{
				Navigation.PushAsync(new RunnerPage(benchmarkType));
				List.SelectedItem = null;
			}
		}
	}
}
