using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

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
		int tries;

		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate (bundle);

			//Set content view to Main Layout
			SetContentView(Resource.Layout.Main);

            //Connect to the database - These lines need to be called in iOS initialization as well
            Database.connect();
            Data.insertData();

            //Initialize layout variables
            //---------------------------
            loginButton = FindViewById<Button> (Resource.Id.loginButton);		//Log in button
            usernameField = FindViewById<EditText>(Resource.Id.usernameField);	//Username text field
            passwordField = FindViewById<EditText>(Resource.Id.passwordField);	//Password text field
            authStatus = FindViewById<TextView>(Resource.Id.authStatusText);    //Authentication text view 
			tries = 0;
			loginButton.SetBackgroundColor(Android.Graphics.Color.DarkGray);
			//Clear Text when usernameField is clicked
			usernameField.Click += delegate {
				usernameField.Text = "";
			};
			//Clear Text when passwordField is clicked
			passwordField.Click += delegate
			{
				passwordField.Text = "";
			};

			//When Log in button is clicked, user may log in if username and password are stored in the database
			loginButton.Click += delegate {      

				//Return true if username and password entered are stored in the database
				bool auth = Controller.logIn(usernameField.Text, passwordField.Text);
				//If username and password is valid, start next activity
				if (auth)
				{
					StartActivity(typeof(PatientList));
					Finish();
				}
				//Else, let know the user log in failed
                else authStatus.Text = " Log in Failed! " + ++tries + " Attempt/s";
                
            };

		}
	}
}



