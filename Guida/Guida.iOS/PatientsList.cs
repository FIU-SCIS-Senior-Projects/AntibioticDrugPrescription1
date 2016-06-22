using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Guida.iOS
{
    public partial class PatientsList : UIViewController
    {
        public PatientsList (IntPtr handle) : base (handle)
        {
        }

		public PatientsList() : base("PatientsList", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Controller control = new Controller();

			UITableView PTable;

			List<string> data = control.patientsList(Session.user.username);
			//List<string> ids = control.patientsIDList(User.doc.username);
;
			PTable = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSource(data,this)
			};
			View.AddSubview(PTable);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
    }
}