using Foundation;
using System;
using UIKit;

namespace Guida.iOS
{
	//PatientInformation Class display patient information selected previously in PatientList page
	public partial class PatientInformation : UIViewController
	{
		public PatientInformation(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			patientInformation.Text = "ID: " + Session.selectedPatient.id + "\nEnter " + Session.selectedPatient.name + " information here!";
		}
	}
}