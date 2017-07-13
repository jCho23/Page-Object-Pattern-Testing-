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
		UIWindow window;
		UINavigationController navController;
		UITableViewController homeViewController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
#if DEBUG
			Calabash.Start();
#endif
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			window.MakeKeyAndVisible();

			//HockeyApp Setup for iOS
			var hockeyappManager = BITHockeyManager.SharedHockeyManager;
			hockeyappManager.Configure(HockeyAppConstants.iOSHockeyAppID);
			hockeyappManager.LogLevel = BITLogLevel.Debug;
			hockeyappManager.StartManager();
			hockeyappManager.Authenticator.AuthenticateInstallation();
			hockeyappManager.UpdateManager.CheckForUpdateOnLaunch = true;

			navController = new UINavigationController();

			homeViewController = new Screens.HomeScreen();

			navController.NavigationBar.TintColor = UIColor.FromRGB(0x6F, 0xA2, 0x2E); 
			navController.NavigationBar.BarTintColor = UIColor.FromRGB(0xCF, 0xEF, 0xA7);

			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				TextColor = UIColor.FromRGB(0x6F, 0xA2, 0x2E), 
				TextShadowColor = UIColor.Clear
			});

			navController.PushViewController(homeViewController, false);
			window.RootViewController = navController;
			window.MakeKeyAndVisible();

			return true;
		}
	}
}