using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;

namespace Restaurants.Services.Controllers
{
    public class MealsController : BaseApiController
    {
        //POST /api/meals
        [HttpPost]
        [Authorize]
        [Route("api/meals")]
        public IHttpActionResult CreateMeals(MealsBindingModel m)
        {
            if (!ModelState.IsValid)
                return this.BadRequest();

            if (!this.Data.Restaurants.Any(r => r.Id == m.RestaurantId)) //!!!
                return this.BadRequest();

            var uId = User.Identity.GetUserId();

            if (this.Data.Restaurants.FirstOrDefault(r => r.Id == m.RestaurantId).OwnerId != uId)
                return this.Unauthorized();

            var meal = new Meal
            {
                Name = m.Name,
                RestaurantId = m.RestaurantId,
                Price = m.Price,
                TypeId = m.TypeId,
                Type = this.Data.MealTypes.FirstOrDefault(mt => mt.Id == m.TypeId) // for some reason it doesnt set itself.
            };

            this.Data.Meals.Add(meal);

            this.Data.SaveChanges();

            return this.Created("http://localhost:1337/api/meals/" + meal.Id, new
            {
                meal.Name,
                meal.RestaurantId,
                meal.Price,
                Type = meal.Type.Name
            });
        }

        //PUT /api/meals/{id}
        [HttpPut]
        [Authorize]
        [Route("api/meals/{id}")]
        public IHttpActionResult EditMeals(int id, EditMealsBindingModel m)
        {
            if (!this.Data.Meals.Any(me => me.Id == id))
                return this.NotFound();

            var uId = User.Identity.GetUserId();

            var ownerId = this.Data.Restaurants
                .FirstOrDefault(r => r.Id == this.Data.Meals
                    .FirstOrDefault(me => me.Id == id).RestaurantId).OwnerId;

            if (ownerId != uId)
                return this.Unauthorized();

            if (!ModelState.IsValid || !this.Data.MealTypes.Any(mt => mt.Id == m.TypeId) || m.Price < 0)
                return this.BadRequest();

            var meal = this.Data.Meals.FirstOrDefault(me => me.Id == id);

            meal.Name = m.Name;
            meal.Price = m.Price;
            meal.TypeId = m.TypeId;

            this.Data.SaveChanges();

            //Okay, this confused me a little bit. In the first file it was asked 
            //to include location here. In the updated version it wasnt. So i didn't include it.
            return this.Ok(new
            {
                meal.Id,
                meal.Name,
                meal.Price,
                Type = meal.Type.Name
            }); 
        }

        //DELETE /api/meals/{id}
        [HttpDelete]
        [Authorize]
        [Route("api/meals/{id}")]
        public IHttpActionResult DeleteMeals(int id)
        {
            if (!this.Data.Meals.Any(m => m.Id == id))
                return this.NotFound();

            var uId = User.Identity.GetUserId();

            var ownerId = this.Data.Restaurants
               .FirstOrDefault(r => r.Id == this.Data.Meals
                   .FirstOrDefault(me => me.Id == id).RestaurantId).OwnerId;

            if (ownerId != uId)
                return this.Unauthorized();

            var meal = this.Data.Meals.Find(id);

            this.Data.Meals.Remove(meal);

            this.Data.SaveChanges();

            return this.Ok(new 
            {
                Message = string.Format("Meal #{0} deleted.", meal.Id)
            });
        }

        //POST /api/meals/{id}/order
        [HttpPost]
        [Authorize]
        [Route("api/meals/{id}/order")]
        public IHttpActionResult CreateOrders(int id, OrderBindingModel m)
        {
            if (User == null)
                return this.Unauthorized();

            if (!ModelState.IsValid)
                return this.BadRequest();

            if (!this.Data.Meals.Any(me => me.Id == id))
                return this.NotFound();

            var order = new Order
            {
                MealId = id,
                Quantity = m.Quantity,
                UserId = User.Identity.GetUserId(),
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Pending
            };

            this.Data.Orders.Add(order);

            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
