using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Guida.iOS
{
	//Patient List display a list of patients of the current user logged in
	public partial class PatientList : UIViewController
	{
		UITableView patientTable;	//Table to insert the name of the patients
		List<Patient> patientList;	//List of Patients

		public PatientList(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Get the List of patients of the current user logged in
			patientList = appSettings.getController().getPatientList(Session.user.username);

			//Create table to insert the name of the patients
			patientTable = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSource(patientList, this)
			};

			//Display table
			View.AddSubview(patientTable);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}