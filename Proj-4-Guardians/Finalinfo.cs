using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Proj_4_Guardians
{
    [Activity(Label = "Finalinfo")]
    public class Finalinfo : Activity
    {
        private TextView TxtMainInfo;
        private Button BtnInfo;
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

            TxtMainInfo = FindViewById<TextView>(Resource.Id.TxtBenaming);
            // execute a sql search with the data provided by Intent
            // plaats sql benaming in de TxtMainInfo
            TxtMainInfo.Text = "benaming uit database";

            
            
            DataToDisplay = Intent.GetStringExtra("Category2").ToUpper();
            //DataToCheck = //moet verkregen worden met een sql-statement, mogelijk tegelijk met het ophalen van de info voor de titel.

            if (DataToDisplay == DataToCheck) //
            {
                // dan moet nu het scherm gevuld worden met de betreffende info

            }

            // ↓ klikfuncties ↓
            BtnInfo = FindViewById<Button>(Resource.Id.BtnInfo);
            BtnInfo.Click += BtnInfo_Click;
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            // nieuw popup-scherm met daarin de info die weergegeven moet worden
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.Show(transaction, "Extra info");
        }
    }
}