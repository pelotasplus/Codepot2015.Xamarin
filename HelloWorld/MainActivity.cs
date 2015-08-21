using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Views;

namespace HelloWorld
{
	[Activity (Label = "HelloWorld", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, View.IOnClickListener
	{
		static string TAG = "MainActivity";
		static string EXTRA_COUNT = TAG + "/EXTRA_COUNT";

		int count = 0;

		Button button;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += delegate {
				Log.Error(TAG, "First delegate!");
				count++;
				UpdateCountsView ();
			};

			button.Click += (sender, e) => {
				Log.Error(TAG, "Second delegate!");
			};

//			button.SetOnClickListener (this);

			if (bundle != null) {
				count = bundle.GetInt (EXTRA_COUNT, 0);
				UpdateCountsView ();
			}
		}

		private void UpdateCountsView ()
		{
			if (count <= 0)
				return;
			button.Text = string.Format ("{0} clicks!", count);
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			outState.PutInt (EXTRA_COUNT, count);

			base.OnSaveInstanceState (outState);
		}

		public void OnClick (View v)
		{
			Log.Debug (TAG, "OnClick");
		}
	}
}


