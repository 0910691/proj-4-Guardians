using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Proj_4_Guardians
{
    public class InfoOverlay : DialogFragment
    {
        private TextView TxtFinalinfo;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.ExtraInfo, container, false);
            TxtFinalinfo = view.FindViewById<TextView>(Resource.Id.TxtInfo);
            TxtFinalinfo.Text = $"Product beschrijving:  {Finalinfo.desc}\r\n \r\n Afval toelichting:  {Finalinfo.SoortToelichting}";
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
        }
    }
}