using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Data;

namespace News.RepoTests
{
    [TestClass]
    public class NewsRepoTests
    {
        private static readonly NewsData repo = new NewsData(new NewsContext());
        private TransactionScope _scope;

        [TestInitialize]
        public void Initialize()
        {
            _scope = new TransactionScope();
        }

        [TestMethod]
        public void Listing_All_News_Should_Return_Them_Correctly()
        {
            var news = repo.News.All().ToList();

            Assert.IsNotNull(repo);
            CollectionAssert.AreEqual(news, repo.News.All().ToList());
        }

        [TestMethod]
        public void Creating_News_Should_Create_And_Return_The_News()
        {
            var news = new Models.News
            {
                Title = "New 1",
                Content = "New 1",
                PublishDate = DateTime.Now
            };

            repo.News.Add(news);

            repo.SaveChanges();

            var newsFromDb = repo.News.Find(news.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(news, newsFromDb);
        }

        [TestMethod]
        [ExpectedException(typeof (DbEntityValidationException))]
        public void Creating_News_With_Incorrect_Data_Should_Throw_Exception()
        {
            var fakeNews = new Models.News
            {
                Title = null,
                Content = null,
                PublishDate = DateTime.Now
            };

            repo.News.Add(fakeNews);

            repo.SaveChanges();
        }

        [TestMethod]
        public void Modify_Existing_News_Item_With_Correct_Data_Modifies_The_Item()
        {
            var news = new Models.News
            {
                Id = 2,
                Title = "Modified",
                Content = "Modified",
                PublishDate = DateTime.Now
            };

            repo.News.Update(news);

            repo.SaveChanges();

            var modifiedNews = repo.News.Find(2);

            Assert.IsNotNull(modifiedNews);
            Assert.AreEqual(news, modifiedNews);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Modify_Existing_News_Item_With_Incorrect_Data_Should_Throw_Exception()
        {
            var news = new Models.News
            {
                Id = 2,
                Title = null,
                Content = null,
                PublishDate = DateTime.Now
            };

            repo.News.Update(news);
            repo.SaveChanges();
           
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void Modifying_Non_Existing_News_Should_Throw_Exception()
        {
            var news = new Models.News
            {
                Id = 2000,
                Title = "eeee",
                Content = "Modified",
                PublishDate = DateTime.Now
            };

            repo.News.Update(news);
            repo.SaveChanges();
        }

        [TestMethod]
        public void Deleting_Existing_Item_Should_Delete_It_Successfully()
        {
            var item = repo.News.All().First(n => n.Id == 2);

            repo.News.Delete(item);

            repo.SaveChanges();

            Assert.IsFalse(repo.News.All().Any(n => n.Id == 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Deleting_Non_Existing_Item_Should_Throw_Exception()
        {
            repo.News.Delete(repo.News.All().First(n => n.Id == 20000));

            repo.SaveChanges();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _scope.Dispose();
        }
    }
}