using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using News.Data;
using News.Services.Controllers;
using News.Services.Models.BindingModels;
using News.Services.Models.ViewModels;

namespace News.Tests.UnitTests
{
    [TestClass]
    public class NewsControllerTests
    {
        private MockContainer _mocks;

        [TestInitialize]
        public void InitTest()
        {
            _mocks = new MockContainer();
            _mocks.PrepareMocks();
        }

        [TestMethod]
        public void Listing_All_News_Should_Return_Them_Correctly()
        {
            var fakeNews = _mocks.NewsRepoMock.Object.All();

            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News.All())
                .Returns(fakeNews);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.GetAllNews().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var newsResponse = response.Content.ReadAsAsync<IEnumerable<NewsViewModel>>()
                .Result
                .Select(n => n.Id)
                .ToList();

            var fakeNewsList = fakeNews
                .OrderByDescending(n => n.PublishDate)
                .Select(n => n.Id)
                .ToList();

            CollectionAssert.AreEqual(newsResponse, fakeNewsList);
        }

        [TestMethod]
        public void Creating_News_Should_Create_And_Return_The_News()
        {
            var news = new List<Models.News>();

            _mocks.NewsRepoMock
                .Setup(r => r.Add(It.IsAny<Models.News>()))
                .Callback((Models.News n) => { news.Add(n); });

            var fakeNews = new NewsBindingModel
            {
                Title = "Sample title",
                Content = "Sample content",
                PublishedOn = DateTime.Now
            };

            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.PostNews(fakeNews).ExecuteAsync(CancellationToken.None).Result;

            var newsResponse = response.Content.ReadAsAsync<NewsBindingModel>().Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(news.Count, 1);

            //It's something
            Assert.AreEqual(fakeNews.Title, newsResponse.Title);
        }

        [TestMethod]
        public void Creating_News_With_Incorrect_Data_Should_Return_BadRequest()
        {
            var news = new List<Models.News>();

            _mocks.NewsRepoMock
                .Setup(r => r.Add(It.IsAny<Models.News>()))
                .Callback((Models.News n) => { news.Add(n); });

            var fakeNews = new NewsBindingModel
            {
                Title = null,
                Content = null,
                PublishedOn = DateTime.Now
            };

            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.PostNews(fakeNews).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);

            mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Modify_Existing_News_Item_With_Correct_Data_Modifies_The_Item()
        {
            var updatedNews = new NewsBindingModel
            {
                Title = "Update",
                Content = "Update",
                PublishedOn = DateTime.Now
            };

            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.UpdateNews(1,updatedNews).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Modify_Existing_News_Item_With_Incorrect_Data_Should_Return_BadRequest()
        {
            var updatedNews = new NewsBindingModel
            {
                Title = null,
                Content = null,
                PublishedOn = DateTime.Now
            };

            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.UpdateNews(1, updatedNews).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);

            mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Modifying_Non_Existing_News_Should_Return_BadRequest()
        {
            var updatedNews = new NewsBindingModel
            {
                Title = "Update",
                Content = "Update",
                PublishedOn = DateTime.Now
            };

            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.UpdateNews(100000, updatedNews).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);

            mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void Deleting_Existing_Item_Should_Delete_It_Successfully()
        {
            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.DeleteNews(1).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Deleteing_Non_Existing_Item_Should_Return_BadRequest()
        {
            var mockContext = new Mock<INewsData>();

            mockContext.Setup(c => c.News)
                .Returns(_mocks.NewsRepoMock.Object);

            var newsController = new NewsController(mockContext.Object);
            SetupController(newsController);

            var response = newsController.DeleteNews(1000000).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);

            mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }

        private void SetupController(NewsController newsController)
        {
            newsController.Request = new HttpRequestMessage();
            newsController.Configuration = new HttpConfiguration();
        }
    }
}