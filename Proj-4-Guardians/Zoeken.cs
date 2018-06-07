using System;
using System.Collections;
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
    [Activity(Label = "Zoeken")]
    class Zoeken : Activity
    {
        private SearchView _sv;
        private ListView _lv;
        private ArrayAdapter _adapter;

        public static List<categorie> m_categorien;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Zoeken);
            ActionBar.Hide();
            m_categorien = MainActivity.m_categorien;

            _lv = FindViewById<ListView>(Resource.Id.lv);
            _sv = FindViewById<SearchView>(Resource.Id.sv);

            //populateList();


            _adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, test());
            _lv.Adapter = _adapter;

            _sv.QueryTextChange += _sv_QueryTextChange;
            _lv.ItemClick += _lv_ItemClick;

        }

        public List<string> test()
        {
            List<string> newlist = new List<string>();            
            // ↓voor de beschrijving van product↓
            foreach (var product in m_categorien)
            {                
                //cat = product.name.ToLower();
                newlist.Add(product.name.ToLower());
                
            }
            return newlist;

        }

        void _lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            Toast.MakeText(this, _adapter.GetItem(e.Position).ToString(), ToastLength.Short).Show();

        }

        void _sv_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            _adapter.Filter.InvokeFilter(e.NewText);


        }

        private void populateList()
        {

            m_categorien = MainActivity.m_categorien;

        }
    }
}