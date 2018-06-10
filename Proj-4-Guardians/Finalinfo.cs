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
        private Button mBtnZoek;
        private ImageButton BtnMenu;

        public string AfvalTitel = null;
        public string LoosPunt = null;
        public string cat = null;
        public string SoortToelichting = null;
        public string desc = null;
        private string titel = null;
        private string geoL = null;
        private string geoB = null;
        private string straat = null;

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
                Toast.MakeText(this, "Er is iets fout gegaan, u wordt teruggebracht naar het hoofdscherm", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                return;
            }

            m_afvalproduct = MainActivity.m_afvalproduct;
            m_afvalsoort = MainActivity.m_afvalsoort;
            m_categorie = MainActivity.m_categorien;
            m_locatie = MainActivity.m_locaties;
            
            #region data ophalen uit json en opslaan           
            string SelectedProduct = Intent.GetStringExtra("Zoek").ToLower();
            GetProd(SelectedProduct);
            GetSoort(AfvalTitel);                  
            GetCat(cat);
            GetLoc(cat);            
            #endregion

            TxtMainInfo = FindViewById<TextView>(Resource.Id.TxtBenaming);
            TxtMainInfo.Text = cat;            

            #region KlikFuncties
            mBtnZoek = FindViewById<Button>(Resource.Id.BtnZoekFin);
            BtnInfo = FindViewById<Button>(Resource.Id.BtnInfo);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMap = FindViewById<Button>(Resource.Id.BtnMap);

            mBtnZoek.Click += MBtnZoek_Click;
            BtnInfo.Click += BtnInfo_Click;
            BtnMenu.Click += BtnMenu_Click;
            BtnMap.Click += BtnMap_Click;
            #endregion
        }

        #region getData
        public void GetProd(string SelectedProduct)
        {
            // ↓voor de bijbehorende categorie↓
            foreach (var categorie in m_afvalproduct)
            {
                var Value1 = categorie.product.ToLower();
                if (Value1 == SelectedProduct)
                {
                    AfvalTitel = categorie.afval.ToLower();
                    break;
                }
            }
        }

        public void GetSoort(string AfvalTitel)
        {
            // ↓voor extra info over het product↓
            foreach (var soort in m_afvalsoort)
            {
                var Value1 = soort.afvaltitel.ToLower();
                if (Value1 == AfvalTitel)
                {
                    LoosPunt = soort.loospunttitel;
                    cat = soort.categorie.ToLower();
                    SoortToelichting = soort.toelichting;
                    break;
                }
            }
        }

        public void GetCat(string cat)
        {
            // ↓voor de beschrijving van product↓
            foreach (var product in m_categorie)
            {
                var Value1 = product.name.ToLower();
                if (Value1 == cat)
                {
                    desc = product.description;
                    break;
                }
            }
        }

        public void GetLoc(string cat)
        {
            // ↓voor de locatie om in te leveren↓
            foreach (var loc in m_locatie)
            {
                var value1 = loc.titel.ToLower();
                if (value1.Contains(cat))
                {
                    titel = loc.titel;
                    geoL = loc.lengte;
                    geoB = loc.breedte;
                    straat = loc.straat;
                    break;
                }
            }
        }        
        #endregion

        #region Knoppen
        private void MBtnZoek_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Zoeken));
            StartActivity(intent);
        }

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
            string Geo = "";
            // controleren of alle gegevens aanwezig zijn
            if (geoL != null && geoB != null && titel != null)
            {
            Geo = $"geo:0,0?q={geoL},{geoB}?z=19({titel})";
            }
            // zo niet dan wordt Rotterdam Centraal weergegeven
            else
            {
                Geo = $"geo:0,0?q=51.9244818,4.4694783?z=15(Rotterdam Centraal)";
            }
            var geoUri = Android.Net.Uri.Parse(Geo);
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
        #endregion
    }
}