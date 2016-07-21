
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
	[Activity(Label = "Infections")]
	public class Infections : Activity
	{
		TextView step;
		ListView list;
		List<Disease> d;
		Button logout;
		TextView label;
		Button antibioticPrescription, patientInformation, searchAntibiotic;
		TextView user, patient;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AbdominalInfection Layout
			SetContentView(Resource.Layout.Infections);

			step = FindViewById<TextView>(Resource.Id.infoLabel2);
			antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button
			label = FindViewById<TextView>(Resource.Id.textView1);
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

			d = Controller.getDisease(Session.selectedArea.affectedArea);

			list = FindViewById<ListView>(Resource.Id.listView1);

			//List of names from the list of infections
			var names = new List<string>();
			foreach (Disease x in d)
			{
				names.Add(x.name);
			}

			//Display names of the infections in a list
			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemSingleChoice, names);
			list.Adapter = adapter;
			list.ItemClick += listp_ItemClicked;

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
		}
		//if a infection is selected, display antibiotic's information
		void listp_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			if (Session.selectedPatient == null)
			{
				step.Text ="Please, select a patient";
			}
			else {


				RuleEngine re = new RuleEngine();
				Antibiotic a = re.determineAntibiotic(d[e.Position].name);

				if (a != null)
				{
					Session.antibioticInformation = a;
					StartActivity(typeof(AntibioticInformation));
				}
				else {
					string missing = re.getMissing();
					step.Text = "Antibiotic for " + d[e.Position].name + " not found\nRequired Patient Data: " + missing;
			}
			}

		}
	}
}


