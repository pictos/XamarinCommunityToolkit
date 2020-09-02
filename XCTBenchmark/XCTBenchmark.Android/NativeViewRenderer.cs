using Android.Content;
using Xamarin.Forms;
using XCTBenchmark.Helpers;
using AView = Android.Views.View;

[assembly: Dependency (typeof (XCTBenchmark.Droid.NativeViewRenderer))]

namespace XCTBenchmark.Droid
{
	class NativeViewRenderer : INativeViewRenderer
	{
		readonly Context context = global::Android.App.Application.Context;

		public object CreateNativeView (View view)
		{
			var native = (AView) Xamarin.Forms.Platform.Android.Platform.CreateRendererWithContext (view, context);
			native.Layout (0, 0, 100, 100);
			return native;
		}
	}
}
