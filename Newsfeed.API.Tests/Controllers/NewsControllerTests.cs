using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newsfeed.API.Controllers;
using Newsfeed.API.Models;
using Newsfeed.API.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Newsfeed.API.Tests.Controllers
{
   public class NewsControllerTests
    {
        [TestClass]
        public class NewsControllerTest
        {
            [TestMethod]
            public void RetrieveData()
            {
                var mockRepository = new Mock<INewsRepository>();

                List<News> news = new List<News>
                {
                    new News() {NewsId = 1, Text = "test1",PublishedDate = "1/1/2016"},
                    new News(){NewsId = 1, Text = "test1",PublishedDate = "1/3/2016"},
                    new News(){NewsId = 1, Text = "test1",PublishedDate = "1/6/2016"},
                };

                mockRepository.Setup(x => x.Retrieve()).Returns(news);
                // Arrange
                NewsController controller = new NewsController(mockRepository.Object);

                // Act
                IHttpActionResult response = controller.Get();
                var contentResult = response as OkNegotiatedContentResult<IEnumerable<News>>;
                
                // Assert
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(3, contentResult.Content.ToList().Count);
            }
        }
    }
}
