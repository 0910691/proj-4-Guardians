using System;
using System.Collections.Generic;
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
        private Button BtnMap;
        private ImageButton BtnMenu;
        private string DataToDisplay;
        private string DataToCheck;

        public List<afvalproduct> m_afvalproduct;
        public List<afvalsoort> m_afvalsoort;
        public List<categorie> m_categorie;
        public List<locatie> m_locatie;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Finalinfo);
            ActionBar.Hide();

            if (Intent.Extras == null)
            {
                Toast.MakeText(this, "Something went wrong, going back to the main-screen", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            m_afvalproduct = MainActivity.m_afvalproduct;
            m_afvalsoort = MainActivity.m_afvalsoort;
            m_categorie = MainActivity.m_categorien;
            m_locatie = MainActivity.m_locaties;

            #region later naar kijken
            //string Cat2 = Intent.GetStringExtra("Category2");
            //string Second = Intent.GetStringExtra("Search");
            //if (Cat2 != null)
            //{
            //}
            #endregion

            #region data ophalen uit json en opslaan
            string geselecteerd = Intent.GetStringExtra("Zoek").ToLower();
            string cat = "";
            string desc = "";
            // ↓voor de beschrijving van product↓
            foreach (var product in m_categorie)
            {
                var Value1 = product.name.ToLower();
                if (Value1.Contains(geselecteerd))
                {
                    cat = product.name.ToLower();
                    desc = product.description;
                    break;
                }                
            }
            // ↓voor de locatie om in te leveren↓
            string geoL= "";
            string geoB = "";
            string straat = "";
            // titel van loc moet overeenkomen met categorie
            foreach (var loc in m_locatie)
            {
                var value1 = loc.titel.ToLower();
                if (value1.Contains(cat))
                {
                    geoL = loc.lengte;
                    geoB = loc.breedte;
                    straat = loc.straat;
                    break;
                }
            }

            #endregion


            TxtMainInfo = FindViewById<TextView>(Resource.Id.TxtBenaming);
            TxtMainInfo.Text = cat;
            
            DataToDisplay = Intent.GetStringExtra("Category2").ToUpper();
            //DataToCheck = //moet verkregen worden met een sql-statement, mogelijk tegelijk met het ophalen van de info voor de titel.
            DataToCheck = "";
            if (DataToDisplay == DataToCheck) //
            {
                // dan moet nu het scherm gevuld worden met de betreffende info
            }

            #region KlikFuncties
            BtnInfo = FindViewById<Button>(Resource.Id.BtnInfo);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMap = FindViewById<Button>(Resource.Id.BtnMap);

            BtnInfo.Click += BtnInfo_Click;
            BtnMenu.Click += BtnMenu_Click;
            BtnMap.Click += BtnMap_Click;
            #endregion
        }
        #region Knoppen
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.Show(transaction, "Extra info");
        }

        private void BtnMap_Click(object sender, EventArgs e)
        {
            //var school = Android.Net.Uri.Parse("geo:0,0?q=51.901797,4.416193,z19(Locatie)");
            var geoUri = Android.Net.Uri.Parse("geo:0,0?q=51.93073923,4.507137499?z=19(Locatie)");
            //var geoUri = Android.Net.Uri.Parse("geo:51.55028,4.29025?z=19(Hogeschool Rotterdam)");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
        #endregion
    }
}