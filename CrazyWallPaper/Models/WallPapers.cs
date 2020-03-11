using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace CrazyWallPaper.Models
{
    public class WallPaper
    {
        public int total { get; set; }
        public int total_pages { get; set; }
        public ObservableCollection<Result> results { get; set; }
    }

    public class Urls
    {
        public string raw { get; set; }
        public string full { get; set; }
        public string regular { get; set; }
        public string small { get; set; }
        public string thumb { get; set; }
    }

    public class ProfileImage
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class Type
    {
        public string slug { get; set; }
        public string pretty_slug { get; set; }
    }

    public class Category
    {
        public string slug { get; set; }
        public string pretty_slug { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime? promoted_at { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string alt_description { get; set; }
        public Urls urls { get; set; }
        public List<object> categories { get; set; }
        public int likes { get; set; }
        public bool liked_by_user { get; set; }
        public List<object> current_user_collections { get; set; }
        public User user { get; set; }
    }



}
