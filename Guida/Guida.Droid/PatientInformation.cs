
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
	//PatientInfo Activity. It display the information of the patient selected in PatientList
	[Activity(Label = "Patient Information")]
	public class PatientInformation : Activity
	{
		//Layout Variables
		TextView patientInfo;
		TextView patientInfo2;
		TextView patientName;
		Button antibioticPrescription, patientInformation, searchAntibiotic;
		Button logout;
		TextView label;
		TextView user, patient;
		//LinearLayout t;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to PatientInfo Layout
			SetContentView(Resource.Layout.PatientInformation);

			//Initialize variables
			patientName = FindViewById<TextView>(Resource.Id.displayPatientName);
			patientInfo = FindViewById<TextView>(Resource.Id.displayPatientInfo);
			patientInfo2 = FindViewById<TextView>(Resource.Id.displayPatientInfo2);
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button
			label = FindViewById<TextView>(Resource.Id.textView1);
			logout = FindViewById<Button>(Resource.Id.logout);
			user = FindViewById<TextView>(Resource.Id.currentUser);
			patient = FindViewById<TextView>(Resource.Id.currentPatient);
			//t = FindViewById<LinearLayout>(Resource.Id.table);

			label.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			logout.SetBackgroundColor(Android.Graphics.Color.DarkCyan);
			patientInformation.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.Transparent);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.Transparent);
			//t.SetBackgroundColor(Android.Graphics.Color.Transparent);
			patientName.SetTextColor(Android.Graphics.Color.White);
			patientInfo.SetTextColor(Android.Graphics.Color.White);
			patientInfo2.SetTextColor(Android.Graphics.Color.White);

			user.Text = "Doctor: " + Session.user.username;
			if (Session.selectedPatient == null) patient.Text = "Patient: Not Selected";
			else patient.Text = "Patient: " + Session.selectedPatient.name;

			Controller.patientSelected(Session.selectedPatient.condition);

			patientInformation.Click += delegate {
				StartActivity(typeof(PatientList));
			};
			//if Antibiotic Prescription button is clicked, move to AntibioticPrescription activity
			antibioticPrescription.Click += delegate
			{
				StartActivity(typeof(AntibioticPrescription));
			};

			//if Search Antibiotic button is clicked, move to AntibioticSearch activity
			searchAntibiotic.Click += delegate
			{
				StartActivity(typeof(AntibioticSearch));
			};
			logout.Click += delegate
			{
				StartActivity(typeof(MainActivity));
				//clear user below
				// [add later]
			};
			//Display information
			patientName.Text = Session.selectedPatient.name + " " + Session.selectedPatient.lastName ;
			string displayInfo = "";
			string displayInfo2 = "";
			displayInfo += "First Name: \n";
			displayInfo2 += Session.selectedPatient.name + "\n";
			displayInfo += "Last Name: \n";
			displayInfo2 += Session.selectedPatient.lastName + "\n";
			displayInfo += "Date of Birth: \n";
			displayInfo2 += Session.selectedPatient.DoB + "\n";
			foreach (KeyValuePair<string, string> entry in Session.patientData)
			{
				displayInfo += entry.Key + ": \n";
				displayInfo2 += entry.Value + "\n";
			}
			patientInfo.Text = displayInfo;
			patientInfo2.Text = displayInfo2;
		}
	}
}

//acquired == community
//acquired == hospital
//severely ill == true
//severely ill == false
//pcn allergy == no
//pcn allergy == severe
//pcn allergy == non severe