
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
		TextView patientInformation;
		TextView patientName;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to PatientInfo Layout
			SetContentView(Resource.Layout.PatientInformation);

			//Initialize variables
			patientName = FindViewById<TextView>(Resource.Id.displayPatientName);
			patientInformation = FindViewById<TextView>(Resource.Id.displayPatientInfo);

			//Display information
			patientName.Text = Session.selectedPatient.name;
			patientInformation.Text = "Patient ID: " + Session.selectedPatient.id + "\nDoB: " + Session.selectedPatient.DoB;
		}
	}
}

