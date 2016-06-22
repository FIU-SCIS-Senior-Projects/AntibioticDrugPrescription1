using Foundation;
using System;
using UIKit;

namespace Guida.iOS
{
    public partial class PatientInfo : UIViewController
    {
        public PatientInfo (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			Visits.Text = "ID: " + Session.selectedPatient.id + " Enter " + Session.selectedPatient.name + " information here!";
		}
    }
}