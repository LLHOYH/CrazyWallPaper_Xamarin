using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using CrazyWallPaper.Models;
using CrazyWallPaper.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CrazyWallPaper.ViewModels
{
    public class WallPaperDetailsViewModel : BaseViewModel
    {
        string imgUrl, imgID;

        public WallPaperDetailsViewModel()
        {
            DownloadCommand = new Command(DownloadImage);
        }

        public string ImgUrl
        {
            get { return imgUrl; }
            set { SetProperty(ref imgUrl, value); }
        }

        public string ImgID
        {
            get { return imgID; }
            set { SetProperty(ref imgID, value); }
        }

        Command downloadCommand;
        public Command DownloadCommand
        {
            get { return downloadCommand; }
            set { SetProperty(ref downloadCommand, value); }
        }

        public void DownloadImage()
        {
            IFileService fileSvc = DependencyService.Get<IFileService>();

            WebClient wc = new WebClient();
            byte[] byteArr = wc.DownloadData(ImgUrl);

            fileSvc.SaveImageFromByte(byteArr, ImgID + ".png");

        }
    }
}
