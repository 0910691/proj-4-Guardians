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
    [Activity(Label = "About")]
    class about : Activity
    {

        private ImageButton BtnMenu;
        private Button mBtnZoek;
        private TextView _TV1;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.About);
            ActionBar.Hide();

            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMenu.Click += BtnMenu_Click;

            mBtnZoek = FindViewById<Button>(Resource.Id.BtnZoekMain);
            mBtnZoek.Click += mBtnZoek_Click;     
         }

        private void mBtnZoek_Click(object sender, EventArgs e)
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
    }
}