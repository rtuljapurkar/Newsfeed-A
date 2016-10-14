using Newsfeed.API.Models;
using System;
namespace Newsfeed.API.Repository.Contracts
{
    public interface INewsRepository
    {
        System.Collections.Generic.List<Newsfeed.API.Models.News> Retrieve();
        Newsfeed.API.Models.News Save(Newsfeed.API.Models.News prd);
        bool WriteData(System.Collections.Generic.List<Newsfeed.API.Models.News> news);

        News Create();
    }
}
