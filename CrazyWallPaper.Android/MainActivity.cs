using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Threading.Tasks;
using System.IO;
using Plugin.CurrentActivity;
using Android.Support.V4.App;

namespace CrazyWallPaper.Droid
{
    [Activity(Label = "CrazyWallPaper", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {





        //internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            AskPermission(this);
            Stormlion.PhotoBrowser.Droid.Platform.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            this.Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            LoadApplication(new App());

            //Instance = this;
        }

        public void AskPermission(Activity activity)
        {
            string[] Permission =
        {
            Android.Manifest.Permission.ReadExternalStorage,
            Android.Manifest.Permission.WriteExternalStorage
        };

            int RequestID = 1;
            ActivityCompat.RequestPermissions(activity, Permission, RequestID);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }



        //// ...
        //// Field, property, and method for Picture Picker
        //public static readonly int PickImageId = 1000;

        //public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        //{
        //    base.OnActivityResult(requestCode, resultCode, intent);

        //    if (requestCode == PickImageId)
        //    {
        //        if ((resultCode == Result.Ok) && (intent != null))
        //        {
        //            Android.Net.Uri uri = intent.Data;
        //            Stream stream = ContentResolver.OpenInputStream(uri);

        //            // Set the Stream as the completion of the Task
        //            PickImageTaskCompletionSource.SetResult(stream);
        //        }
        //        else
        //        {
        //            PickImageTaskCompletionSource.SetResult(null);
        //        }
        //    }
        //}
    }
}