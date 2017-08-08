using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Provider;
using Android.Views;
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



            var uri = ContactsContract.Contacts.ContentUri;
            string[] projection = {
                       ContactsContract.Contacts.InterfaceConsts.Id,
                       ContactsContract.Contacts.InterfaceConsts.DisplayName,
                       ContactsContract.Contacts.InterfaceConsts.PhotoId,
                    };







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
    [Table("Items")]
    public class Stock
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
    }
    public class HomeMasterScreenAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public HomeMasterScreenAdapter(Activity context, List<TableItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }

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

    public class TodoScreenAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public TodoScreenAdapter(Activity context, List<TableItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            // SIMPLE LIST ITEM 1
            View view = convertView;
            //if (view == null)
            //	view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            //	view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            // SIMPLE LIST ITEM 2
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;
            //view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.SubHeading;

            // SIMPLE SELECTABLE LIST ITEM
            // View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleSelectableListItem, null);
            // view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            // SIMPLE LIST ITEM ACTIVATED 1
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemActivated1, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            // SIMPLE LIST ITEM ACTIVATED 2
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemActivated2, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;
            //view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.SubHeading;

            // SIMPLE LIST ITEM CHECKED
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemChecked, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            // SIMPLE LIST ITEM MULTIPLE CHOICE
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemMultipleChoice, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            // SIMPLE LIST ITEM SINGLE CHOICE
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemSingleChoice, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            // TWO LINE LIST ITEM
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.TwoLineListItem, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;
            //view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.SubHeading;

            // ACTIVITY LIST ITEM
            view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemChecked, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;
            ImageView img = view.FindViewById<ImageView>(Android.Resource.Id.Icon);


            // TEST LIST ITEM
            //View view = context.LayoutInflater.Inflate(Android.Resource.Layout.TestListItem, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Heading;

            return view;
        }
    }
    public class TableItem
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public int ImageResourceId { get; set; }
    }
}
