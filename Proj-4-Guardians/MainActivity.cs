#region usings
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
 * **************afvalsoort klopt niet helemaal, kloppend maken*******************
 * product.json afmaken met behulp van macro-keys
 * FinalInfo moet gegevens krijgen na het zoeken en vergelijken met de opgehaalde lijsten
 * zoekfunctie maken
 * Zoekbalken vervangen door een knop naar Zoeken.cs
 * in zoeken menu toevoegen
 * barcode verwijderen
 * kleuren aanpassen
 * voorbeelden om te selecteren
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
        public static List<afvalproduct> m_afvalproduct;        // class niet goed?

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();
            LoadCategorieData(Assets.Open("categorie.json"));
            m_categorien = m_databasehelper.Connection.Table<categorie>().ToList();
            LoadLocatieData(Assets.Open("locaties.json"));
            m_locaties = m_databasehelper.Connection.Table<locatie>().ToList();
            LoadAfvalsoortData(Assets.Open("soort.json"));
            m_afvalsoort = m_databasehelper.Connection.Table<afvalsoort>().ToList();
            LoadAfvalproductData(Assets.Open("prod.json"));
            m_afvalproduct = m_databasehelper.Connection.Table<afvalproduct>().ToList();
            

            mBtnRecycle = FindViewById<ImageButton>(Resource.Id.ImbRecycle);
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            Search = FindViewById<Button>(Resource.Id.BtnZoekMain);
                        
            mBtnRecycle.Click += MBtnRecycle_Click;
            BtnMenu.Click += BtnMenu_Click;
            Search.Click += Search_Click;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Zoeken));
            StartActivity(intent);
        }

        #region data laden uit json
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

