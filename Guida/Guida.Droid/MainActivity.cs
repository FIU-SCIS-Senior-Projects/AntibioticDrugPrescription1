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
	//Main activity. When application is launched, this is the first activity to be displayed
	[Activity (Label = "Guida.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//Layout Variables
		Button loginButton;
		EditText usernameField, passwordField;
		TextView authStatus;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Set content view to Main Layout
			SetContentView(Resource.Layout.Main);

			//Initialize layout variables
			loginButton = FindViewById<Button> (Resource.Id.loginButton);
            usernameField = FindViewById<EditText>(Resource.Id.usernameField);
            passwordField = FindViewById<EditText>(Resource.Id.passwordField);
            authStatus = FindViewById<TextView>(Resource.Id.authStatusText);

			//Clear Text when usernameField is clicked
			usernameField.Click += delegate {
				usernameField.Text = "";
			};
			//Clear Text when passwordField is clicked
			passwordField.Click += delegate
			{
				passwordField.Text = "";
			};

			//Create Database. (The creation of the database should be moved to another file)
			//-------------------------------------------------------------------------------

			//DOCTORS
			appSettings.GetController().addUser("Alan", "12345");
			appSettings.GetController().addUser("Sean", "12345");
			appSettings.GetController().addUser("Mohsen", "12345");
			appSettings.GetController().addUser("Sadjadi", "12345");
			appSettings.GetController().addUser("Giri", "12345");
			appSettings.GetController().addUser("Trevor", "12345");

			//PATIENTS
			appSettings.GetController().addPatient("Sergio", "Jul");
			appSettings.GetController().addPatient("Karla", "Aug");
			appSettings.GetController().addPatient("Richard", "Jan");
			appSettings.GetController().addPatient("Evelyn", "Dec");
			appSettings.GetController().addPatient("Guillermo", "Oct");
			appSettings.GetController().addPatient("Eduardo", "Sep");

			//DOCTOR-PATIENT
			appSettings.GetController().addDoctorPatient(1, "Alan");
			appSettings.GetController().addDoctorPatient(2, "Alan");
			appSettings.GetController().addDoctorPatient(3, "Alan");
			appSettings.GetController().addDoctorPatient(4, "Sean");
			appSettings.GetController().addDoctorPatient(5, "Giri");
			appSettings.GetController().addDoctorPatient(6, "Trevor");

			//VISIT
			//appSettings.controller.addVisits(1, "01-05-16", "Sergio", "Thyru");
			//appSettings.controller.addVisits(2, "02-05-16", "Karla", "Alan");
			//appSettings.controller.addVisits(3, "03-05-16", "Richard", "Sean");
			//appSettings.controller.addVisits(4, "04-05-16", "Everlyn", "Giri");
			//appSettings.controller.addVisits(1, "02-05-16", "Sergio", "Trevor");

			//When Log in button is clicked, user may log in if username and password are stored in the database
			loginButton.Click += delegate {      

				//Return true if username and password entered are stored in the database
				bool auth = appSettings.GetController().logIn(usernameField.Text, passwordField.Text);

				//If username and password is valid, start next activity
                if (auth) StartActivity(typeof(Home));
				//Else, let know the user log in failed
                else authStatus.Text += " Log in Failed! ";
                
            };

		}
	}
}



