using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsfeed.API.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Text { get; set; }
        public string PublishedDate { get; set; }
    }
}