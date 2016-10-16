using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin;
using HockeyApp.iOS;
using Tasky.Shared;

namespace Tasky
{
	public class Application
	{
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}

	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		UITableViewController homeViewController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
#if DEBUG
			Calabash.Start();
#endif
			// create a new window instance based on the screen size
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			// make the window visible
			window.MakeKeyAndVisible();

			var hockeyappManager = BITHockeyManager.SharedHockeyManager;
			hockeyappManager.Configure(HockeyAppConstants.iOSHockeyAppID);
			hockeyappManager.LogLevel = BITLogLevel.Debug;
			hockeyappManager.StartManager();
			hockeyappManager.Authenticator.AuthenticateInstallation();
			hockeyappManager.UpdateManager.CheckForUpdateOnLaunch = true;


			// create our nav controller
			navController = new UINavigationController();

			// create our Todo list screen
			homeViewController = new Screens.HomeScreen();


			//			UIApplication.SharedApplication.KeyWindow.TintColor = UIColor.White;
			//			navController.NavigationBar.BarTintColor = UIColor.FromRGB (0x91, 0xCA, 0x47);
			// green theme

			//			navController.NavigationBar.TintColor = UIColor.White;
			//			navController.NavigationBar.BarTintColor = UIColor.FromRGB (0x6F, 0xA2, 0x2E);

			navController.NavigationBar.TintColor = UIColor.FromRGB(0x6F, 0xA2, 0x2E); // 6FA22E dark-green
			navController.NavigationBar.BarTintColor = UIColor.FromRGB(0xCF, 0xEF, 0xA7); // CFEFA7 light-green

			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				//				TextColor = UIColor.White,
				TextColor = UIColor.FromRGB(0x6F, 0xA2, 0x2E), // 6FA22E dark-green
				TextShadowColor = UIColor.Clear
			});

			// push the view controller onto the nav controller and show the window
			navController.PushViewController(homeViewController, false);
			window.RootViewController = navController;
			window.MakeKeyAndVisible();

			return true;
		}
	}
}