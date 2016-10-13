using System;
using Xamarin.UITest;
using TaskyUITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using System.Runtime.Hosting;

namespace TaskyUITest
{
	public class TaskDetailsPage : BasePage
	{
		#region Properties and Fields
		readonly Query AddNameFieldUsingIds;
		readonly Query AddNotesFieldUsingIds;
		readonly Query ClickCheckBoxUsingIds;
		readonly Query SaveButtonUsingIds;
		readonly Query CancelButtonUsingIds;

		readonly Query AddNameField;
		readonly Query AddNotesField;
		readonly Query ClickCheckBox;
		readonly Query SaveButton;
		readonly Query CancelButton;
		#endregion

		#region Constructors
		public TaskDetailsPage(IApp app, Platform platform) : base(app, platform)
		{
			//Always initialize your UITest queries using "x.Marked" and referencing the UI ID
			//In Xamarin.Android, you set the UI ID by setting the control's "ContentDescription"
			//In Xamarin.iOS, you set the UI ID by setting the control's "AccessibilityIdentifiers"
			if (OnAndroid)
			{
				AddNameFieldUsingIds = x => x.Marked("AddNameFieldUsingIds");
				AddNotesFieldUsingIds = x => x.Marked("AddNotesFieldUsingIds");
				ClickCheckBoxUsingIds = x => x.Marked("ClickCheckBoxUsingIds");
				SaveButtonUsingIds = x => x.Marked("SaveButtonUsingIds");
				CancelButtonUsingIds = x => x.Marked("CancelButtonUsingIds");
			}
			//Below shows the improper way to initalize queries.
			//This code would break if the developer changed the text of the fields OR added another field/button
			if (OniOS)
			{
				AddNameField = x => x.Text("task name");
				AddNotesField = x => x.Class("UITableViewCell").Index(1);
				ClickCheckBox = x => x.Class("UISwitchModernVisualElement");
				SaveButton = x => x.Text("Save");
				CancelButton = x => x.Text("Delete");
			}
		}
		#endregion

		#region Methods
		//Name Field
		public void TapAddNameFieldUsingIds()
		{
			app.DismissKeyboard();
			app.ScrollDownTo(AddNameFieldUsingIds);
			app.Tap(AddNameFieldUsingIds);
			app.Screenshot("Tapped on Add Name Text Field");
		}

		public void TapAddNameField()
		{
			app.DismissKeyboard();
			app.ScrollDownTo(AddNameField);
			app.Tap(AddNameField);
			app.Screenshot("Tapped on Add Name Text Field");
		}

		//Notes Field
		public void TapAddNotesFieldUsingIds()
		{
			app.DismissKeyboard();
			app.ScrollDownTo(AddNotesFieldUsingIds);
			app.Tap(AddNotesFieldUsingIds);
			app.Screenshot("Tapped on Add Notes Edit Text Field");
		}

		public void TapAddNotesField()
		{
			app.DismissKeyboard();
			app.ScrollDownTo(AddNotesField);
			app.Tap(AddNotesField);
			app.Screenshot("Tapped on Add Notes Edit Text Field");
		}

		//Check Box
		public void TapClickCheckBoxUsingIds()
		{
			app.Tap(ClickCheckBoxUsingIds);
			app.Screenshot("Clicked on Check Box 'Done'");
		}

		public void TapClickCheckBox()
		{
			app.Tap(ClickCheckBox);
			app.Screenshot("Clicked on Check Box 'Done'");
		}

		//Save Button
		public void TapSaveButtonUsingIds()
		{
			app.Tap(SaveButtonUsingIds);
			app.Screenshot("Tapped on Save Button");
		}

		public void TapSaveButton()
		{
			app.Tap(SaveButton);
			app.Screenshot("Tapped on Save Button");
		}

		//Cancel Button
		public void TapCancelButtonUsingIds()
		{
			app.Tap(CancelButtonUsingIds);
			app.Screenshot("Tapped on Cancel Button");
		}

		public void TapCancelButton()
		{
			app.Tap(CancelButton);
			app.Screenshot("Tapped on Save Button");
		}
		#endregion
	}
}