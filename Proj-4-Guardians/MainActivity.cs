using Android.App;
using Android.Widget;
using Android.OS;

namespace Proj_4_Guardians
{
    [Activity(Label = "Proj_4_Guardians", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // uitleg voor image en tekst in een grid
            // https://assist-software.net/snippets/android-button-place-image-center-and-text-bottom

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

