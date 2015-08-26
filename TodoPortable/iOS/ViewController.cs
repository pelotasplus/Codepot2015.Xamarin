using System;
		
using UIKit;
using CoreGraphics;

namespace TodoPortable.iOS
{
	public partial class ViewController : UIViewController
	{
		UITableView table;

		public ViewController (IntPtr handle) : base (handle)
		{		
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif

			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			table = new UITableView(new CGRect(0, 0, width, height));
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = new ItemsSource ();
			Add (table);
		}
	}
}
