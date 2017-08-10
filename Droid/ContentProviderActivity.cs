
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TwittersList.Droid
{
    [Activity(Label = "ContentProviderActivity", MainLauncher = false)]
    public class ContentProviderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var uri = ContactsContract.Contacts.ContentUri;
            string[] projection = {
                       ContactsContract.Contacts.InterfaceConsts.Id,
                       ContactsContract.Contacts.InterfaceConsts.DisplayName,
                       ContactsContract.Contacts.InterfaceConsts.PhotoId,
                    };
            // Create your application here
            var cursor = ContentResolver.Query(uri, projection, null, null, null);
        }
    }
}
