//
//
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using Android.Gms.Maps;

namespace CADView.Droid
{
    [Activity(Label = "CADView", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,  IOnMapReadyCallback 
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            
            LoadApplication(new App());
        
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnMapReady(GoogleMap map)
        {
            //base.OnMapReady(map);

            //map.MapType = GoogleMap.MapTypeTerrain;    //.MapTypeHybrid;

            map.MyLocationEnabled = true;                 // !!!
            map.UiSettings.MyLocationButtonEnabled = true;
            map.UiSettings.ZoomControlsEnabled = true;      //
            map.UiSettings.ZoomGesturesEnabled = true;
            map.UiSettings.CompassEnabled = true;           //
            
        }

    }
}