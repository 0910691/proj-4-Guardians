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
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Menu, container, false);
            // hier functies neerzetten die via het menu worden aangeroepen

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
        }

        //var imageButton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
        //var imageButton2 = FindViewById<ImageButton>(Resource.Id.imageButton2);
        //imageButton1.Click += (e, o) =>
        //{
        //    Toast.MakeText(this, "ImageButton 1 Clicked", ToastLength.Long).Show();
        //};
        //imageButton2.Click += (e, o) =>
        //{
        //    Toast.MakeText(this, "ImageButton 2 Clicked", ToastLength.Long).Show();
        //};        
    }
}