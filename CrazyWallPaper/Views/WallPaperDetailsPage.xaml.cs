using System;
using System.Collections.Generic;
using Stormlion.PhotoBrowser;
using Xamarin.Forms;

namespace CrazyWallPaper.Views
{
    public partial class WallPaperDetailsPage : ContentPage
    {
        public WallPaperDetailsPage()
        {
            InitializeComponent();
            LoadDownloadButton();
            LoadImage();
        }


        public void LoadDownloadButton()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    btn_Download.FontFamily = "Font Awesome 5 Free";
                    break;
                case Device.Android:
                default:
                    btn_Download.FontFamily = "fa-solid-900.ttf#Font Awesome 5 Free Solid";
                    break;
            }
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public void LoadImage()
        {
            new PhotoBrowser
            {
                Photos = new List<Photo>
        {
            new Photo
            {
                URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Vincent.jpg",
                Title = "Vincent"
            }
        },
            
                ActionButtonPressed = (index) =>
                {
                },
                
                

                //BackgroundColor = Color.White,
                //DidDisplayPhoto = (index) =>
                //{
                //    Debug.WriteLine($"Selection changed: {index}");
                //},

                //Android_ContainerPaddingPx = 20,
                //iOS_ZoomPhotosToFill = false
            }.Show();
        }
    }
}
