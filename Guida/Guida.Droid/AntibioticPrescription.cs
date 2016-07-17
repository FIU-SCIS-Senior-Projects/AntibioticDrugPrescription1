﻿
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
		Button antibioticPrescription, patientInformation, searchAntibiotic;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AntibioticPrescription Layout
			SetContentView(Resource.Layout.AntibioticPrescription);

			//Initialize layout variables
			//---------------------------
			abs = FindViewById<ImageButton>(Resource.Id.absButton);    	//Abs button
			lung = FindViewById<ImageButton>(Resource.Id.lungButton);
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button

			patientInformation.SetBackgroundColor(Android.Graphics.Color.DarkBlue);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.DarkBlue);

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

