using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Services.Controllers
{
    public class RestaurantsController : BaseApiController
    {
        //GET /api/restaurants?townId={townId}
        [HttpGet]
        [Route("api/restaurants")]
        public IHttpActionResult GetRestaurantsByTown(int townId)
        {
            var restaurants = this.Data.Restaurants.Where(r => r.TownId == townId)
                .Select(r => new ResturantsViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = (r.Ratings.Count == 0) ? 0 : (r.Ratings.Select(ra => ra.Stars).Sum() / r.Ratings.Count),
                    Town = new TownViewModel
                    {
                        Id = r.TownId,
                        Name = r.Town.Name
                    }
                });

            return this.Ok(restaurants);
        }

        //POST api/restaurants
        [HttpPost]
        [Authorize] // !!!
        [Route("api/restaurants")]
        public IHttpActionResult CreateRestaurants(RestaurantsBindingModel m)
        {
            if (!ModelState.IsValid)
                return this.BadRequest();

            var restaurant = new Restaurant
            {
                Name = m.Name,
                TownId = m.TownId,
                OwnerId = User.Identity.GetUserId()
            };

            var townName = this.Data.Towns.FirstOrDefault(t => t.Id == m.TownId).Name;

            this.Data.Restaurants.Add(restaurant);

            this.Data.SaveChanges();

            //Hardcoded location because CreatedAtRoute kept throwing some kind of stupid exception.
            //My code is bad and I should feel bad... But Hey, it works! 
            return this.Created("http://localhost:1337/api/restaurants/" + restaurant.Id, new
            {
                id = restaurant.Id,
                name = restaurant.Name,
                rating = (Rating)null,
                town = new 
                {
                    id = restaurant.TownId,
                    name = townName
                }
            });
        }

        //POST /api/restaurants/{id}/rate
        [HttpPost]
        [Authorize]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult RateRestaurants(int id, RatingBindingModel m)
        {
            if (!this.Data.Restaurants.Any(r => r.Id == id))
                return this.NotFound();

            if (this.Data.Restaurants.FirstOrDefault(r => r.Id == id).OwnerId == User.Identity.GetUserId())
                return this.BadRequest("You can't rate your own resturant.");

            if (m.Stars > 10 || m.Stars <= 0)
                return this.BadRequest("Invalid value for stars.");

            var uId = User.Identity.GetUserId();

            if (this.Data.Ratings.Any(r => r.UserId == uId && r.RestaurantId == id))
            {
                var restaurant =
                    this.Data.Ratings.FirstOrDefault(
                        r => r.UserId == uId && r.RestaurantId == id);

                restaurant.Stars = m.Stars;

                this.Data.SaveChanges();

                return this.Ok();
            }

            var rating = new Rating
            {
                RestaurantId = id,
                UserId = uId,
                Stars = m.Stars
            };

            this.Data.Ratings.Add(rating);

            this.Data.SaveChanges();

            return this.Ok();
        }

        //GET /api/restaurants/{id}/meals
        [HttpGet]
        [Route("api/restaurants/{id}/meals")]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            if (!this.Data.Restaurants.Any(r => r.Id == id))
                return this.NotFound();

            var meals = this.Data.Meals.Where(m => m.RestaurantId == id)
                .Select(m => new MealsViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type =  m.Type.Name
                });

            return this.Ok(meals);
        }


    }
}