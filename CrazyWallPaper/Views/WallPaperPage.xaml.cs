using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using CrazyWallPaper.EnumObjects;
using CrazyWallPaper.Models;
using CrazyWallPaper.Services;
using CrazyWallPaper.ViewModels;
using Newtonsoft.Json;
using Stormlion.PhotoBrowser;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace CrazyWallPaper.Views
{
    public partial class WallPaperPage : ContentPage
    {

        public WallPaperPage()
        {
            BindingContext = new WallPaperViewModel();
            InitializeComponent();
            LoadColorCat();
        }

        async void cv_WallPapers_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            Result selectedWallPaper = (e.CurrentSelection[0] as Result);
            //var wallpaperDetailsVM = new WallPaperDetailsViewModel
            //{
            //    ImgID = selectedWallPaper?.id,
            //    ImgUrl = selectedWallPaper?.urls.regular
            //};

            //var wallpaperDetails = new WallPaperDetailsPage();
            //wallpaperDetails.BindingContext = wallpaperDetailsVM;
            //await Navigation.PushModalAsync(wallpaperDetails, true);

            LoadImage(selectedWallPaper?.urls.regular);
        }


        public void LoadImage(string ImgUrl)
        {
            new PhotoBrowser
            {
                Photos = new List<Photo>
                {
                    new Photo
                    {
                        URL = ImgUrl
                    }
                },

                ActionButtonPressed = async (index) =>
                {
                    await DisplayAlert("download?", "download", "Nope");
                },

            }.Show();
        }

        void LoadColorCat()
        {
            List<string> colorNames = new List<string>();

            colorNames = Enum.GetNames(typeof(ColorCategoryEnums)).Cast<string>().ToList();

            if (Device.RuntimePlatform == Device.Android)
            {
                foreach (string colorName in colorNames)
                {
                    Frame frame = new Frame();
                    frame.BorderColor = Color.FromHex("#ff7600");
                    frame.CornerRadius = 40;
                    frame.WidthRequest = 80;
                    frame.Padding = 0;
                    frame.VerticalOptions = LayoutOptions.FillAndExpand;
                    Button button = new Button
                    {
                        Text = colorName,
                        TextColor = Color.FromHex("#ff7600"),
                        BackgroundColor = Color.Transparent,
                        Padding = -5,
                        FontSize = 10,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                    };
                    frame.Content = button;
                    sl_ColorCat.Children.Add(frame);
                }
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                foreach (string colorName in colorNames)
                {
                    Frame frame = new Frame();
                    frame.BorderColor = Color.FromHex("#ff7600");
                    frame.CornerRadius = 15;
                    frame.WidthRequest = 80;
                    frame.Padding = 0;
                    frame.HasShadow = false;
                    frame.VerticalOptions = LayoutOptions.FillAndExpand;
                    Button button = new Button
                    {
                        Text = colorName,
                        TextColor = Color.FromHex("#ff7600"),
                        BackgroundColor = Color.Transparent,
                        FontSize = 10,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                    };
                    frame.Content = button;
                    sl_ColorCat.Children.Add(frame);
                }
            }

            sv_ColorCat.Content = sl_ColorCat;
        }
    }
}
