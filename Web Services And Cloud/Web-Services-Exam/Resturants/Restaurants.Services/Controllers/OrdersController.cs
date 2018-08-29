using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Services.Controllers
{
    public class OrdersController : BaseApiController
    {
        //GET /api/orders?startPage={start-page}&limit={page-size}&mealId={mealId}
        [HttpGet]
        [Authorize]
        [Route("api/orders")]
        public IHttpActionResult ViewPendingOrders([FromUri]int startPage, [FromUri]int limit, [FromUri]int mealId)
        {
            var uId = User.Identity.GetUserId();
            var orders = this.Data.Orders.Where(m => m.MealId == mealId && m.UserId == uId);

            if (startPage == 0 && limit != 0)
            {
                var ordersToReturn = orders
                    .Take(limit)
                    .Select(o => new OrdersViewModel
                    {
                        Id = o.Id,
                        Meal = new MealsViewModel
                        {
                            Id = o.Meal.Id,
                            Name = o.Meal.Name,
                            Price = o.Meal.Price,
                            Type = o.Meal.Type.Name //TODO: Fix this.
                        },
                        Quantity = o.Quantity,
                        Status = o.OrderStatus,
                        CreatedOn = o.CreatedOn
                        
                    });

                return this.Ok(ordersToReturn);
            }

            if (limit == 0)
            {
                return this.Ok();
            }

            var ordersToReturnSkip = orders.OrderBy(o => o.Id)
                .Skip(startPage * limit)
                .Select(o => new OrdersViewModel
                {
                    Id = o.Id,
                    Meal = new MealsViewModel
                    {
                        Id = o.Meal.Id,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name //TODO: Fix this.
                    },
                    Quantity = o.Quantity,
                    Status = o.OrderStatus,
                    CreatedOn = o.CreatedOn

                });

            return this.Ok(ordersToReturnSkip);
        }

    }
}
