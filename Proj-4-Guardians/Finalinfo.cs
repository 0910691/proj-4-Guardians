﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Linq;

namespace Proj_4_Guardians
{
    [Activity(Label = "Finalinfo")]
    public class Finalinfo : Activity
    {
        private TextView TxtMainInfo;
        private TextView txtMap;
        private ImageButton BtnMap;
        private Button mBtnZoek;
        private ImageButton BtnMenu;
        private ImageButton ImbInfo;

        public string AfvalTitel = null;
        public string LoosPunt = null;
        public string cat = null;
        public static string SoortToelichting = null;
        public static string desc = null;
        private string titel = null;
        private string geoL = null;
        private string geoB = null;
        private string straat = null;

        private bool HasData = false;

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

            txtMap = FindViewById<TextView>(Resource.Id.TxtMap);
            TxtMainInfo = FindViewById<TextView>(Resource.Id.TxtBenaming);
            TxtMainInfo.Gravity = Android.Views.GravityFlags.CenterHorizontal;
            TxtMainInfo.Text = $"Categorie: \r\n{cat}";

            #region KlikFuncties
            ImbInfo = FindViewById<ImageButton>(Resource.Id.ImbInfo);
            mBtnZoek = FindViewById<Button>(Resource.Id.BtnZoekFin);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMap = FindViewById<ImageButton>(Resource.Id.BtnMap);
            if (HasData)
            {
                BtnMap.Visibility = Android.Views.ViewStates.Visible;
                txtMap.Visibility = Android.Views.ViewStates.Visible;
            }
            ImbInfo.Click += BtnInfo_Click;
            mBtnZoek.Click += MBtnZoek_Click;
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
            // controleren wat de dichtstbijzijnde locatie is
            double CurrentL = 51.917440;
            double CurrentB = 4.484105;
            List<locatie> temp = new List<locatie>();
            // ↓voor de locatie om in te leveren↓
            foreach (var loc in m_locatie)
            {
                var value1 = loc.titel.ToLower();
                if (value1.Contains(cat))
                {
                    temp.Add(loc);
                }
            }
            if (temp.Count > 0)
            {
                HasData = true;
                // vergelijkt nu lengtegraad x met breedtegraad y
                // moet lengtegraad x met lengtegraad y vergelijken
                // en moet breedtegraad x met breedtegraad y vergelijken
                var closest = temp.Aggregate((x, y) => Math.Abs(Convert.ToDouble(x.lengte) - CurrentL) < Math.Abs(Convert.ToDouble(y.breedte) - CurrentB) ? x : y);

                //var closestLen = temp.Aggregate((x, y) => Math.Abs(Convert.ToDouble(x.lengte) - CurrentL) < Math.Abs(Convert.ToDouble(y.lengte) - CurrentL) ? x : y);
                //var closestBre = temp.Aggregate((x, y) => Math.Abs(Convert.ToDouble(x.breedte) - CurrentB) < Math.Abs(Convert.ToDouble(y.breedte) - CurrentB) ? x : y);

                titel = closest.titel;
                geoL = closest.lengte;
                geoB = closest.breedte;
                straat = closest.straat;
                return;
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
            if ((geoL != null || geoL != "0") && (geoB != null || geoB != "0") && titel != null)
            {
            Geo = $"geo:0,0?q={geoL},{geoB}?z=18({titel})";
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