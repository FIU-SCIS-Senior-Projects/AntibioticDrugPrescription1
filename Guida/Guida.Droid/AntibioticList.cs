
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
	[Activity(Label = "AntibioticList")]
	public class AntibioticList : Activity
	{
		Button antibioticPrescription, patientInformation, searchAntibiotic, logout;
		TextView label;
		TextView user, patient;
		List<string> antibitoics;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.AntibioticList);
			// Create your application here
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button
			label = FindViewById<TextView>(Resource.Id.antibioticListTitleText);
			logout = FindViewById<Button>(Resource.Id.logout);
			user = FindViewById<TextView>(Resource.Id.currentUser);
			patient = FindViewById<TextView>(Resource.Id.currentPatient);


			label.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			logout.SetBackgroundColor(Android.Graphics.Color.DarkCyan);
			patientInformation.SetBackgroundColor(Android.Graphics.Color.Transparent);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.Transparent);
			user.Text = "Doctor: " + Session.user.username;
			if (Session.selectedPatient == null) patient.Text = "Patient: Not Selected";
			else patient.Text = "Patient: " + Session.selectedPatient.name;


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
			logout.Click += delegate
			{
				StartActivity(typeof(MainActivity));
				//clear user below
				// [add later]
			};
			//if Antibiotic Prescription button is clicked, move to AntibioticPrescription activity
			antibioticPrescription.Click += delegate
			{
				StartActivity(typeof(AntibioticPrescription));
			};


			RuleEngine re = new RuleEngine();
			string a = re.determineAntibiotic(Session.selectedArea.name);

			char[] delim = { ',' };
			ListView antibioticList = FindViewById<ListView>(Resource.Id.antibioticListView);
			string[] ab = a.Split(delim);
			antibitoics = new List<string>();
			foreach (string s in ab)
			{
				antibitoics.Add(s);
			}
			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemSingleChoice, antibitoics);
			antibioticList.Adapter = adapter;
			antibioticList.ItemClick += lista_ItemClicked;
		}

		void lista_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			Session.antibioticInformation = Controller.getAntibiotic(antibitoics.ElementAt(e.Position));
			StartActivity(typeof(AntibioticInformation));
		}
	}
}

