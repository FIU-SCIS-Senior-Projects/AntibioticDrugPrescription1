using System;

using UIKit;

namespace Guida.iOS
{
	public partial class AntibioticSearch : UIViewController
	{
		public AntibioticSearch(IntPtr handle) : base (handle)
		{

		}

		public AntibioticSearch() : base("AntibioticSearch", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Controller control = new Controller();

			SearchAntibiotic.TouchUpInside += delegate
			{
				String antibioticName = AntibioticName.Text;
				Antibiotic found = control.getAntibiotic(antibioticName);
				if (found != null)
				{

					String info = "Name: "+ found.name + "\nPrice: $" + found.price + "\nAcceptableUses: " + found.acceptableUses + "\nToxicity: " + found.toxicity;
					AntibioticInfo.Text = info;
				}
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


