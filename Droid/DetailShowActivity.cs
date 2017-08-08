using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace TwittersList.Droid
{
    [Activity(Label = "DetailShowActivity")]
    public class DetailShowActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Screen1);
            // Create your application here

            Button acept = FindViewById<Button>(Resource.Id.btnAcept);
            Button cancel = FindViewById<Button>(Resource.Id.btnCancel);
            ImageView image = FindViewById<ImageView>(Resource.Id.HotDotImageView);

            acept.Click += async (sender, e) =>
            {
                cancel.Text = "Jajaja";
            };
            cancel.Click += async (sender, e) =>
            {
                var intent = new Intent(this, typeof(Screen2Activity));
				EditText msg = FindViewById<EditText>(Resource.Id.txtMsg);
                intent.PutExtra("Mors",msg.Text);
                StartActivityForResult(intent,123);

                cancel.Text = "Jajaja";
        
            };
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 123){
                var dialog = new AlertDialog.Builder(this);   
                dialog.SetTitle("Titulo numero 1");
                dialog.SetMessage("Mensaje - " + data.GetStringExtra("Primero") + " -- " + data.GetStringExtra("Segunda") );
                dialog.Show();
            }
        }
    }
}
