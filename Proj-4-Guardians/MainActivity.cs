using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace Proj_4_Guardians
{
    [Activity(Label = "Recycler", MainLauncher = true, Icon = "@drawable/Recycle")]
    public class MainActivity : Activity
    {
        private ImageButton mBtnRecycle;
        private ImageButton BtnMenu;
        private SearchView Search;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // uitleg voor image en tekst in een grid
            // https://assist-software.net/snippets/android-button-place-image-center-and-text-bottom
            // image button : https://www.youtube.com/watch?v=bZd-jUK_egE
            // SearchView : https://www.youtube.com/watch?v=4FvObC44bhM

            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();

            mBtnRecycle = FindViewById<ImageButton>(Resource.Id.ImbRecycle);
            mBtnRecycle.Click += MBtnRecycle_Click;

            Search = FindViewById<SearchView>(Resource.Id.ScvZoekMain);
            Search.SetQueryHint("Papier, Plastic, Glas");

            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMenu.Click += BtnMenu_Click;           
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MenuOverlay Menu_overlay = new MenuOverlay();
            Menu_overlay.Show(transaction, "Menu");
        }

        private void MBtnRecycle_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category));
            StartActivity(intent);
        }
    }
}

