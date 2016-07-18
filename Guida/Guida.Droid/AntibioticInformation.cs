
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
		Button antibioticPrescription, patientInformation, searchAntibiotic, logout;
		TextView information;
		TextView label;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AntibioticSearch Layout
			SetContentView(Resource.Layout.AntibioticInformation);

			//Initialize variables
			name = FindViewById<TextView>(Resource.Id.antibioticNameText);
			information = FindViewById<TextView>(Resource.Id.antibioticInfoText);
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button

			patientInformation.SetBackgroundColor(Android.Graphics.Color.Transparent);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.Transparent);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			label.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			logout.SetBackgroundColor(Android.Graphics.Color.DarkCyan);

			//if Antibiotic Prescription button is clicked, move to AntibioticPrescription activity
			antibioticPrescription.Click += delegate
			{
				StartActivity(typeof(AntibioticPrescription));
			};

			//if Patient Information button is clicked, move to PList activity
			patientInformation.Click += delegate
			{
				StartActivity(typeof(PatientList));
			};
			logout.Click += delegate
			{
				StartActivity(typeof(MainActivity));
				//clear user below
				// [add later]
			};

			//Display information
			name.Text = Session.antibioticInformation.name;
			String info = "Price: $" + Session.antibioticInformation.price + "\nAcceptableUses: " + Session.antibioticInformation.acceptableUses 
                          + "\nToxicity: " + Session.antibioticInformation.toxicity;
			information.Text = info;
		}
	}
}

