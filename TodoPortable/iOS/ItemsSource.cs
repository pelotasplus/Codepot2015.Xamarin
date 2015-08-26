using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace TodoPortable.iOS
{
	public class ItemsSource : UITableViewSource {

		List<Item> items;
		string CellIdentifier = "TableCell";

		public ItemsSource ()
		{
			items = new List<Item> ();
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);

			Item item = items[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
			}

			cell.TextLabel.Text = item.Name;

			return cell;
		}
	}
}