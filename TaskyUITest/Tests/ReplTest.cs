using NUnit.Framework;
using Xamarin.UITest;
using TaskyUITest;

namespace TaskyUITest
{
	public class ReplTest : BaseTest
	{

		public ReplTest(Platform platform) : base(platform)
		{
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}
	}
}