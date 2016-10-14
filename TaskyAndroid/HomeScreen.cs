using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Shared;
using TaskyAndroid;
using TaskyAndroid.ApplicationLayer;
using Android.Content.PM;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

namespace TaskyAndroid.Screens 
{
	/// Main ListView screen displays a list of tasks, plus an [Add] button
	[Activity (Label = "Tasky",  
		Icon="@drawable/icon",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class HomeScreen : Activity 
	{
		TodoItemListAdapter taskList;
		IList<TodoItem> tasks;
		Button addTaskButton;
		ListView taskListView;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			CrashManager.Register(this, HockeyAppConstants.DroidHockeyAppID);
			UpdateManager.Register(this, HockeyAppConstants.DroidHockeyAppID, true);
			FeedbackManager.Register(this, HockeyAppConstants.DroidHockeyAppID, null);
			//MetricsManager.Register(this, Application, HockeyAppConstants.DroidHockeyAppID);

			//Set our layout to be the home screen
			SetContentView(Resource.Layout.HomeScreen);

			//Find our controls
			taskListView = FindViewById<ListView> (Resource.Id.TaskList);
			addTaskButton = FindViewById<Button> (Resource.Id.AddButton);

			// wire up add task button handler
			if(addTaskButton != null) {
				addTaskButton.Click += (sender, e) => {
					MetricsManager.TrackEvent(HockeyAppConstants.AddButtonTapped);
					StartActivity(typeof(TodoItemScreen));
				};
			}
			
			// wire up task click handler
			if(taskListView != null) {
				taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var taskDetails = new Intent (this, typeof (TodoItemScreen));
					taskDetails.PutExtra ("TaskID", tasks[e.Position].ID);
					StartActivity (taskDetails);
				};
			}
		}
		
		protected override void OnResume ()
		{
			base.OnResume ();

			Tracking.StartUsage(this);

			tasks = TodoItemManager.GetTasks();
			
			// create our adapter
			taskList = new TodoItemListAdapter(this, tasks);

			//Hook up our adapter to our ListView
			taskListView.Adapter = taskList;
		}

		protected override void OnPause()
		{
			base.OnPause();

			Tracking.StopUsage(this);
		}
	}
}