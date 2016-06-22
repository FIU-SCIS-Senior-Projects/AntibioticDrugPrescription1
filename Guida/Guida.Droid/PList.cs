
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
		List<string> patients;
		List<string> patientsID;
		ListView listp;
		Controller mc;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ListP);

			//Code
			mc = new Controller();
			patients = mc.patientsList(Session.user.username);
			patientsID = mc.patientsIDList(Session.user.username);
			listp = FindViewById<ListView>(Resource.Id.listView1);
			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, patients);
			listp.Adapter = adapter;
			listp.ItemClick += listp_ItemClicked;
		}

		void listp_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			if (mc.patientExist(Int32.Parse(patientsID[e.Position])))
			{
				StartActivity(typeof(PatientInfo));
			}
		}
	}
}

