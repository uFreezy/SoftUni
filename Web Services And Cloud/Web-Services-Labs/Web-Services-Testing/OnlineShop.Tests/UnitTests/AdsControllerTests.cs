using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Service.Controllers;
using OnlineShop.Service.Infrastructure;
using OnlineShop.Service.Models.BindingModels;
using OnlineShop.Service.Models.ViewModels;

namespace OnlineShop.Tests.UnitTests
{
    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer _mocks;

        [TestInitialize]
        public void InitTest()
        {
            _mocks = new MockContainer();
            _mocks.PrepareMocks();
        }

        [TestMethod]
        public void GetAllAds_Should_Return_Total_Ads_Sorted_By_TypeIndex()
        {
            var fakeAds = _mocks.AdRepoMock.Object.All();

            var mockContext = new Mock<IOnlineShopData>();

            mockContext.Setup(c => c.Ads.All())
                .Returns(fakeAds);

            var mockUserIdProvider = new Mock<IUserIdProvider>();
            mockContext.Setup(c => c.Ads.All())
                .Returns(fakeAds);

            var adsController = new AdsController(mockContext.Object, mockUserIdProvider.Object);
            SetupController(adsController);

            var response = adsController.GetAds().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var adsResponse = response.Content.ReadAsAsync<IEnumerable<AdViewModel>>()
                .Result
                .Select(ad => ad.Id)
                .ToList();

            var orderedFakeAds = fakeAds.OrderBy(ad => ad.Type)
                .ThenBy(ad => ad.PostedOn)
                .Select(ad => ad.Id)
                .ToList();

            CollectionAssert.AreEqual(adsResponse, orderedFakeAds);
        }

        [TestMethod]
        public void CreateAd_Should_Successfully_Add_To_Repository()
        {
            var ads = new List<Ad>();

            var fakeUser = _mocks.ApplicationUserRepoMock.Object.All()
                .FirstOrDefault();

            if (fakeUser == null)
            {
                Assert.Fail("No users to perform the test with.");
            }

            _mocks.AdRepoMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                {
                    ad.Owner = fakeUser;
                    ads.Add(ad);
                    
                });

            var mockContext = new Mock<IOnlineShopData>();

            mockContext.Setup(c => c.Ads)
                .Returns(this._mocks.AdRepoMock.Object);
            mockContext.Setup(c => c.AdTypes)
                .Returns(this._mocks.AdTypeRepoMock.Object);
            mockContext.Setup(c => c.Categories)
                .Returns(this._mocks.CategoryRepoMock.Object);
            mockContext.Setup(c => c.Users)
                .Returns(this._mocks.ApplicationUserRepoMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);

            this.SetupController(adsController);

            var randomName = Guid.NewGuid().ToString();

            var newAdd = new CreateAdBindingModel
            {
                Name = randomName,
                Price = 555,
                TypeId = 1,
                Description = "Sample text",
                Categories = new[] { 1, 2, 3 }
            };

            var response = adsController.CreateAd(newAdd)
                .ExecuteAsync(CancellationToken.None)
                .Result;

            Assert.AreEqual(response.StatusCode,HttpStatusCode.OK);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(ads.Count, 1);

            Assert.AreEqual(ads[0].Name, randomName);
        }

        [TestMethod]
        public void Closing_Ads_As_Owner_Should_Return_200OK()
        {
            var fakeAd = this._mocks.AdRepoMock.Object.All()
                .FirstOrDefault(ad => ad.Status == AdStatus.Open);

            if (fakeAd == null)
                Assert.Fail("No ads available to perform the test.");

            var adId = fakeAd.Id;

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this._mocks.AdRepoMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns(fakeAd.OwnerId);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);

            this.SetupController(adsController);

            var response = adsController.CloseAd(adId)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreNotEqual(_mocks.AdRepoMock.Object.All().FirstOrDefault(ad => ad.Id == adId), null);

            Assert.AreEqual(_mocks.AdRepoMock.Object.All().FirstOrDefault(ad => ad.Id == adId).Status, AdStatus.Closed);
        }

        [TestMethod]
        public void Closing_Ads_As_Non_Owner_Should_Return_400BadRequest()
        {
            var fakeAd = this._mocks.AdRepoMock.Object.All()
               .FirstOrDefault(ad => ad.Status == AdStatus.Open);

            if (fakeAd == null)
                Assert.Fail("No ads available to perform the test.");

            var adId = fakeAd.Id;

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this._mocks.AdRepoMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns("Ivan4o");

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);

            this.SetupController(adsController);

            var response = adsController.CloseAd(adId)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized);

            mockContext.Verify(c => c.SaveChanges(), Times.Never);

            Assert.AreEqual(_mocks.AdRepoMock.Object.All().FirstOrDefault(ad => ad.Id == adId).Status, AdStatus.Open);

        }

        private void SetupController(AdsController adsController)
        {
            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();
        }
    }
}