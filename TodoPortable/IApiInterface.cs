using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoPortable
{
	public interface IApiInterface
	{
		[Get("/api/v1/items")]
		Task<List<Item>> GetItems ([Header("Authorization")] string authorization);
	}
}