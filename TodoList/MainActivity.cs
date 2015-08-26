using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Refit;


namespace TodoList
{
	[Activity (Label = "TodoList", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, LoaderManager.ILoaderCallbacks
	{
		string TAG = "MainActivity";

		RecyclerView mRecyclerView;
		RecyclerView.LayoutManager mLayoutManager;
		ItemAdapter mItemAdapter;
		Boolean loading;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			mItemAdapter = new ItemAdapter ();	
			mLayoutManager = new LinearLayoutManager (this);

			mRecyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);
			mRecyclerView.SetLayoutManager (mLayoutManager);
			mRecyclerView.SetAdapter (mItemAdapter);

			FetchItems ();
//			LoaderManager.InitLoader (0, null, this);
		}

		public class ItemViewHolder : RecyclerView.ViewHolder
		{
			public ImageView Image { get; private set; }

			public TextView Name { get; private set; }

			public ItemViewHolder (View itemView) //, Action<int> listener)
				: base (itemView)
			{
				Image = itemView.FindViewById<ImageView> (Resource.Id.imageView);
				Name = itemView.FindViewById<TextView> (Resource.Id.textView);
			}
		}

		public class ItemAdapter : RecyclerView.Adapter
		{
			List<Item> items;

			public ItemAdapter ()
			{
				items = new List<Item>();
			}

			public void AddItems (List<Item> ret)
			{
				items = ret;
				NotifyDataSetChanged ();
			}

			public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
			{
				ItemViewHolder vh = holder as ItemViewHolder;

				Item item = items [position];

				vh.Name.Text = item.Name;
			}

			public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
			{
				View itemView = LayoutInflater.From (parent.Context).
					Inflate (Resource.Layout.ItemView, parent, false);

				ItemViewHolder vh = new ItemViewHolder (itemView); //, OnClick); 
				return vh;
			}

			public override int ItemCount {
				get {
					return items.Count;
				}
			}

			public void Clear() {
				items.Clear ();
			}
		}

		public async void FetchItems ()
		{
			if (loading)
				return;
			loading = true;

			try {
				var api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");
				List<Item> ret = await api.GetItems("Token 30e4eb6453096eb7b92625c00cc8e35c289622cb");
				mItemAdapter.AddItems (ret);
			} catch (Exception e) {
				Android.Util.Log.Error ("FetchItems", e.ToString ());
			}

			loading = false;
		}

		public Loader OnCreateLoader (int id, Bundle args)
		{
			return new ItemsLoader (this);
		}

		public void OnLoaderReset (Loader loader)
		{
			mItemAdapter.Clear ();
		}

		public void OnLoadFinished (Loader loader, Java.Lang.Object data)
		{
			JavaList<Item> itemsList = data as JavaList<Item>;
			Android.Util.Log.Debug (TAG, "OnLoadFinished '" + itemsList + "'");

//			List<Item> items = new List<Item> ();

//			for (int i = 0; i < itemsList.Count; i++) {
//				Item item = itemsList.Get(i) as Item;
//			}

//			mItemAdapter.AddItems (items);
		}
	}
}
