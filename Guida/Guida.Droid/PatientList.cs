
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
		List<Patient> patientList;	//List of Patients

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to PatientList Layout
			SetContentView(Resource.Layout.PatientList);

			//Initialize variables
			patientList = appSettings.getController().getPatientList(Session.user.username);	//List of patients of the current user logged in
			list = FindViewById<ListView>(Resource.Id.listView1);							//List to be displayed in the layout

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

