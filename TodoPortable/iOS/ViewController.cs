using System;
		
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace TodoPortable.iOS
{
	public partial class ViewController : UIViewController
	{
		UITableView table;
		ItemsSource itemsSource;

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

			base.ViewDidLoad ();
			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			itemsSource = new ItemsSource ();

			table = new UITableView(new CGRect(0, 0, width, height));
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = itemsSource;
			Add (table);

			FetchItems ();
		}

		public async void FetchItems ()
		{
			List<Item> ret = await ApiServices.FetchItemsAsync();

			itemsSource.AddItems (ret);

			table.ReloadData ();
		}
	}
}
