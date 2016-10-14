using Newsfeed.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Newsfeed.API.Repository.Contracts;

namespace Newsfeed.API.Repository
{
    public class NewsRepository : INewsRepository
    {

        public List<News> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~\App_Data\News.json");
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<News>>(jsonData);
        }

        public News Save(News item)
        {
            var News = Retrieve();
            var maxId = News.Max(p => p.NewsId);
            item.NewsId = maxId + 1;
            News.Add(item);
            WriteData(News);
            return item;

        }

        public bool WriteData(List<News> news)
        {
            string filePath = HostingEnvironment.MapPath(@"~\App_Data\News.json");
            string jsonData = JsonConvert.SerializeObject(news, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            return true;
        }

        public News Create()
        {
            News news = new News
            {
                PublishedDate = DateTime.Now.ToShortDateString()
            };
            return news;
        }
    }
}