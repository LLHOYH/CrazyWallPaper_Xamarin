using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using CrazyWallPaper.EnumObjects;
using CrazyWallPaper.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CrazyWallPaper.ViewModels
{
    public class WallPaperViewModel : BaseViewModel
    {
        private readonly string apiKey = "untxjeopIOEWhcjrYaxJHUPw5cXVusW6sWJ2kW8w3l8";
        private readonly string apiPath = "https://api.unsplash.com/";
        private readonly string imgOritention = "squarish";
        public WallPaperViewModel()
        {
            WallPapers = new WallPaper();
            Results = new ObservableCollection<Result>();
            ColorCategory = new List<ColorCategories>();
            WallPapersBindingCommand = new Command(BindWallPapers);
            BindColorCategories();
            BindWallPapers();
        }




        public class ColorCategories
        {
            public ColorCategories(string colorName)
            {

                ColorName = colorName;
            }

            public string ColorName { get; set; }

        }



        WallPaper wallPapers;
        public WallPaper WallPapers
        {
            get { return wallPapers; }
            set { SetProperty(ref wallPapers, value); }
        }

        ObservableCollection<Result> results;
        public ObservableCollection<Result> Results
        {
            get { return results; }
            set { SetProperty(ref results, value); }
        }

        List<ColorCategories> colorCategory;
        public List<ColorCategories> ColorCategory
        {
            get { return colorCategory; }
            set { SetProperty(ref colorCategory, value); }
        }

        string searchQuery;
        public string SearchQuery
        {
            get { return searchQuery; }
            set { SetProperty(ref searchQuery, value); }
        }

        Command wallPapersBindingCommand;
        public Command WallPapersBindingCommand
        {
            get { return wallPapersBindingCommand; }
            set { SetProperty(ref wallPapersBindingCommand, value); }
        }

        string fullUri;

        public void BindColorCategories()
        {
            List<string> colorNames = new List<string>();

            colorNames = Enum.GetNames(typeof(ColorCategoryEnums)).Cast<string>().ToList();

            foreach(string colorName in colorNames)
            {
                ColorCategory.Add(new ColorCategories(colorName));
            }
        }

        public async void BindWallPapers()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var width = int.Parse(mainDisplayInfo.Width.ToString());
            var height = int.Parse(mainDisplayInfo.Height.ToString());


            HttpClient _client = new HttpClient();
            ObservableCollection<Result> resultsCustom = new ObservableCollection<Result>();
            //fullUri = apiPath + "photos?client_id=" + apiKey + "&per_page=30"+ "&w=" + (width / 2).ToString() + "&h=" + (height / 2).ToString() + "&dpi=2";
            fullUri = apiPath + "photos?client_id=" + apiKey + "&orientation=" + imgOritention + "&per_page=10";


            if (string.IsNullOrEmpty(SearchQuery))
            {
                var uri = new Uri(fullUri);
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    Results = JsonConvert.DeserializeObject<ObservableCollection<Result>>(jsonString);

                }
            }
            else if (!string.IsNullOrEmpty(SearchQuery))
            {
                fullUri += "&query=" + SearchQuery;

                var uri = new Uri(fullUri);
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    WallPapers = JsonConvert.DeserializeObject<WallPaper>(jsonString);
                    if (WallPapers.results.Count > 0)
                        Results = wallPapers.results;
                }
            }

            

        }
    }
}
