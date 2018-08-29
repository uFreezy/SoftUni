using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using OnlineShop.Models;
using OnlineShop.Service.Models.BindingModels;
using OnlineShop.Service.Models.ViewModels;

namespace OnlineShop.Service.Controllers
{
    public class AdsController : BaseApiController
    {
        //GET api/Ads
        [HttpGet]
        public IHttpActionResult GetAds()
        {
            if (!Data.Ads.Any())
                return NotFound();

            var Ads = Data.Ads
                .Where(ad => ad.Status == 0)
                .OrderByDescending(ad => ad.TypeId)
                .ThenBy(ad => ad.PostedOn)
                .Select(AdViewModel.Create);

            return Ok(Ads);
        }

        //POST api/Ads
        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateAd([FromBody] CreateAdBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!model.Categories.Any())
                return BadRequest("You must specify at least 1 category!");

            if (model.Categories.Count() > 3)
                return BadRequest("You cannot have more than 3 categories!");

            if (!Data.AdTypes.Any(ad => ad.Id == model.TypeId))
                return BadRequest("Type with the Id specified doesnt exist!");

            if (Data.Categories.Where(c => model.Categories.Contains(c.Id)).ToList().Count != model.Categories.Count())
                return BadRequest("One or more of the specified category Id's doesnt belong to a category!");


            var uId = User.Identity.GetUserId();

            var add = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                TypeId = model.TypeId,
                Status = 0,
                PostedOn = DateTime.Now,
                OwnerId = uId,
                Price = model.Price,
                Categories = (Data.Categories.Where(c => model.Categories.Contains(c.Id)))
                    .ToList()
            };


            Data.Ads.Add(add);

            Data.SaveChanges();

            var result = Data.Ads.Where(d => d.Id == add.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return Ok(result);
        }

        //PUT api/ads/{id}/close 
        [HttpPut]
        [Authorize]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            if (!Data.Ads.Any(a => a.Id == id))
                return BadRequest("No such ad!");
            ;

            if (Data.Ads.First(a => a.Id == id).OwnerId != User.Identity.GetUserId())
                return Unauthorized();

            var ad = Data.Ads.First(a => a.Id == id);

            ad.Status = AdStatus.Closed;

            ad.ClosedOn = DateTime.Now;

            Data.SaveChanges();

            return Ok();
        }
    }
}