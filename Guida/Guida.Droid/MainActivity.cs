using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

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

            Authentication mc = new Authentication();

            loginButton.Click += delegate {
                String username = usernameField.Text;
                String password = passwordField.Text;
                bool auth = mc.authenticate(username, password);
                if (auth)
                {
                    //authStatus.Text += " Logged in!";
					SetContentView (Resource.Layout.Home);
				
                }else
                {
                    authStatus.Text += " Failed";
                }
            };
		}
	}
}


