﻿#region usings
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using System.IO;
using System.Collections.Generic;

using System.Linq;
using Newtonsoft.Json;
#endregion

/* TODO
 * kleuren aanpassen
 * 
 * knop naar map standaard onzichtbaar
 * knop desc moet dan uitleg geven
 * 
 * data waar een locatie van is wel de mapKnop weergeven
*/
namespace Proj_4_Guardians
{
    [Activity(Label = "Recycler", MainLauncher = true, Icon = "@drawable/Recycle")]
    public class MainActivity : Activity
    {
        private ImageButton mBtnRecycle;
        private ImageButton BtnMenu;
        private Button Search;

        // voor de db
        private DatabaseHelper m_databasehelper = new DatabaseHelper();
        public static List<categorie> m_categorien;
        public static List<locatie> m_locaties;
        public static List<afvalsoort> m_afvalsoort;
        public static List<afvalproduct> m_afvalproduct;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();
            GetData();

            mBtnRecycle = FindViewById<ImageButton>(Resource.Id.ImbRecycle);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            Search = FindViewById<Button>(Resource.Id.BtnZoekMain);
                        
            mBtnRecycle.Click += ButtonCLick<Zoeken>;
            BtnMenu.Click += BtnMenu_Click;
            Search.Click += ButtonCLick<Zoeken>;
        }               

        #region data laden uit json
        public void GetData()
        {
            // gedaan om te voorkomen dat elke keer dat het hoofdscherm geladen wordt de data opnieuw opgehaald wordt
            if (m_categorien == null)
            {
                LoadCategorieData(Assets.Open("categorie.json"));
                m_categorien = m_databasehelper.Connection.Table<categorie>().ToList();
            }
            if (m_locaties == null)
            {
                LoadLocatieData(Assets.Open("locaties.json"));
                m_locaties = m_databasehelper.Connection.Table<locatie>().ToList();
            }
            if (m_afvalsoort == null)
            {
                LoadAfvalsoortData(Assets.Open("soort.json"));
                m_afvalsoort = m_databasehelper.Connection.Table<afvalsoort>().ToList();
            }
            if (m_afvalproduct == null)
            {
                LoadAfvalproductData(Assets.Open("prod.json"));
                m_afvalproduct = m_databasehelper.Connection.Table<afvalproduct>().ToList();
            }
        }

        public void LoadCategorieData(Stream db_path)
        {
            StreamReader reader = new StreamReader(db_path);
            string resp = reader.ReadToEnd();
            List<categorie> temp_values;
            temp_values = JsonConvert.DeserializeObject<List<categorie>>(resp);
            m_databasehelper.Connection.CreateTable<categorie>();
            m_databasehelper.Connection.DeleteAll<categorie>();
            foreach (var categorie in temp_values)
            {
                m_databasehelper.Connection.InsertOrReplace(new categorie
                {
                    name = categorie.name,
                    description = categorie.description                    
                });
            }
        }

        public void LoadLocatieData(Stream db_path)
        {
            StreamReader reader = new StreamReader(db_path);
            string resp = reader.ReadToEnd();
            List<locatie> temp_values;
            temp_values = JsonConvert.DeserializeObject<List<locatie>>(resp);
            m_databasehelper.Connection.CreateTable<locatie>();
            m_databasehelper.Connection.DeleteAll<locatie>();
            foreach (var locatie in temp_values)
            {
                m_databasehelper.Connection.InsertOrReplace(new locatie
                {
                    titel = locatie.titel,
                    straat = locatie.straat,
                    lengte = locatie.lengte,
                    breedte = locatie.breedte
                });
            }
        }

        public void LoadAfvalsoortData(Stream db_path)
        {
            StreamReader reader = new StreamReader(db_path);
            string resp = reader.ReadToEnd();
            List<afvalsoort> temp_values;
            temp_values = JsonConvert.DeserializeObject<List<afvalsoort>>(resp);
            m_databasehelper.Connection.CreateTable<afvalsoort>();
            m_databasehelper.Connection.DeleteAll<afvalsoort>();
            foreach (var soort in temp_values)
            {
                m_databasehelper.Connection.InsertOrReplace(new afvalsoort
                {
                    afvaltitel = soort.afvaltitel,                    
                    loospunttitel = soort.loospunttitel,
                    categorie = soort.categorie,
                    toelichting = soort.toelichting
                });
            }
        }

        public void LoadAfvalproductData(Stream db_path)
        {
            StreamReader reader = new StreamReader(db_path);
            string resp = reader.ReadToEnd();
            List<afvalproduct> temp_values;
            temp_values = JsonConvert.DeserializeObject<List<afvalproduct>>(resp);
            m_databasehelper.Connection.CreateTable<afvalproduct>();
            m_databasehelper.Connection.DeleteAll<afvalproduct>();
            foreach (var product in temp_values)
            {
                m_databasehelper.Connection.InsertOrReplace(new afvalproduct
                {
                    product = product.product,
                    afval = product.afval
                });
            }
        }
        #endregion

        #region Knop functies
        private void ButtonCLick<T>(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(T));
            StartActivity(intent);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }
        #endregion
    }
}

