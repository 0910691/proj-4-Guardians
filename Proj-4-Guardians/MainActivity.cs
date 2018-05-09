using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Proj_4_Guardians
{
    [Activity(Label = "Proj_4_Guardians", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ImageButton mImageButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // uitleg voor image en tekst in een grid
            // https://assist-software.net/snippets/android-button-place-image-center-and-text-bottom
            // image button : https://www.youtube.com/watch?v=bZd-jUK_egE

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Category);
            ActionBar.Hide();

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
            
            ImageButton drank_ = FindViewById<ImageButton>(Resource.Id.ImbDrank);
            drank_.Click += delegate {
                SetContentView(Resource.Layout.Category2);
                ActionBar.Hide();
            };
            mImageButton = FindViewById<ImageButton>(Resource.Id.ImbPapier);
            mImageButton.Click += MImageButton_Click;
        }

        private void MImageButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity2));
            this.StartActivity(intent);
        }

        private void Tester_Click(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.Category);
            ActionBar.Hide();
        }
    }
}

