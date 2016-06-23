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
    [Activity(Label = "AntibioticSearch")]
    public class AntibioticSearch : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AntibioticSearch);
            Controller control = new Controller();
            Button searchButton = FindViewById<Button>(Resource.Id.antibioticSearchButton);
            EditText nameField = FindViewById<EditText>(Resource.Id.antibitoicSearchField);

            searchButton.Click += delegate
            {
                String antibioticName = nameField.Text;
                Antibiotic found = control.getAntibiotic(antibioticName);
                if(found != null)
                {
                    SetContentView(Resource.Layout.AntibioticInformation);
                    
                    TextView name = FindViewById<TextView>(Resource.Id.antibioticNameText);
                    TextView information = FindViewById<TextView>(Resource.Id.antibioticInfoText);
                    name.Text = found.name;
                    String info = "Price: $" + found.price + "\nAcceptableUses: " + found.acceptableUses + "\nToxicity: " + found.toxicity;
                    information.Text = info;
                }
            };
        }
    }
}