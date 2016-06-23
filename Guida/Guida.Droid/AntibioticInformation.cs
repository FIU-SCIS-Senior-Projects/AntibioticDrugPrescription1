
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Guida.Droid
{
	//AntibioticSearch Activity. It let the user search for an antibiotic
	[Activity(Label = "AntibioticInformation")]
	public class AntibioticInformation : Activity
	{
		//Layout Variables
		TextView name;
		TextView information;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AntibioticSearch Layout
			SetContentView(Resource.Layout.AntibioticInformation);

			//Initialize variables
			name = FindViewById<TextView>(Resource.Id.antibioticNameText);
			information = FindViewById<TextView>(Resource.Id.antibioticInfoText);

			//Display information
			name.Text = Session.antibioticInformation.name;
			String info = "Price: $" + Session.antibioticInformation.price + "\nAcceptableUses: " + Session.antibioticInformation.acceptableUses 
                          + "\nToxicity: " + Session.antibioticInformation.toxicity;
			information.Text = info;
		}
	}
}

