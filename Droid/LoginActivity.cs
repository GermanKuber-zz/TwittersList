using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Auth0.OidcClient;
using IdentityModel.OidcClient;
using LoginScreen;
using Xamarin.Auth;

namespace TwittersList.Droid
{
[Activity(Label = "AndroidSample", MainLauncher = true, Icon = "@drawable/icon",
	LaunchMode = LaunchMode.SingleTask)]
	[IntentFilter(
	new[] { Intent.ActionView },
	Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
	DataScheme = "twitterslist.droid",
	DataHost = "germakuber.auth0.com",
	DataPathPrefix = "/android/twitterslist.droid/callback")]

    public class LoginActivity : Activity
    {
        AuthorizeState authorizeState;
        Auth0Client client;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //LoginScreenControl<CredentialsProvider, LoginScreenMessages>.Activate(this);
            //var auth = new OAuth2Authenticator(
            //                clientId: "291353537939776",
            //                scope: "",
            //                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
            //                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));
            //auth.Completed += (sender, eventArgs) =>
            //{

            //};

            //var client = new Auth0Client(new Auth0ClientOptions


            client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "germakuber.auth0.com",
                ClientId = "cFLRdKP28o2DHVB8Ea0iRfg6A74BwvOv",
                Activity = this,
                ClientSecret="m31h6Jr8SZ6AyIBsck6zUS6Md5Fj6zIuA69KNHcYXmkeXjRX-Ps8JykoNTt-ZdHC"
            });
            // StartActivity(auth.GetUI(this));
             authorizeState = await client.PrepareLoginAsync();

			var uri = Android.Net.Uri.Parse(authorizeState.StartUrl);
			var intent = new Intent(Intent.ActionView, uri);
			intent.AddFlags(ActivityFlags.NoHistory);
			StartActivity(intent);
        }
		protected override async void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);
            try
            {
				var loginResult = await client.ProcessResponseAsync(intent.DataString, authorizeState);
            }
            catch (Exception ex)
            {

            }
          
		}
    }
}
