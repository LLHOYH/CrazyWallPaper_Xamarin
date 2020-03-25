using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrazyWallPaper.Views;

namespace CrazyWallPaper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new WallPaperPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
