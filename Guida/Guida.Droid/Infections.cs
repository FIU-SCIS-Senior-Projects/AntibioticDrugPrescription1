
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
	[Activity(Label = "Infections")]
	public class Infections : Activity
	{
		TextView step;
		ListView list;
		List<Disease> d;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//Set content view to AbdominalInfection Layout
			SetContentView(Resource.Layout.Infections);

			step = FindViewById<TextView>(Resource.Id.infoLabel);
			step.Text = "Type of Infection";

			d = Controller.getDisease(Session.selectedArea.affectedArea);

			list = FindViewById<ListView>(Resource.Id.listView1);

			//List of names from the list of infections
			var names = new List<string>();
			foreach (Disease x in d)
			{
				names.Add(x.name);
			}

			//Display names of the infections in a list
			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, names);
			list.Adapter = adapter;
			list.ItemClick += listp_ItemClicked;


		}
		//if a infection is selected, display antibiotic's information
		void listp_ItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			RuleEngine re = new RuleEngine();
			Antibiotic a = re.determineAntibiotic(d[e.Position].name);
			if (a != null)
			{
				Session.antibioticInformation = a;
				StartActivity(typeof(AntibioticInformation));
			}
			else {
				step.Text = "Antibiotic for " + d[e.Position].name + " not found";
			}
		}
	}
}


