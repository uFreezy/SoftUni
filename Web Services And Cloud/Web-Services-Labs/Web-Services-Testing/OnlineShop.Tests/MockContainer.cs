using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Tests
{
    public class MockContainer
    {
        public Mock<IRepository<ApplicationUser>> ApplicationUserRepoMock { get; set; }
        public Mock<IRepository<AdType>> AdTypeRepoMock { get; set; }
        public Mock<IRepository<Ad>> AdRepoMock { get; set; }
        public Mock<IRepository<Category>> CategoryRepoMock { get; set; }

        public void PrepareMocks()
        {
            SetupFakeApplicationUsers();

            SetupFakeAdTypes();

            SetupFakeAds();

            SetupFakeCategories();
        }

        public void SetupFakeCategories()
        {
            var fakeCat = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Sample 1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Sample 2"
                },
                new Category
                {
                    Id = 3,
                    Name = "Sample 3"
                }
            };

            CategoryRepoMock = new Mock<IRepository<Category>>();
            CategoryRepoMock.Setup(r => r.All())
                .Returns(fakeCat.AsQueryable());

            CategoryRepoMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) => { return fakeCat.FirstOrDefault(f => f.Id == id); });
        }

        public void SetupFakeAds()
        {
            var adTypes = new List<AdType>
            {
                new AdType {Name = "Normal", Index = 100},
                new AdType {Name = "Premium", Index = 200}
            };

            var fakeAds = new List<Ad>
            {
                new Ad
                {
                    Id = 1,
                    Name = "BMW 320",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser {UserName = "Gosho", Id = "123"},
                    Price = 100
                },
                new Ad
                {
                    Id = 2,
                    Name = "Audi 80",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser {UserName = "Pesho", Id = "124"},
                    Price = 200
                },
                new Ad
                {
                    Id = 1,
                    Name = "Golf 3ka",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser {UserName = "Ivan", Id = "125"},
                    Price = 300
                }
            };


            AdRepoMock = new Mock<IRepository<Ad>>();
            AdRepoMock.Setup(r => r.All())
                .Returns(fakeAds.AsQueryable());

            AdRepoMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) => { return fakeAds.FirstOrDefault(f => f.Id == id); });
        }

        public void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>
            {
                new AdType
                {
                    Id = 1,
                    Name = "Type1",
                    Index = 100
                },
                new AdType
                {
                    Id = 2,
                    Name = "Type2",
                    Index = 200
                },
                new AdType
                {
                    Id = 3,
                    Name = "Type3",
                    Index = 300
                }
            };


            AdTypeRepoMock = new Mock<IRepository<AdType>>();
            AdTypeRepoMock.Setup(r => r.All())
                .Returns(fakeAdTypes.AsQueryable());

            AdTypeRepoMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) => { return fakeAdTypes.FirstOrDefault(f => f.Id == id); });
        }

        public void SetupFakeApplicationUsers()
        {
            var fakeUsers = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "123",
                    Email = "pesho@goshev.bg",
                    UserName = "peshkata123"
                }
            };

            ApplicationUserRepoMock = new Mock<IRepository<ApplicationUser>>();
            ApplicationUserRepoMock.Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());

            ApplicationUserRepoMock.Setup(r => r.Find(It.IsAny<string>()))
                .Returns((string id) => { return fakeUsers.FirstOrDefault(f => f.Id == id); });
        }
    }
}