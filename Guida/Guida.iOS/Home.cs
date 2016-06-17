using System;

using UIKit;

namespace Guida.iOS
{
	public partial class Home : UIViewController
	{
		public Home(IntPtr handle) : base (handle)
		{
			
		}

		public Home() : base("Home", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			BodyParts.TouchUpInside += (object sender, EventArgs e) =>
			{
				UIViewController home = Storyboard.InstantiateViewController("HomeViewController") as HomeViewController;
				this.NavigationController.PushViewController(home, true);
			};
			PatientsInfo.TouchUpInside += (object sender, EventArgs e) =>
			{
				UIViewController home = Storyboard.InstantiateViewController("HomeViewController") as HomeViewController;
				this.NavigationController.PushViewController(home, true);
			};
			SearchAntibiotic.TouchUpInside += (object sender, EventArgs e) =>
			{
				UIViewController home = Storyboard.InstantiateViewController("AntibioticSearch") as AntibioticSearch;
				this.NavigationController.PushViewController(home, true);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


