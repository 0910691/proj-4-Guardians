using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views.InputMethods;

namespace Proj_4_Guardians
{
    [Activity(Label = "Recycler", MainLauncher = true, Icon = "@drawable/Recycle")]
    public class MainActivity : Activity
    {
        ImageButton mBtnRecycle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // uitleg voor image en tekst in een grid
            // https://assist-software.net/snippets/android-button-place-image-center-and-text-bottom
            // image button : https://www.youtube.com/watch?v=bZd-jUK_egE
            // SearchView : https://www.youtube.com/watch?v=4FvObC44bhM

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();
            mBtnRecycle = FindViewById<ImageButton>(Resource.Id.ImbRecycle);
            mBtnRecycle.Click += MBtnRecycle_Click;

            SearchView search = FindViewById<SearchView>(Resource.Id.ScvZoekMain);
            search.SetQueryHint("Papier, Plastic, Glas");

            var txt = FindViewById<TextView>(Resource.Id.TxvUitleg3);
            txt.Click += (e, o) =>
            {
                Toast.MakeText(this, "text clicked", ToastLength.Long).Show();
            };
            
            
            
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

        private void MBtnRecycle_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Category));
            this.StartActivity(intent);
        }
    }
}

