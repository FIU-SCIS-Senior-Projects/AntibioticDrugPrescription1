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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			//Set content view to AntibioticSearch Layout
			SetContentView(Resource.Layout.AntibioticSearch);

			//Initialize Variables
			nameField = FindViewById<EditText>(Resource.Id.antibitoicSearchField);		//Name of the antibiotic text box
            searchButton = FindViewById<Button>(Resource.Id.antibioticSearchButton);	//Search for antibiotic button
            
			//Search for the antibiatic entered in nameField on the database to display its information
            searchButton.Click += delegate
            {
				//Search for antibiotic on the database
				Antibiotic found = appSettings.getController().getAntibiotic(nameField.Text);

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