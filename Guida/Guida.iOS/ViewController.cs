using System;

using UIKit;

namespace Guida.iOS
{
	//First View Controller displayed when app is open for first time
	public partial class ViewController : UIViewController
	{
		//Next page
		UIViewController home;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Log in button is clicked
			loginButton.TouchUpInside += (object sender, EventArgs e) => {

				//if username and password is valid
				if (appSettings.GetController().logIn(usernameField.Text,passwordField.Text)){

					//Clear text
					usernameField.Text = "";
					passwordField.Text = "";

					//Go to next view controller
					home = Storyboard.InstantiateViewController ("Home") as Home;
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

