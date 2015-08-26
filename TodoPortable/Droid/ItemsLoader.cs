using System;
using System.Collections.Generic;
using Refit;
using Android.Content;
using Android.Runtime;
using System.Threading.Tasks;

namespace TodoPortable.Droid
{
	public class ItemsLoader : Android.Content.AsyncTaskLoader
	{
		public ItemsLoader (Context context) : base(context)
		{
		}

		private Task<List<Item>> doQuery() {
			var api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");
			return api.GetItems("Token 30e4eb6453096eb7b92625c00cc8e35c289622cb");
		}

		public override Java.Lang.Object LoadInBackground ()
		{
			try {
				List<Item> ret = doQuery().Result;
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