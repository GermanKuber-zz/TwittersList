using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace TwittersList.Droid
{
    public class HomeScreenAdapter : BaseAdapter<string>
    {



        public List<String> items = new List<string>();

        public void AddItem(string item)
        {
            this.items.Add(item);
            this.NotifyDataSetChanged();
        }
        Activity context;
        public HomeScreenAdapter(Activity context, List<String> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {

            return position;
        }
        public override string this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position];
            return view;
        }

    }
}
