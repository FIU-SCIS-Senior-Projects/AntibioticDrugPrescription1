using System;

using UIKit;

namespace Guida.iOS
{
	//This class allows the user to see all the pages the user can access
	public partial class Home : UIViewController
	{
		//Next page
		UIViewController next;

		public Home(IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Antibiotic Prescription button is clicked. Go to Antibiotic Prescription page
			antibioticPrescriptionButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				next = Storyboard.InstantiateViewController("AntibioticPrescription") as AntibioticPrescription;
				this.NavigationController.PushViewController(next, true);
			};

			//Patient List button is clicked. Go to Patient List page
			patientListButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				next = Storyboard.InstantiateViewController("PatientList") as PatientList;
				this.NavigationController.PushViewController(next, true);
			};

			//Search Antibiotic button is clicked. Go to Search Antibiotic page
			searchAntibioticButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				next = Storyboard.InstantiateViewController("AntibioticSearch") as AntibioticSearch;
				this.NavigationController.PushViewController(next, true);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


