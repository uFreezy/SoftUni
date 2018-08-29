using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using News.Data;

namespace News.Tests
{
    public class MockContainer
    {
        public Mock<IRepository<Models.News>> NewsRepoMock { get; set; }

        public void PrepareMocks()
        {
            SetupFakeNews();
        }

        public void SetupFakeNews()
        {
            var fakeNews = new List<Models.News>
            {
                new Models.News
                {
                    Id = 1,
                    Title = "News 1",
                    Content = "Sample text",
                    PublishDate = DateTime.Now
                },
                new Models.News
                {
                    Id = 2,
                    Title = "News 2",
                    Content = "Sample text",
                    PublishDate = DateTime.Now
                },
                new Models.News
                {
                    Id = 3,
                    Title = "News 3",
                    Content = "Sample text",
                    PublishDate = DateTime.Now
                }
            };


            NewsRepoMock = new Mock<IRepository<Models.News>>();
            NewsRepoMock.Setup(r => r.All())
                .Returns(fakeNews.AsQueryable());

            NewsRepoMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) => { return fakeNews.FirstOrDefault(f => f.Id == id); });
        }
    }
}