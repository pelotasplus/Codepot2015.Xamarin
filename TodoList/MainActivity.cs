using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;


namespace TodoList
{
	[Activity (Label = "TodoList", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		RecyclerView mRecyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			mRecyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);

			mLayoutManager = new LinearLayoutManager (this);

			mRecyclerView.SetLayoutManager (mLayoutManager);
		}
	}
}
