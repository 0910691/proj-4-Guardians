using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Proj_4_Guardians
{
    [Activity(Label = "Category2")]
    public class Category2 : Activity
    {
        private ImageButton BtnMenu;
        private Button BtnFinal;
        private TextView testText;
        private string DataToDisplay;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Category2);
            ActionBar.Hide();

            //↓ deze gaat gebruikt worden om te weten welke category er is geselecteerd
            if (Intent.Extras == null)
            {
                Toast.MakeText(this, "Something went wrong, going back to the main-screen", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }

            DataToDisplay = Intent.GetStringExtra("Category").ToUpper();
            if (DataToDisplay == "GLAS")
            {
                // dan moet nu het scherm gevuld worden met de betreffende info              
            }

            // echter hebben we nu alleen text, dus gewoon naar het scherm schrijven
            testText = FindViewById<TextView>(Resource.Id.txtv3);
            testText.Text = DataToDisplay;

            // ↓ klikfuncties ↓
            BtnMenu = FindViewById<ImageButton>(Resource.Id.Menu);
            BtnMenu.Click += BtnMenu_Click;

            BtnFinal = FindViewById<Button>(Resource.Id.Cat2But1);
            BtnFinal.Click += BtnFinal_Click;
        }

        private void BtnFinal_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Finalinfo));
            intent.PutExtra("Category2", "plastic");
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