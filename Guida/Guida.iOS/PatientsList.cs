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

			List<string> data = control.patientsList("Alan");;
;
			PTable = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSource(data)
			};
			View.AddSubview(PTable);

			/*SearchAntibiotic.TouchUpInside += delegate
			{
				String antibioticName = AntibioticName.Text;
				Antibiotic found = control.getAntibiotic(antibioticName);
				if (found != null)
				{

					String info = "Name: " + found.name + "\nPrice: $" + found.price + "\nAcceptableUses: " + found.acceptableUses + "\nToxicity: " + found.toxicity;
					AntibioticInfo.Text = info;
				}
			};*/
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
    }
}