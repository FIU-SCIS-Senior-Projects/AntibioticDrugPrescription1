
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
	[Activity(Label = "Home")]
	public class Home : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			// Create your application here
			SetContentView(Resource.Layout.Home);
			Button bodyParts = FindViewById<Button>(Resource.Id.bodyButton);
			Button patientInfo = FindViewById<Button>(Resource.Id.patientInfoButton);
			Button searchAntibiotic = FindViewById<Button>(Resource.Id.searchAntibioticButton);

			bodyParts.Click += delegate
			{
				SetContentView(Resource.Layout.BodyParts);
			};
			patientInfo.Click += delegate
			{
				StartActivity(typeof(PList));
			};
			searchAntibiotic.Click += delegate
			{
				//Sean add code here
			};
		}
	}
}

