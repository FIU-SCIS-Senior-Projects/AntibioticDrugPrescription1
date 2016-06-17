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
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


