
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
		Button antibioticPrescription, patientInformation, searchAntibiotic, logout;
		//TextView information;
		TextView label;
		TextView user, patient;
		TextView antibioticInfo;
		TextView antibioticInfo2;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate(savedInstanceState);

			//Set content view to AntibioticSearch Layout
			SetContentView(Resource.Layout.AntibioticInformation);

			//Initialize variables
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button
			user = FindViewById<TextView>(Resource.Id.currentUser);
			patient = FindViewById<TextView>(Resource.Id.currentPatient);
			label = FindViewById<TextView>(Resource.Id.textView1);
			logout = FindViewById<Button>(Resource.Id.logout);
			antibioticInfo = FindViewById<TextView>(Resource.Id.antibioticInfoText);
			antibioticInfo2 = FindViewById<TextView>(Resource.Id.antibioticInfoText2);

			patientInformation.SetBackgroundColor(Android.Graphics.Color.Transparent);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.Transparent);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			label.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			logout.SetBackgroundColor(Android.Graphics.Color.DarkCyan);
			antibioticInfo.SetTextColor(Android.Graphics.Color.White);
			antibioticInfo2.SetTextColor(Android.Graphics.Color.White);
			label.Text = Session.antibioticInformation.name;

			user.Text = "Doctor: " + Session.user.username;
			if (Session.selectedPatient == null) patient.Text = "Patient: Not Selected";
			else patient.Text = "Patient: " + Session.selectedPatient.name;

			//if Search Antibiotic button is clicked, move to AntibioticSearch activity
			searchAntibiotic.Click += delegate
			{
				StartActivity(typeof(AntibioticSearch));
			};

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

			string displayInfo = "";
			string displayInfo2 = "";
			displayInfo += "Name: \n";
			displayInfo2 += Session.antibioticInformation.name + "\n";
			displayInfo += "Price: \n";
			displayInfo2 += "$" + Session.antibioticInformation.price + "\n";
			displayInfo += "Acceptable uses: \n";
			displayInfo2 += Session.antibioticInformation.acceptableUses + "\n";
			displayInfo += "Toxicity: \n";
			displayInfo2 += Session.antibioticInformation.toxicity + "\n";

			antibioticInfo.Text = displayInfo;
			antibioticInfo2.Text = displayInfo2;

		}
	}
}

