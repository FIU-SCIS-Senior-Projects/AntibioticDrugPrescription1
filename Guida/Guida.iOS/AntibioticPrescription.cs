using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Guida.iOS
{
	//Initial page to start to search for the correct antibiotic for a patient
	partial class AntibioticPrescription : UIViewController
	{
		//Next page
		UIViewController next;

		public AntibioticPrescription(IntPtr handle) : base(handle)
		{


		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Antibiotic Prescription button is clicked. Go to Antibiotic Prescription page
			abs.TouchUpInside += (object sender, EventArgs e) =>
			{
				next = Storyboard.InstantiateViewController("Infections") as Infections;
				Disease d = new Disease();
				d.name = "Not selected yet";
				d.affectedArea = "Abdominal Infection";
				Session.selectedArea = d;
				this.NavigationController.PushViewController(next, true);
			};

			//Patient List button is clicked. Go to Patient List page
			lung.TouchUpInside += (object sender, EventArgs e) =>
			{
				next = Storyboard.InstantiateViewController("Infections") as Infections;
				Disease d = new Disease();
				d.name = "Not selected yet";
				d.affectedArea = "Pulmonary Infection";
				Session.selectedArea = d;
				this.NavigationController.PushViewController(next, true);
			};

		}

	}
}
