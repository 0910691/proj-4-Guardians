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
    class MenuOverlay:DialogFragment
    {
        private Button mBtnMenu;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Menu, container, false);
            // hier functies neerzetten die via het menu worden aangeroepen
            mBtnMenu = view.FindViewById<Button>(Resource.Id.btnMenu);
            mBtnMenu.Click += MBtnMenu_Click;

            return view;
        }

        private void MBtnMenu_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(MainActivity));
            StartActivity(intent);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
        }
    }
}