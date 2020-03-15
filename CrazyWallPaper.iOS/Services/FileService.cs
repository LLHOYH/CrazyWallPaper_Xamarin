using System;
using System.IO;
using System.Threading.Tasks;
using CrazyWallPaper.iOS.Services;
using CrazyWallPaper.Services;
using Foundation;
using Photos;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace CrazyWallPaper.iOS.Services
{

    public class FileService : IFileService
    {

        public void SaveImageFromByteAsync(byte[] imageByte, string fileName)
        {
            var imageData = new UIImage(NSData.FromArray(imageByte));

            //PHPhotoLibrary.RequestAuthorization(status =>
            //{
            //    switch (status)
            //    {
            //        case PHAuthorizationStatus.Restricted:
            //        case PHAuthorizationStatus.Denied:
            //            // nope you don't have permission
            //            break;
            //        case PHAuthorizationStatus.Authorized:

                        imageData.SaveToPhotosAlbum((image, error) =>
                        {
                            //you can retrieve the saved UI Image as well if needed using  
                            //var i = image as UIImage;  
                            if (error != null)
                            {
                                Console.WriteLine(error.ToString());
                            }
                        });
                        //break;
            //    }
            //});

        }



        //select image from photo library

        //TaskCompletionSource<Stream> taskCompletionSource;
        //UIImagePickerController imagePicker;

        //public Task<Stream> GetImageStreamAsync()
        //{
        //    // Create and define UIImagePickerController
        //    imagePicker = new UIImagePickerController
        //    {
        //        SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
        //        MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
        //    };

        //    // Set event handlers
        //    imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
        //    imagePicker.Canceled += OnImagePickerCancelled;

        //    // Present UIImagePickerController;
        //    UIWindow window = UIApplication.SharedApplication.KeyWindow;
        //    var viewController = window.RootViewController;
        //    viewController.PresentModalViewController(imagePicker, true);

        //    // Return Task object
        //    taskCompletionSource = new TaskCompletionSource<Stream>();
        //    return taskCompletionSource.Task;
        //}

        //void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        //{
        //    UIImage image = args.EditedImage ?? args.OriginalImage;

        //    if (image != null)
        //    {
        //        // Convert UIImage to .NET Stream object
        //        NSData data;
        //        if (args.ReferenceUrl.PathExtension.Equals("PNG") || args.ReferenceUrl.PathExtension.Equals("png"))
        //        {
        //            data = image.AsPNG();
        //        }
        //        else
        //        {
        //            data = image.AsJPEG(1);
        //        }
        //        Stream stream = data.AsStream();

        //        UnregisterEventHandlers();

        //        // Set the Stream as the completion of the Task
        //        taskCompletionSource.SetResult(stream);
        //    }
        //    else
        //    {
        //        UnregisterEventHandlers();
        //        taskCompletionSource.SetResult(null);
        //    }
        //    imagePicker.DismissModalViewController(true);
        //}

        //void OnImagePickerCancelled(object sender, EventArgs args)
        //{
        //    UnregisterEventHandlers();
        //    taskCompletionSource.SetResult(null);
        //    imagePicker.DismissModalViewController(true);
        //}

        //void UnregisterEventHandlers()
        //{
        //    imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
        //    imagePicker.Canceled -= OnImagePickerCancelled;
        //}
    }
}
