using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Views;
using Android.Widget;

namespace TwittersList.Droid.ContactsProvider
{
    public class ContactsAdapter : BaseAdapter<TableItem>
    {
        public ContactsAdapter()
        {

        }
        Activity activity;
        public ContactsAdapter(Activity activity)
        {
            this.activity = activity;
            FillContacts();
        }
        public override int Count
        {
            get { return contactList.Count; }
        }

        public List<Contact> contactList { get; private set; }

        public override Java.Lang.Object GetItem(int position)
        {
            return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        }
        public override long GetItemId(int position)
        {
            return contactList[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ContactListItem, parent, false);
            var contactName = view.FindViewById<TextView>(Resource.Id.ContactName);
            var contactImage = view.FindViewById<ImageView>(Resource.Id.ContactImage);
            contactName.Text = contactList[position].DisplayName;
            if (contactList[position].PhotoId == null)
            {
                contactImage = view.FindViewById<ImageView>(Resource.Id.ContactImage);
                contactImage.SetImageResource(Resource.Drawable.ContactImage);
            }
            else
            {
                var contactUri = ContentUris.WithAppendedId(ContactsContract.Contacts.ContentUri, contactList[position].Id);
                var contactPhotoUri = Android.Net.Uri.WithAppendedPath(contactUri, Contacts.Photos.ContentDirectory);
                contactImage.SetImageURI(contactPhotoUri);
            }
            return view;
        }

    }
    public class Contact
    {
        public int Id
        {
            get;
            set;
        }
        public int PhotoId
        {
            get;
            set;
        }
        public string DisplayName
        {
            get;
            set;
        }
    }
}
