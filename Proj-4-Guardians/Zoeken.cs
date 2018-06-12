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
        private ImageButton _Menu;

        public static List<afvalproduct> m_afvalproduct;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Zoeken);
            ActionBar.Hide();
            m_afvalproduct = MainActivity.m_afvalproduct;

            _Menu = FindViewById<ImageButton>(Resource.Id.Menu);
            _lv = FindViewById<ListView>(Resource.Id.lv);
            _sv = FindViewById<SearchView>(Resource.Id.sv);
            _sv.SetQueryHint("Glas, Plastic, Papier, Elektronica");

            _adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, DataToList());
            _lv.Adapter = _adapter;

            _sv.QueryTextChange += _sv_QueryTextChange;
            _lv.ItemClick += _lv_ItemClick;
            _Menu.Click += _Menu_Click;
        }

        public List<string> DataToList()
        {
            List<string> newlist = new List<string>();
            foreach (var product in m_afvalproduct)
            {
                newlist.Add(product.product.ToLower());
            }
            newlist.Sort();
            return newlist;
        }

        private void _Menu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }

        void _lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //toast.MakeText(this, _adapter.GetItem(e.Position).ToString(), ToastLength.Short).Show();
            Intent intent = new Intent(this, typeof(Finalinfo));
            intent.PutExtra("Zoek", _adapter.GetItem(e.Position).ToString());
            StartActivity(intent);
        }

        void _sv_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            _adapter.Filter.InvokeFilter(e.NewText);
        }
    }
}