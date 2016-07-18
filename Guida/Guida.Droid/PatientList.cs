
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
	//PatientList Activity. It display a list of patients of the current user logged in
	[Activity(Label = "PatientList")]
	public class PatientList : Activity
	{
		//Variables
		ListView list;				//Layout
		List<Patient> patientList;  //List of Patients
		Button antibioticPrescription, patientInformation, searchAntibiotic;
		Button logout;
		TextView label;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to PatientList Layout
			SetContentView(Resource.Layout.PatientList);

			//Initialize variables
			patientList = Controller.getPatientList(Session.user.username);	//List of patients of the current user logged in
			list = FindViewById<ListView>(Resource.Id.listView1);							//List to be displayed in the layout
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button
			label = FindViewById<TextView>(Resource.Id.textView1); 
			logout = FindViewById<Button>(Resource.Id.logout);

			label.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			logout.SetBackgroundColor(Android.Graphics.Color.DarkCyan);
			patientInformation.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.Transparent);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.Transparent);


			//List of names from the list of patients
			var names = new List<string>();
			foreach (Patient p in patientList)
			{
				names.Add(p.name);
			}

			//Display names of the patients in a list
			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, names);
			list.Adapter = adapter;
			list.ItemClick += listp_ItemClicked;

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

			logout.Click += delegate {
				StartActivity(typeof(MainActivity));
				//Session.user = null;
				//clear user below
				// [add later]
			};
		}

		//if a patient is selected, display patient's information
		void listp_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			//Save which patient was select
			Session.selectedPatient = patientList[e.Position];

			//Next activity. It display the patient information in another layout
			StartActivity(typeof(PatientInformation));
		}
	}
}

