using Foundation;
using System;
using UIKit;

namespace Guida.iOS
{
	//AntibioticInformation class display antibiotic information entered in AntibioticSearch page
    public partial class AntibioticInformation : UIViewController
    {
        public AntibioticInformation (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			//Display antibiotic information
			String info = "Name: " + Session.antibioticInformation.name + "\nPrice: $" + Session.antibioticInformation.price + "\nAcceptableUses: " + Session.antibioticInformation.acceptableUses + "\nToxicity: " + Session.antibioticInformation.toxicity;
			antibioticInformation.Text = info;
		}
    }

}