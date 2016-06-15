
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
	[Activity(Label = "PatientList")]
	public class PList : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ListP);
			Controller mc = new Controller();
			List<string> patients = mc.patientsList("Alan");

			ListView listp = FindViewById<ListView>(Resource.Id.listView1);
			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, patients);
			listp.Adapter = adapter;
		}
	}
}

