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



		public class ItemViewHolder : RecyclerView.ViewHolder
		{
			public ImageView Image { get; private set; }
			public TextView Name { get; private set; }

			public ItemViewHolder (View itemView, Action<int> listener) 
				: base (itemView)
			{
				Image = itemView.FindViewById<ImageView> (Resource.Id.textView);
				Name = itemView.FindViewById<TextView> (Resource.Id.textView);

//				itemView.Click += (sender, e) => listener (base.Position);
			}
		}
	}
}
