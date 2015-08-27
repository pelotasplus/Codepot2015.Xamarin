using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace TodoPortable.iOS {
	public class ItemsSource : UITableViewSource {
		
		protected List<Item> items;
		protected string cellIdentifier = "TableCell";
//		HomeScreen owner;

		public ItemsSource ()
		{
			items = new List<Item> ();
//			this.owner = owner;
		}

		public void AddItems(List<Item> items)
		{
			this.items = items;
//			this.owjn
		}
		
		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return items.Count;
		}
		
		/// <summary>
		/// Called when a row is touched
		/// </summary>
//		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
//		{
//			UIAlertController okAlertController = UIAlertController.Create ("Row Selected", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);
//			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
//			owner.PresentViewController (okAlertController, true, null);
//
//			tableView.DeselectRow (indexPath, true);
//		}
		
		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			Item item = items[indexPath.Row];
			
			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			}
			
			cell.TextLabel.Text = item.Name;
			
			return cell;
		}
			
//		public override string TitleForHeader (UITableView tableView, nint section)
//		{
//			return " ";
//		}
	}
}