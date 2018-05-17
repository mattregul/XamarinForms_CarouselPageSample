using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Foundation;
using UIKit;

namespace XamarinForms_CarouselPageSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			//AppCenter.Start("ios=<<Your AppCenter Key Here>>;" +
			//	  "uwp={Your UWP App secret here};" +
			//	  "android={Your Android App secret here}",
			//				typeof(Analytics), typeof(Crashes));

			    #if ENABLE_TEST_CLOUD
                Xamarin.Calabash.Start();
                #endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

