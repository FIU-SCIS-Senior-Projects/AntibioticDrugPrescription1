
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

	//Antibiotic Prescription Activity. It let you search for the right antibiotic for a patient
	[Activity(Label = "AntibioticPrescription")]
	public class AntibioticPrescription : Activity
	{
		//Layout Variables
		ImageButton abs, lung;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AntibioticPrescription Layout
			SetContentView(Resource.Layout.AntibioticPrescription);

			//Initialize layout variables
			//---------------------------
			abs = FindViewById<ImageButton>(Resource.Id.absButton);    	//Abs button
			lung = FindViewById<ImageButton>(Resource.Id.lungButton);

			//if abs button is clicked, move to AntibioticInfection activity
			abs.Click += delegate
			{
				Disease d = new Disease();
				d.name = "Not selected yet";
				d.affectedArea = "Abdominal Infection";
				Session.selectedArea = d;
				StartActivity(typeof(Infections));
			};

			lung.Click += delegate
			{
				Disease d = new Disease();
				d.name = "Not selected yet";
				d.affectedArea = "Pulmonary Infection";
				Session.selectedArea = d;
				StartActivity(typeof(Infections));
			};
		}
	}
}

