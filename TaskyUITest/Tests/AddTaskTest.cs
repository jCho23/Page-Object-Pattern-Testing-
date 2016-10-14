using System;
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
		public void TapAddTaskButtonUsingIds()
		{
			//Arrange

			//Act
			HomeScreen.TapAddTaskButtonUsingIds();

			//Assert
			Assert.IsTrue(HomeScreen.IsHomeScreenLoaded());
		}


		#region The Unorthodox method of Page Object Pattern
		//This method does not take advantage of UI IDs and thus, you will need to write different tests for each platform
		//Consequently, we have to write TWO separate sets of test-- one for Android and the other for iOS
		[Test]
		public void AddNewTaskForAndroidandiOS()
		{
			//Arrange
			string taskName = "Feed Kirby";
			var note = "Kirby runs wild when he is hungry!";


			if (platform == Platform.Android)
			{
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
				Assert.IsTrue(HomeScreen.IsHomeScreenLoaded());
			}

			else if (platform == Platform.iOS)
			{
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
				Assert.IsTrue(HomeScreen.IsHomeScreenLoaded());
			}
			#endregion
		}
	}
}
