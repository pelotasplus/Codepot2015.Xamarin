using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;

namespace TodoPortable.Droid
{
	public class ItemsLoader : AsyncTaskLoader
	{
		public ItemsLoader (Context context) : base(context)
		{
		}


		public override Java.Lang.Object LoadInBackground ()
		{
			try {
				List<Item> ret = ApiServices.FetchItems();
				return new JavaList<Item>(ret);
			} catch (Exception e) {
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

