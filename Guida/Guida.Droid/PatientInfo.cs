
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

			TextView listp = FindViewById<TextView>(Resource.Id.textView1);
			listp.Text = "ID: " + User.patInfo.id + " Enter " + User.patInfo.name + " information here!";
		}
	}
}

