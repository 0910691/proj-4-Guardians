#region usings
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

using Proj_4_Guardians.Database;
using System.Linq;
#endregion

namespace Proj_4_Guardians
{
    [Activity(Label = "Recycler", MainLauncher = true, Icon = "@drawable/Recycle")]
    public class MainActivity : Activity
    {
        private ImageButton mBtnRecycle;
        private ImageButton BtnMenu;
        private SearchView Search;
        private EditText mBarcode;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();

            #region DB conn
            DB dB = new DB(); // create db conn

            #endregion

            mBtnRecycle = FindViewById<ImageButton>(Resource.Id.ImbRecycle);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            Search = FindViewById<SearchView>(Resource.Id.ScvZoekMain);
            mBarcode = FindViewById<EditText>(Resource.Id.EdtBarcode);

            // controleren of er 13 getallen in de editText staan, zo ja dan wat doen
            mBarcode.TextChanged += (s, e) =>
            {
                string UserCode = mBarcode.ToString();
                // check if barcode is long enough
                if (UserCode.Length < 13)
                {
                    Toast.MakeText(this, "De gegeven barcode is niet lang genoeg!", ToastLength.Short).Show();
                }
                else if ( UserCode.Length == 13)
                {
                    // Compare user barcode to database barcode's
                }
                else
                {
                    Toast.MakeText(this, "De gegeven barcode is te lang!", ToastLength.Short).Show();
                }
            };

            Search.Close += (s, e) =>
            {
                
            };
            mBtnRecycle.Click += MBtnRecycle_Click;
            Search.SetQueryHint("Papier, Plastic, Glas");
            BtnMenu.Click += BtnMenu_Click;           
        }
        #region Knop functies
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }

        private void MBtnRecycle_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category));
            StartActivity(intent);
        }
        #endregion
    }
}

