using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Runtime;
using Android.Views;

namespace Proj_4_Guardians
{
    [Activity(Label = "Recycler")]
    public class Category : Activity
    {
        ImageButton mBtnDrank;
        ImageButton mBtnPapier;
        ImageButton mBtnElektro;
        ImageButton mBtnAnders;
        ImageButton BtnMenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Category);
            ActionBar.Hide();

            SearchView search = FindViewById<SearchView>(Resource.Id.ScvZoekMain);
            search.SetQueryHint("Papier, Plastic, Glas");


            mBtnDrank = FindViewById<ImageButton>(Resource.Id.ImbDrank);
            mBtnDrank.Click += MBtnDrank_Click;

            mBtnPapier = FindViewById<ImageButton>(Resource.Id.ImbPapier);
            mBtnPapier.Click += MBtnPapier_Click;

            mBtnElektro = FindViewById<ImageButton>(Resource.Id.ImbElektro);
            mBtnElektro.Click += MBtnElektro_Click;

            mBtnAnders = FindViewById<ImageButton>(Resource.Id.ImbAnders);
            mBtnAnders.Click += MBtnAnders_Click;

            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMenu.Click += BtnMenu_Click;
        }

        private void MBtnAnders_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category2));
            intent.PutExtra("Category", "anders");
            StartActivity(intent);
        }

        private void MBtnElektro_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category2));
            intent.PutExtra("Category", "elektro");
            StartActivity(intent);
        }

        private void MBtnPapier_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category2));
            intent.PutExtra("Category", "papier");
            StartActivity(intent);
        }
    
        private void MBtnDrank_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category2));
            intent.PutExtra("Category", "plastic");
            StartActivity(intent);
        }

        private void BtnMenu_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }
    }
}