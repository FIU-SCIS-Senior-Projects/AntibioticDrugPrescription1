using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Guida.Droid
{
	[Activity (Label = "Guida.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button loginButton = FindViewById<Button> (Resource.Id.loginButton);
            EditText usernameField = FindViewById<EditText>(Resource.Id.usernameField);
            EditText passwordField = FindViewById<EditText>(Resource.Id.passwordField);
            TextView authStatus = FindViewById<TextView>(Resource.Id.authStatusText);

            Controller mc = new Controller();

			//DOCTORS
			mc.addUser("Alan", "12345");
			mc.addUser("Sean", "12345");
			mc.addUser("Mohsen", "12345");
			mc.addUser("Sadjadi", "12345");
			mc.addUser("Giri", "12345");
			mc.addUser("Trevor", "12345");

			//PATIENTS
			mc.addPatient("Sergio", "Jul");
			mc.addPatient("Karla", "Aug");
			mc.addPatient("Richard", "Jan");
			mc.addPatient("Evelyn", "Dec");
			mc.addPatient("Guillermo", "Oct");
			mc.addPatient("Eduardo", "Sep");

			//DOCTOR-PATIENT
			mc.addDoctorPatient(1, "Alan");
			mc.addDoctorPatient(2, "Alan");
			mc.addDoctorPatient(3, "Alan");
			mc.addDoctorPatient(4, "Sean");
			mc.addDoctorPatient(5, "Giri");
			mc.addDoctorPatient(6, "Trevor");
	

            loginButton.Click += delegate {
                String username = usernameField.Text;
                String password = passwordField.Text;
                bool auth = mc.logIn(username, password);
                if (auth)
                {
                    //authStatus.Text += " Logged in!";
					var home = new Intent(this, typeof(Home));
					home.PutExtra("Data",username);
					StartActivity(home);
                }else
                {
                    authStatus.Text += " Failed";
                }
            };
		}
	}
}




