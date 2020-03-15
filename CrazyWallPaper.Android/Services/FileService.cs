using System;
using System.IO;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.Content;
using CrazyWallPaper.Droid.Services;
using CrazyWallPaper.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace CrazyWallPaper.Droid.Services
{
    public class FileService : IFileService
    {
        MainActivity activity = new MainActivity();

        public FileService()
        {
        }

        Context CurrentContext => CrossCurrentActivity.Current.Activity;
        public void SaveImageFromByte(byte[] imageByte, string filename)
        {

            var thisActivity = Forms.Context as Activity;

            if (ContextCompat.CheckSelfPermission(Android.App.Application.Context, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            {
                //permission granted
                try
            {
                    Java.IO.File storagePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                    string path = System.IO.Path.Combine(storagePath.ToString(), filename);
                    System.IO.File.WriteAllBytes(path, imageByte);
                    var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                    mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));
                    CurrentContext.SendBroadcast(mediaScanIntent);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                new MainActivity().AskPermission(thisActivity);
            }
        }


    }
}
