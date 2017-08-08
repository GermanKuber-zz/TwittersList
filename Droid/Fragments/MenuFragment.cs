
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TwittersList.Droid.Fragments
{
	public class MenuFragment : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			Button btn = this.View.FindViewById<Button>(Resource.Id.button1);
			var count = 0;
			btn.Click += (sender, e) => {
				btn.Text = count.ToString();
				++count;
			};
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			var view = inflater.Inflate(Resource.Layout.MenuFragment, container, false);


			return view;
		}
	}

	public class PrincipalFragment : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        public override void OnDestroyView()
        {
            base.OnDestroyView();
        }
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			var view = inflater.Inflate(Resource.Layout.PrincipalFragment, container, false);
			return view;
		}
	}
}
