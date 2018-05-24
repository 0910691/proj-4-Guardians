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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Category);
            ActionBar.Hide();

            SearchView search = FindViewById<SearchView>(Resource.Id.ScvZoekCat1);
            search.SetQueryHint("Papier, Plastic, Glas");


            mBtnDrank = FindViewById<ImageButton>(Resource.Id.ImbDrank);
            mBtnDrank.Click += MBtnDrank_Click;

            mBtnPapier = FindViewById<ImageButton>(Resource.Id.ImbPapier);
            mBtnPapier.Click += MBtnPapier_Click;

            mBtnElektro = FindViewById<ImageButton>(Resource.Id.ImbElektro);
            mBtnElektro.Click += MBtnElektro_Click;

            mBtnAnders = FindViewById<ImageButton>(Resource.Id.ImbAnders);
            mBtnAnders.Click += MBtnAnders_Click;            
        }

        private void MBtnAnders_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CategoryAnders));
            this.StartActivity(intent);
        }

        private void MBtnElektro_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CategoryElektro));
            this.StartActivity(intent);
        }

        private void MBtnPapier_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CategoryPapier));
            this.StartActivity(intent);
        }
    
        private void MBtnDrank_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CategoryDrank));
            this.StartActivity(intent);
        }
    }
}