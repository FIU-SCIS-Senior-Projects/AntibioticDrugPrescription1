using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace Guida.iOS
{
	//This class is used to create a list  of patients for PatientList page
	public class TableAntibiotics : UITableViewSource
	{
		//Variables
		List<string> tableItems;
		string cellIdentifier = "AntibioticList";
		AntibioticList parent;

		public TableAntibiotics(List<string> items, AntibioticList p)
		{
			tableItems = items;
			parent = p;
		}

		//Insert names in the cells of the list
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

		//Return the number of rows to be added
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		//If row is selected, go to Patient Information page 
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Session.antibioticInformation = Controller.getAntibiotic(tableItems[indexPath.Row]);
			UIViewController home = parent.Storyboard.InstantiateViewController("AntibioticInformation") as AntibioticInformation;
			parent.NavigationController.PushViewController(home, true);
		}
	}
}