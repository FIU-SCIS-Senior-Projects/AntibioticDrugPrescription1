using System;

using UIKit;

namespace Guida.iOS
{
	public partial class AntibioticSearch : UIViewController
	{
		public AntibioticSearch(IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Search for antibiotic button is clicked
			searchButton.TouchUpInside += delegate
			{
				//Return the antibiotic entered in nameField text box 
				Antibiotic found = Controller.getAntibiotic(nameField.Text);

				//If antibiotic is found, display it
				if (found != null)
				{
					//Store antibiotic information to display on the next page
					Session.antibioticInformation = found;

					//Go to the next page
					UIViewController antibioticInformation = Storyboard.InstantiateViewController("AntibioticInformation") as AntibioticInformation;
					NavigationController.PushViewController(antibioticInformation, true);
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


