using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Provider;
using Android.Widget;
using SQLite;

namespace TwittersList.Droid
{
    [Activity(Label = "Sql Activity")]
    public class SqlActivity : Activity
    {

        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SqlActivityView);



          







            Spinner spinner = FindViewById<Spinner>(Resource.Id.spnCategory);

            //create a list of items for the spinner.
            String[] items = new String[] { "1", "2", "three" };
            //create an adapter to describe how the items are displayed, adapters are used in several places in android.
            //There are multiple variations of this, but this is the basic variant.
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, items);
            //set the spinners adapter to the previously created one.
            spinner.Adapter = adapter;





            Button btnAcept = FindViewById<Button>(Resource.Id.btnAdd);
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            EditText txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);
            HomeMasterScreenAdapter listAdapter = new HomeMasterScreenAdapter(this, tableItems);
            btnAcept.Click += (sender, e) =>
            {
                ListView lstList = FindViewById<ListView>(Resource.Id.lstList);
                lstList.ItemSelected += (senders, ee) =>
                {
                };
                lstList.ItemClick += (sdf, sdfe) =>
                {
                    lstList.SetItemChecked(4, true);
                    var selectedFromList = lstList.GetItemAtPosition(sdfe.Position);
                };
                lstList.FastScrollEnabled = true;
                //var items2 = new List<string> { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
                //var listAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items2);
                //listAdapter.items.AddRange(items2);
                tableItems.Add(new TableItem() { Heading = "Vegetables", SubHeading = "65 items", ImageResourceId = Resource.Drawable.Vegetables });
                tableItems.Add(new TableItem() { Heading = "Fruits", SubHeading = "17 items", ImageResourceId = Resource.Drawable.Fruits });
                tableItems.Add(new TableItem() { Heading = "Flower Buds", SubHeading = "5 items", ImageResourceId = Resource.Drawable.FlowerBuds });
                tableItems.Add(new TableItem() { Heading = "Legumes", SubHeading = "33 items", ImageResourceId = Resource.Drawable.Legumes });
                tableItems.Add(new TableItem() { Heading = "Bulbs", SubHeading = "18 items", ImageResourceId = Resource.Drawable.Bulbs });
                tableItems.Add(new TableItem() { Heading = "Tubers", SubHeading = "43 items", ImageResourceId = Resource.Drawable.Tubers });

                // Select multiple rows for activated ListViews:
                // ListView.ChoiceMode = ChoiceMode.Multiple;
                lstList.ChoiceMode = ChoiceMode.Single;

                listAdapter = new HomeMasterScreenAdapter(this, tableItems);

                lstList.Adapter = listAdapter;
            };


            btnDelete.Click += (sender, e) =>
            {

                //listAdapter.AddItem(txtDescription.Text);

            };

            GenerateDataAsync();

        }
        private async Task GenerateDataAsync()
        {
            string dbPath = System.IO.Path.Combine(
                             System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                             "ormdemo.db3");

            var db = new SQLiteAsyncConnection(dbPath);

            await db.CreateTableAsync<Stock>();
            if (await db.Table<Stock>().CountAsync() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Stock();
                newStock.Symbol = "AAPL";
                await db.InsertAsync(newStock);
                newStock = new Stock();
                newStock.Symbol = "GOOG";
                await db.InsertAsync(newStock);
                newStock = new Stock();
                newStock.Symbol = "MSFT";
                await db.InsertAsync(newStock);
            }
            System.Console.WriteLine("Reading data");
            var table = db.Table<Stock>();
            foreach (var s in await table.ToListAsync())
            {
                System.Console.WriteLine(s.Id + " " + s.Symbol);
            }

        }



    }
}
