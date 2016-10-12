﻿using NUnit.Framework;
using Xamarin.UITest;

namespace TaskyUITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]

	public abstract class BaseTest
	{
		protected IApp app;
		protected Platform platform;

		protected HomeScreen HomeScreen;
		protected TaskDetailsPage TaskDetailsPage;

		protected BaseTest(Platform platform)
		{
			this.platform = platform;

		}

		[SetUp]
		virtual public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Initialized");

			this.HomeScreen = new HomeScreen(app, this.platform);
			this.TaskDetailsPage = new TaskDetailsPage(app, this.platform);
		}
	}
}

