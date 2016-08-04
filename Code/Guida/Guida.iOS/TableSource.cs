using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace Guida.iOS
{
	//This class is used to create a list  of patients for PatientList page
	public class TableSource: UITableViewSource
	{
		//Variables
		List<Patient> tableItems;
		string cellIdentifier = "Patients";
		PatientList parent; 

		public TableSource(List<Patient> items, PatientList p)
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
			cell.TextLabel.Text = tableItems[indexPath.Row].name;

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
			//Store patient selected to display his information on next page
			Session.selectedPatient = tableItems[indexPath.Row];

			//Go to next page
			UIViewController home = parent.Storyboard.InstantiateViewController("PatientInformation") as PatientInformation;
			parent.NavigationController.PushViewController(home, true);

			//Unselect row
			tableView.DeselectRow(indexPath, true);
		}
	}
}

