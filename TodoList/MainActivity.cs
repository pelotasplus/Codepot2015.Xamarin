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
		ItemAdapter mItemAdapter;
		var api;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			mItemAdapter = new ItemAdapter ();	
			mLayoutManager = new LinearLayoutManager (this);

			api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");

			mRecyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);
			mRecyclerView.SetLayoutManager (mLayoutManager);
			mRecyclerView.SetAdapter (mItemAdapter);

			var octocat = await api.GetItems("adadasdadoctocat");
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

//				itemView.Click += (sender, e) => listener (base.Position);
			}
		}

		public class ItemAdapter : RecyclerView.Adapter
		{
			public ItemAdapter ()
			{
			}

			public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
			{
				ItemViewHolder vh = holder as ItemViewHolder;

				vh.Name.Text = "Alek";
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
					return 10;
				}
			}
		}
	}
}
