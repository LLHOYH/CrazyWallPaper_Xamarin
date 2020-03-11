using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using CrazyWallPaper.Models;
using CrazyWallPaper.Services;
using CrazyWallPaper.ViewModels;
using Newtonsoft.Json;
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
        }

        async void cv_WallPapers_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            Result selectedWallPaper = (e.CurrentSelection[0] as Result);
            var wallpaperDetailsVM = new WallPaperDetailsViewModel
            {
                ImgUrl = selectedWallPaper?.urls.regular
            };

            var wallpaperDetails = new WallPaperDetailsPage();
            wallpaperDetails.BindingContext = wallpaperDetailsVM;
            await Navigation.PushAsync(wallpaperDetails, true);
        }
    }
}
