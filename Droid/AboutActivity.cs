
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
using TwittersList.Droid.Fragments;

namespace TwittersList.Droid
{
    [Activity(Label = "")]
    public class Screen2Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Screen2);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText("Home");
            tab.TabSelected += (sender, args) =>
            {
				Fragment frag1 = new PrincipalFragment();
				var t = this.FragmentManager.BeginTransaction();

				t.Replace(Resource.Id.frmFragment1, frag1);
				t.Commit();

                Fragment frag = new MenuFragment();
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.frmFragment, frag).Commit();
            };

            ActionBar.AddTab(tab);
            ActionBar.Tab tab2 = ActionBar.NewTab();
            tab2.SetText("Configuraciones");
            tab2.TabSelected += (sender, args) =>
            {
				Fragment frag1 = new MenuFragment();
				this.FragmentManager.BeginTransaction().Replace(Resource.Id.frmFragment1, frag1).Commit();
                Fragment frag = new PrincipalFragment();
                var t = this.FragmentManager.BeginTransaction();
         
                t.Replace(Resource.Id.frmFragment, frag);
                t.Commit();
            };

            ActionBar.AddTab(tab2);




            //AddTab("Favorites",new MenuFragment());
        }
        private void AddTab(string tabText, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);


            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var myf = new MenuFragment();


                Fragment frag = new MenuFragment();
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.frmFragment, frag);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {

            };

            this.ActionBar.AddTab(tab);
        }



        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            var intent = new Intent();
            intent.PutExtra("Mors2", data.GetStringExtra("Mors3"));
            intent.PutExtra("Segunda", "Jajajaja");
            SetResult(Result.Ok, intent);

            this.Finish();
        }
    }

    [Activity(Label = "Screen3Activity")]
    public class Screen3Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Screen3);



            var i = Intent.GetStringExtra("Mors2");

            Button btn = FindViewById<Button>(Resource.Id.btnLlamar);

            btn.Click += (sender, e) =>
            {
                EditText msg = FindViewById<EditText>(Resource.Id.txtFinalMsg);
                var intent = new Intent();
                intent.PutExtra("Mors3", msg.Text);
                intent.PutExtra("Segunda", "Jajajaja");
                SetResult(Result.Ok, intent);

                this.Finish();
            };
        }
    }
}
