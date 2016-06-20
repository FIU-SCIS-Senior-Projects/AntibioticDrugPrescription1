using System;

using UIKit;

namespace Guida.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Controller mc = new Controller();
			//DOCTORS
			mc.addUser("Alan", "12345");
			mc.addUser("Sean", "12345");
			mc.addUser("Mohsen", "12345");
			mc.addUser("Sadjadi", "12345");
			mc.addUser("Giri", "12345");
			mc.addUser("Trevor", "12345");

			//PATIENTS
			mc.addPatient("Sergio", "Jul");
			mc.addPatient("Karla", "Aug");
			mc.addPatient("Richard", "Jan");
			mc.addPatient("Evelyn", "Dec");
			mc.addPatient("Guillermo", "Oct");
			mc.addPatient("Eduardo", "Sep");

			//DOCTOR-PATIENT
			mc.addDoctorPatient(1, "Alan");
			mc.addDoctorPatient(2, "Alan");
			mc.addDoctorPatient(3, "Alan");
			mc.addDoctorPatient(4, "Sean");
			mc.addDoctorPatient(5, "Giri");
			mc.addDoctorPatient(6, "Trevor");

			//Antibiotic
			mc.addAntibiotic("Ab1", "Flu", 5, "100mg");
			mc.addAntibiotic("Pulmoderpoxifan", "Derp", 5, "100mg");

			//Visit
			//mc.addVisits(1, "01-05-16", "Sergio", "Thyru");
			//mc.addVisits(2, "02-05-16", "Karla", "Alan");
			//mc.addVisits(3, "03-05-16", "Richard", "Sean");
			//mc.addVisits(4, "04-05-16", "Everlyn", "Giri");
			//mc.addVisits(1, "02-05-16", "Sergio", "Trevor");

			Login.TouchUpInside += (object sender, EventArgs e) => {
				if (mc.logIn(Username.Text,Password.Text)){

					//Login.SetTitle("Logged in!",UIControlState.Normal);
					Username.Text = "";
					Password.Text = "";
					UIViewController home = Storyboard.InstantiateViewController ("Home") as Home;
					this.NavigationController.PushViewController(home, true);
				}
			};


		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

