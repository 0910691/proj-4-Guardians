using System;
using System.IO;
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
    class MenuOverlay:DialogFragment
    {
        private Button mBtnMenu;
        private Button mBtnZoek;
        private Button mBtnAbout;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Menu, container, false);
            // hier functies neerzetten die via het menu worden aangeroepen
            mBtnMenu = view.FindViewById<Button>(Resource.Id.btnMenu);
            mBtnMenu.Click += MBtnMenu_Click;

            mBtnZoek = view.FindViewById<Button>(Resource.Id.button2);
            mBtnZoek.Text = "Zoeken";
            mBtnZoek.Click += mBtnZoek_Click;

            mBtnAbout = view.FindViewById<Button>(Resource.Id.button3);
            mBtnAbout.Text = "About";
            mBtnAbout.Click += mBtnAbout_Click;
            return view;

           
        }

        private void mBtnZoek_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(Zoeken));
            StartActivity(intent);
        }

        private void MBtnMenu_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(MainActivity));
            StartActivity(intent);
        }

        private void mBtnAbout_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(about));
            StartActivity(intent);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
        }
    }
}