using NUnit.Framework;
using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace TaskyUITest
{
	[Category("AddTaskTest")]
	public class AddTaskTest : BaseTest
	{
		public AddTaskTest(Platform platform) : base(platform)
		{
			this.platform = platform;
		}
	
		//This is the proper way to use AutomationIds in Page Object Pattern for a true Cross-Platform UITest 
		//Thus, you only see one test for BOTH Android and iOS
		[Test]
		public void ClickOnAddNewTaskButton()
		{
			//Arrange
			var expectedHomeScreenTitle = "Home Screen";

			//Act
			HomeScreen.TapAddTaskButtonUsingIds();

			//Assert
			var actualFirstPageTitle = HomeScreen.GetTitle();
			Assert.AreEqual(expectedHomeScreenTitle, expectedHomeScreenTitle);
		}

		//This method does not take advantage of UI IDs and thus, you will need to write different tests for each platform
		//Consequently, we have to write TWO sets of test-- one for Android and the other for iOS

		//This is the test for Android
		[Test]
		public void AddNewTaskForAndroid()
		{
			//Arrange
			string taskName = "Feed Kirby";

			var note = "Kirby runs wild when he is hungry!";
			var expectedHomeScreenTitle = "Home Screen";

			//Act
			HomeScreen.TapAddTaskButtonUsingIds();

			TaskDetailsPage.TapAddNameFieldUsingIds();

			app.EnterText(taskName);
			app.DismissKeyboard();
			app.Screenshot("Typed my task, 'Feed Kirby'");

			TaskDetailsPage.TapAddNotesFieldUsingIds();

			app.EnterText(note);
			app.DismissKeyboard();
			app.Screenshot("Typed my note about Kirby");

			TaskDetailsPage.TapClickCheckBoxUsingIds();

			TaskDetailsPage.TapSaveButtonUsingIds();

			//Assert
			var actualFirstPageTitle = HomeScreen.GetTitle();
			Assert.AreEqual(expectedHomeScreenTitle, expectedHomeScreenTitle);
		}

		//This is the test for iOS
		[Test]
		public void AddNewTaskForiOS()
		{
			//Arrange
			string taskName = "Feed Kirby";

			var note = "Kirby runs wild when he is hungry!";
			var expectedHomeScreenTitle = "Home Screen";

			//Act
			HomeScreen.TapAddTaskButton();

			TaskDetailsPage.TapAddNameField();

			app.EnterText(taskName);
			app.DismissKeyboard();
			app.Screenshot("Typed my task, 'Feed Kirby'");

			TaskDetailsPage.TapAddNotesField();

			app.EnterText(note);
			app.DismissKeyboard();
			app.Screenshot("Typed my note about Kirby");

			TaskDetailsPage.TapClickCheckBox();

			TaskDetailsPage.TapSaveButton();

			//Assert
			var actualFirstPageTitle = HomeScreen.GetTitle();
			Assert.AreEqual(expectedHomeScreenTitle, expectedHomeScreenTitle);
		}

	
	}
}
