using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCTBenchmark.Pages;

namespace XCTBenchmark
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new SimpleRunPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
