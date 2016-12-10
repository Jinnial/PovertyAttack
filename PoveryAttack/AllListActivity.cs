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
using System.IO;
using SQLite;
using Newtonsoft.Json;

namespace PoveryAttack
{
    [Activity(Label = "AllListActivity")]
    public class AllListActivity : Activity
    {
        //path string for the database file
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "providers.db3");
        List<Data.ProviderOrg> items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AllList);
            //setup the db connection
            var db = new SQLiteConnection(dbPath);
            deleteAll();

            //setup a table for an organization
            db.CreateTable<Data.ProviderOrg>();

            //load the json data to populate a list of objects
            Android.Content.Res.AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("services.json")))
            {
                string json = sr.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Data.ProviderOrg>>(json);
            }

            //store the objects into the table
            foreach (var item in items)
            {
                db.Insert(item);
            }

            //get our listview 
            var lv = FindViewById<ListView>(Resource.Id.providerListView);

            //assign the adapter
            lv.Adapter = new HomeScreenAdapter(this, items);

        }

        //a method that deletes all of the records in the table
        //for use in testing the app so we don't fill the DB with
        //records every time we run
        public void deleteAll()
        {
            var db = new SQLiteConnection(dbPath);
            db.Execute("delete from ProviderOrg");
        }
    }
}