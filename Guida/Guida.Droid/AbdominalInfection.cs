
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
	[Activity(Label = "AbdominalInfection")]
	public class AbdominalInfection : Activity
	{
		TextView step;

		//Spinner input;
		RadioButton biliary;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AbdominalInfection Layout
			SetContentView(Resource.Layout.AbdominalInfection);

			step = FindViewById<TextView>(Resource.Id.infoLabel);  
			//input = FindViewById<Spinner>(Resource.Id.infoSpinner); 
			biliary = FindViewById<RadioButton>(Resource.Id.biliary);

			step.Text = "Type of Infection";
			//var infections = new string []{ "Choose one", "Biliary Track", "Diverticulitis", "Pancreatitis", "Peritonitis" };
			//input.Adapter=new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleSpinnerItem,infections);

			biliary.Click += (s,e) =>
			{
				//if (item == "Biliary Track") rule1(item);
				if (biliary.Text == "Biliary Track Infection")
				{
					RuleEngine re = new RuleEngine();
					Antibiotic a = re.determineAntibiotic(biliary.Text);
					if(a != null)
						step.Text = a.name;
					else step.Text = "Not found";
				}
			};

		}

		/*
		public void rule1(string item)
		{
			if (item == "Biliary Track")
			{
				step.Text = "Select one";
				var options = new string[] { "Choose one", "Community Acquired Infection AND no severely Ill", "Hospital Acquired Infection", "Severely Ill", "Multiple Therapeutic Biliary Manipulations" };
				input.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, options);
				input.ItemSelected += (s, e) =>
				{
					string option = e.Parent.GetItemAtPosition(e.Position).ToString();
					if (option != "Choose one")
						rule2(option);
				};
			}
		}

		public void rule2(string option)
		{
			if (option == "Community Acquired Infection AND no severely Ill")
			{
				step.Text = "PCN allergy?";
				var options = new string[] { "Choose one", "Severe", "No allergy" };
				input.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, options);
				input.ItemSelected += (s, e) =>
				{
					string allergy = e.Parent.GetItemAtPosition(e.Position).ToString();
					if (option != "Choose one")
						rule3(allergy);
				};
			}


		}

		public void rule3(string option)
		{
			
			if (option == "No allergy")
			{
				step.Text = "Antibiotic Prescription";
				var antibiotics = new string[] { "Prescriptions", "Ceftriaxone", "Ertapenem" };
				input.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, antibiotics);
			}
		}
*/
	}


}

