using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Guida.iOS
{

	public partial class AntibioticList : UIViewController
	{
		List<String> ant;
		UITableView antibioticTable;

		public AntibioticList(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			ant = new List<string>();
			if (Session.antibioticInformation.name != null)
			{
				ant.Add(Session.antibioticInformation.name);
			}
			//List of names from the list of infections
			//var names = new List<string>();
			//foreach (Disease x in diseases)
			//{
			//	names.Add(x.name);
			//}

			//Create table to insert the name of the patients
			antibioticTable = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableAntibiotics(ant, this)
			};

			//Display table
			View.AddSubview(antibioticTable);

		}
	}
}