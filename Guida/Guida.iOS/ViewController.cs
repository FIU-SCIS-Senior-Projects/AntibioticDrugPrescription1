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
			ApplicationFacade log = new ApplicationFacade();
			Login.TouchUpInside += (object sender, EventArgs e) => {
				if (log.logIn(Username.Text,Password.Text)){
					
					//Login.SetTitle("Logged in!",UIControlState.Normal);
					UIViewController home = Storyboard.InstantiateViewController ("HomeViewController") as HomeViewController;
					this.NavigationController.PushViewController (home, true);
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

