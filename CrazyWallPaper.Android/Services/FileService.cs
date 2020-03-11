using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using CrazyWallPaper.Droid.Services;
using CrazyWallPaper.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace CrazyWallPaper.Droid.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }

        Context CurrentContext => CrossCurrentActivity.Current.Activity;
        public void SaveImageFromByte(byte[] imageByte, string filename)
        {
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

        public void SavePicture(string name, Stream data, string location = "temp")
        {
            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //documentsPath = Path.Combine(documentsPath, "Images", location);
            //Directory.CreateDirectory(documentsPath);

            //string filePath = Path.Combine(documentsPath, name);

            //byte[] bArray = new byte[data.Length];
            //using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            //{
            //    using (data)
            //    {
            //        data.Read(bArray, 0, (int)data.Length);
            //    }
            //    int length = bArray.Length;
            //    fs.Write(bArray, 0, length);
            //}
        }

        //public Task<Stream> GetImageStreamAsync()
        //{
        //    // Define the Intent for getting images
        //    Intent intent = new Intent();
        //    intent.SetType("image/*");
        //    intent.SetAction(Intent.ActionGetContent);

        //    // Start the picture-picker activity (resumes in MainActivity.cs)
        //    MainActivity.Instance.StartActivityForResult(
        //        Intent.CreateChooser(intent, "Select Picture"),
        //        MainActivity.PickImageId);

        //    // Save the TaskCompletionSource object as a MainActivity property
        //    MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

        //    // Return Task object
        //    return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        //}
    }
}
