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

		#region Methods on HomeScreen
		public void TapAddTaskButtonUsingIds()
		{
			//app.DismissKeyboard();
			//app.ScrollDownTo(AddTaskButtonUsingIds);
			app.Tap(AddTaskButtonUsingIds);
			app.Screenshot("Tapped Add Task Button");
		}

		public void TapAddTaskButton()
		{
			//app.DismissKeyboard();
			//app.ScrollDownTo(AddTaskButton);
			app.Tap(AddTaskButton);
			app.Screenshot("Tapped Add Task Button");
		}
		#endregion

		#region Assertion
		public bool IsHomeScreenLoaded()
		{
			AppResult[] CheckAddTaskButtonResults;
			CheckAddTaskButtonResults = app.Query(AddTaskButton);

			int numberOfResults = CheckAddTaskButtonResults.Length;

			if (numberOfResults == 0)
				return false;
			else
				return true;
			#endregion
		}

	}
}
