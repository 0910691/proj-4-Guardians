using System;
using System.IO;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Proj_4_Guardians
{
    [Activity(Label = "Recycler")]
    public class Category : Activity
    {
        private ImageButton mBtnDrank;
        private ImageButton mBtnPapier;
        private ImageButton mBtnElektro;
        private ImageButton mBtnAnders;
        private ImageButton mBtnMenu;
        private Button mBtnZoek;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Category);
            ActionBar.Hide();
            List<afvalsoort> m_afvalsoort = MainActivity.m_afvalsoort;

            mBtnZoek = FindViewById<Button>(Resource.Id.BtnZoekCat);

            // ↓ klikfuncties ↓
            mBtnDrank = FindViewById<ImageButton>(Resource.Id.ImbDrank);
            mBtnPapier = FindViewById<ImageButton>(Resource.Id.ImbPapier);
            mBtnElektro = FindViewById<ImageButton>(Resource.Id.ImbElektro);
            mBtnAnders = FindViewById<ImageButton>(Resource.Id.ImbAnders);
            mBtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);

            mBtnDrank.Click += MBtnDrank_Click;
            mBtnPapier.Click += MBtnPapier_Click;
            mBtnElektro.Click += MBtnElektro_Click;
            mBtnAnders.Click += MBtnAnders_Click;
            mBtnMenu.Click += BtnMenu_Click;
            mBtnZoek.Click += MBtnZoek_Click;
        }

        private void MBtnZoek_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Zoeken));
            StartActivity(intent);
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

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }
    }
}