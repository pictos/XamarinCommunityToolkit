using Xamarin.Forms;

namespace XCTBenchmark.Helpers
{
	public interface INativeViewRenderer
	{
		object CreateNativeView (View view);
	}
}
