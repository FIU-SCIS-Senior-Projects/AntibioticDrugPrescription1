
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
	[Activity(Label = "PatientInfo")]
	public class PatientInfo : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.PInfo);
			// Create your application here
			string user = Intent.GetStringExtra("Data") ?? "Data not available";
			string id = Intent.GetStringExtra("ID") ?? "Data not available";
			TextView listp = FindViewById<TextView>(Resource.Id.textView1);
			listp.Text = "ID: " + id + " Enter " + user + " information here!";
		}
	}
}

