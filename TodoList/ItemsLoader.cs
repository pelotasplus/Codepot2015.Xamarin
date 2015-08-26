using System;
using System.Collections.Generic;
using Android.Util;
using Refit;
using Android.Content;
using Android.Runtime;

namespace TodoList
{
	public class ItemsLoader : Android.Content.AsyncTaskLoader
	{
		string TAG = "ItemsLoader";

		public ItemsLoader (Context context) : base(context)
		{
		}

		public override Java.Lang.Object LoadInBackground ()
		{
			try {
				var api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");
				List<Item> ret = api.GetItems2("Token 30e4eb6453096eb7b92625c00cc8e35c289622cb");
				Log.Debug(TAG, "ret=" + ret);
//				JavaList<Item> list = new JavaList<Item>(ret);
//				Log.Debug(TAG, "ret size " + ret.Count + " list size " + list.Count);
//				return list;
				return null;
			} catch (Exception e) {
				Log.Debug (TAG, "st " + e.StackTrace);
				Log.Error (TAG, "Failed to catch media data", e);
				return null;
			}
		}

		protected override void OnStartLoading ()
		{
			base.OnStartLoading ();
			ForceLoad ();
		}

		protected override void OnStopLoading ()
		{
			CancelLoad ();
		}
	}
}

