using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Guida.iOS
{

    public partial class Infections : UIViewController
    {
		List<Disease> diseases;
		UITableView infectionTable;

        public Infections (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			diseases = Controller.getDisease(Session.selectedArea.affectedArea);
			//List of names from the list of infections
			var names = new List<string>();
			foreach (Disease x in diseases)
			{
				names.Add(x.name);
			}

			//Create table to insert the name of the patients
			infectionTable = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableInfections(names, this)
			};

			//Display table
			View.AddSubview(infectionTable);

		}
    }
}