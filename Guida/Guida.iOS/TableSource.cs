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
		PatientsList parent; 

		public TableSource(List<string> items, PatientsList p)
		{
			tableItems = items;
			parent = p;
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
			return tableItems.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//base.RowSelected(tableView, indexPath);
			//new UIAlertView("Patient Info", "Name:" + tableItems[indexPath.Row], null, "OK", null).Show()
			Controller mc = new Controller();
			mc.patientExist(indexPath.Row + 1);
			UIViewController home = parent.Storyboard.InstantiateViewController("PatientInfo") as PatientInfo;
			parent.NavigationController.PushViewController(home, true);
			tableView.DeselectRow(indexPath, true);
		}

	}
}

