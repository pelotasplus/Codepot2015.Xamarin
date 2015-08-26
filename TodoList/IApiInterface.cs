using System;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoList
{
	public interface IApiInterface
	{
		[Get("/api/v1/items")]
		Task<List<Item>> GetItems ([Header("Authorization")] string authorization);

		[Get("/api/v1/items")]
		List<Item> GetItems2 ([Header("Authorization")] string authorization);

	}
}