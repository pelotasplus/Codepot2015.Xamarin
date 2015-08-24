using System;

namespace TodoList
{
	public class Item
	{
		public Boolean done;

		public String name;

		public Item ()
		{
		}

		public Item (bool done, string name)
		{
			this.done = done;
			this.name = name;
		}
		

		public bool Done {
			get {
				return this.done;
			}
		}

		public string Name {
			get {
				return this.name;
			}
		}
	}
}

