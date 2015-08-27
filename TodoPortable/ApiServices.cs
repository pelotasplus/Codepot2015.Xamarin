using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

namespace TodoPortable
{
	public class ApiServices
	{
		public static List<Item> FetchItems() {
			var api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");
			return api.GetItems("Token 30e4eb6453096eb7b92625c00cc8e35c289622cb").Result;
		}

		public static async Task<List<Item>> FetchItemsAsync() {
			var api = RestService.For<IApiInterface>("http://codepot.pelotaspl.us/");
			return await api.GetItems("Token 30e4eb6453096eb7b92625c00cc8e35c289622cb");
		}
	}
}