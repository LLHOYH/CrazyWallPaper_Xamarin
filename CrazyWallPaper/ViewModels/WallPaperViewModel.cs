using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using CrazyWallPaper.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CrazyWallPaper.ViewModels
{
    public class WallPaperViewModel : BaseViewModel
    {
        private readonly string apiKey = "untxjeopIOEWhcjrYaxJHUPw5cXVusW6sWJ2kW8w3l8";
        private readonly string apiPath = "https://api.unsplash.com/";
        public WallPaperViewModel()
        {
            WallPapers = new WallPaper();
            Results = new ObservableCollection<Result>();
            WallPapersBindingCommand = new Command(BindWallPapers);
            BindWallPapers();
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


        public async void BindWallPapers()
        {
            HttpClient _client = new HttpClient();

            if (string.IsNullOrEmpty(SearchQuery))
            {
                fullUri = apiPath + "photos?client_id=" + apiKey + "&per_page=30";

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
                fullUri = apiPath + "search/photos?client_id=" + apiKey + "&query=" + SearchQuery + "&per_page=30";

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
