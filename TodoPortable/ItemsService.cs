using System;
using System.Collections.Generic;

namespace TodoPortable
{
	public class ItemsService
	{
		Boolean loading;

		public ItemsService ()
		{
		}

		public async void FetchItems ()
		{
			if (loading)
				return;
			loading = true;

			try {
				var api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");
				List<Item> ret = await api.GetItems("Token 30e4eb6453096eb7b92625c00cc8e35c289622cb");
//				mItemAdapter.AddItems (ret);
			} catch (Exception e) {
				Android.Util.Log.Error ("FetchItems", e.ToString ());
			}

			loading = false;
		}
	}
}

