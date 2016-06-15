
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
		private List<string> patients;
		private ListView listp;
		private string user;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ListP);
			user = Intent.GetStringExtra("Data") ?? "Data not available";
			Controller mc = new Controller();
			patients = mc.patientsList(user);
			listp = FindViewById<ListView>(Resource.Id.listView1);
			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, patients);
			listp.Adapter = adapter;
			listp.ItemClick += listp_ItemClicked;
		}

		void listp_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{

			var pinfo = new Intent(this, typeof(PatientInfo));
			pinfo.PutExtra("Data", patients[e.Position]);
			StartActivity(pinfo);
			//Console.WriteLine(patients[e.Position]);
		}
	}
}

