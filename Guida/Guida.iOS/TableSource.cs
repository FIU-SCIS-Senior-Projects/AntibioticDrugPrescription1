using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace Guida.iOS
{
	public class TableSource: UITableViewSource
	{
		
		List<string> tableItems;
		string cellIdentifier = "Patients";

		public TableSource(List<string> items)
		{
			tableItems = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}
			cell.TextLabel.Text = tableItems[indexPath.Row];
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return 3;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//base.RowSelected(tableView, indexPath);
			new UIAlertView("Patient Info", "Name:" + tableItems[indexPath.Row], null, "OK", null).Show();
			tableView.DeselectRow(indexPath, true);
		}

	}
}

