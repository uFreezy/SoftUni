using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OnlineShop.Models;

namespace OnlineShop.Service.Models.ViewModels
{
    public class AdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UserViewModel Owner { get; set; }

        public string Type { get; set; }

        public DateTime PostedOn { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }


        public static Expression<Func<Ad, AdViewModel>> Create
        {
            get
            {
                return ad => new AdViewModel
                {
                    Categories = ad.Categories
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        }),
                    Id = ad.Id,
                    Name = ad.Name,
                    Description = ad.Description,
                    Owner = new UserViewModel
                    {
                        Id = ad.Id,
                        Username = ad.Name
                    },
                    Type = ad.Type.Name,
                    PostedOn = ad.PostedOn
                   
                };
            }
        } 

        //3.	Create a AdViewModel holding all the things we wish to project from an ad - 
        //id, name, price, owner(which is a UserViewModel holding the id and username of the ad owner), etc.
    }
}