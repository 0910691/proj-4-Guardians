using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Proj_4_Guardians.Database;

namespace Proj_4_Guardians
{
    [Activity(Label = "Finalinfo")]
    public class Finalinfo : Activity
    {
        private TextView TxtMainInfo;
        private Button BtnInfo;
        private Button BtnMap;
        private ImageButton BtnMenu;
        private string DataToDisplay;
        private string DataToCheck;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Finalinfo);
            ActionBar.Hide();

            //↓ deze gaat gebruikt worden om te weten welke category er is geselecteerd
            if (Intent.Extras == null)
            {
                Toast.MakeText(this, "Something went wrong, going back to the main-screen", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            string Cat2 = Intent.GetStringExtra("Category2");
            string Second = Intent.GetStringExtra("Search");
            DB Data = new DB();
            if (Cat2 != null)
            {

            }
            IEnumerable<afvalsoort> Query;
            Query = Data.SelectFrom<afvalsoort>("select afvaltitel from afvalsoort where categorie =? ", Cat2);
            //Query = Data.SelectFrom<afvalproduct>("select * from afvalproduct where");

            TxtMainInfo = FindViewById<TextView>(Resource.Id.TxtBenaming);
            // execute a sql search with the data provided by Intent
            // plaats sql benaming in de TxtMainInfo
            TxtMainInfo.Text = Query.ToString();
            
            DataToDisplay = Intent.GetStringExtra("Category2").ToUpper();
            //DataToCheck = //moet verkregen worden met een sql-statement, mogelijk tegelijk met het ophalen van de info voor de titel.
            DataToCheck = "";
            if (DataToDisplay == DataToCheck) //
            {
                // dan moet nu het scherm gevuld worden met de betreffende info

            }
            // ↓ klikfuncties ↓
            BtnInfo = FindViewById<Button>(Resource.Id.BtnInfo);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMap = FindViewById<Button>(Resource.Id.BtnMap);

            BtnInfo.Click += BtnInfo_Click;
            BtnMenu.Click += BtnMenu_Click;
            BtnMap.Click += BtnMap_Click;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            // nieuw popup-scherm met daarin de info die weergegeven moet worden
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.Show(transaction, "Extra info");
        }

        private void BtnMap_Click(object sender, EventArgs e)
        {
            //var school = Android.Net.Uri.Parse("geo:0,0?q=51.901797,4.416193,z19(Locatie)");
            var geoUri = Android.Net.Uri.Parse("geo:0,0?q=51.93073923,4.507137499?z=19(prullebak)");
            //var j = new var[] {school, geoUri };
            //var geoUri = Android.Net.Uri.Parse("geo:51.93073923,4.507137499,z1");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
    }
}