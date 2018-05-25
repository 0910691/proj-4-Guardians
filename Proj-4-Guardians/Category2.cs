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

namespace Proj_4_Guardians
{
    [Activity(Label = "Category2")]
    public class Category2 : Activity
    {
        ImageButton BtnMenu;
        TextView testText;
        string DataToDisplay;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Category2);
            ActionBar.Hide();
            // Create your application here


            //↓ deze gaat gebruikt worden om te weten welke category er is geselecteerd
            if (Intent.Extras == null)
            {
                Intent intent = new Intent(this, typeof(Category));
                StartActivity(intent);
            }

            DataToDisplay = Intent.GetStringExtra("Category").ToUpper();
            if (DataToDisplay == "GLAS")
            {
                // dan moet nu het scherm gevuld worden met de betreffende info
                

            }
            // echter hebben we nu alleen text, dus gewoon naar het scherm schrijven
            testText = FindViewById<TextView>(Resource.Id.txtv3);
            testText.Text = DataToDisplay;

            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMenu.Click += BtnMenu_Click;
        }

        private void BtnMenu_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }
    }
}