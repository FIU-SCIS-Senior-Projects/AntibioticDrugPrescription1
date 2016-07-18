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
	[Activity(Label = "AntibioticSearch")]
    public class AntibioticSearch : Activity
    {
		//Layout Variables
		EditText nameField;
		Button searchButton;
		Button antibioticPrescription, patientInformation, searchAntibiotic;
		Button logout;
		TextView label;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			//Set content view to AntibioticSearch Layout
			SetContentView(Resource.Layout.AntibioticSearch);

			//Initialize Variables
			nameField = FindViewById<EditText>(Resource.Id.antibitoicSearchField);		//Name of the antibiotic text box
            searchButton = FindViewById<Button>(Resource.Id.antibioticSearchButton);	//Search for antibiotic button
            antibioticPrescription = FindViewById<Button>(Resource.Id.antibioticPrescriptionButton);    //Antibiotic Prescription button
			patientInformation = FindViewById<Button>(Resource.Id.patientInformationButton);            //Patient Information button
			searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);                //Search Antibiotic button
			label = FindViewById<TextView>(Resource.Id.textView1);
			logout = FindViewById<Button>(Resource.Id.logout);

			label.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			logout.SetBackgroundColor(Android.Graphics.Color.DarkCyan);
			patientInformation.SetBackgroundColor(Android.Graphics.Color.Transparent);
			antibioticPrescription.SetBackgroundColor(Android.Graphics.Color.Transparent);
			searchAntibiotic.SetBackgroundColor(Android.Graphics.Color.DarkRed);
			searchButton.SetBackgroundColor(Android.Graphics.Color.DarkGray);

			nameField.Click += delegate {
				nameField.Text = "";
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

			//Search for the antibiatic entered in nameField on the database to display its information
            searchButton.Click += delegate
            {
				//Search for antibiotic on the database
				Antibiotic found = Controller.getAntibiotic(nameField.Text);

				//if antibiotic exists, display information in next layout
				if(found != null)
                {
					//Save antibiotic information
					Session.antibioticInformation = found;

					//Display antibiotic information in the next activity
					StartActivity(typeof(AntibioticInformation));
                }
            };
        }
    }
}