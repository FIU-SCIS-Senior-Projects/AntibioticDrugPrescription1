
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
	//Home Activity. It let the user select next activity desired.
	[Activity(Label = "test")]
	public class Home : Activity
	{
		//Layout Variables
		Button antibioticPrescription, patientInformation, searchAntibiotic;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to Home Layout
			SetContentView(Resource.Layout.Home);

			//Initialize layout variables
			//---------------------------
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);	//Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);			//Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);				//Search Antibiotic button

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

			//if Search Antibiotic button is clicked, move to AntibioticSearch activity
			searchAntibiotic.Click += delegate
			{
                StartActivity(typeof(AntibioticSearch));
			};
		}
	}
}

