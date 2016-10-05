using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace TaskyUITest
{
	public class HomeScreen : BasePage
	{
		readonly Query AddTaskButtonUsingIds;
		readonly Query AddTaskButton;

		public HomeScreen(IApp app, Platform platform) : base(app, platform)
		{
			AddTaskButtonUsingIds = x => x.Marked("AddButton");

			if (platform == Platform.iOS)
				AddTaskButton = x => x.Class("UIBarButtonItem").Index(0);
			else
				AddTaskButton = x => x.Class("Button").Index(0);
		}

		public void TapAddTaskButtonUsingIds()
		{
			app.DismissKeyboard();
			app.ScrollDownTo(AddTaskButtonUsingIds);
			app.Tap(AddTaskButtonUsingIds);
			app.Screenshot("Tapped Add Task Button");

		}

		public void TapAddTaskButton()
		{
			app.DismissKeyboard();
			app.ScrollDownTo(AddTaskButton);
			app.Tap(AddTaskButton);
			app.Screenshot("Tapped Add Task Button");

		}

		public string GetTitle()
		{
			var title = "Home Page";
			AppResult[] titleQuery;

			app.WaitForElement(title);

			if (OniOS)
				titleQuery = app.Query(x => x.Class("UILabel").Marked("Home Page"));
			else
				titleQuery = app.Query(x => x.Class("TextView").Marked("Home Page"));

			return titleQuery[0]?.Text;
		}

	}
}
