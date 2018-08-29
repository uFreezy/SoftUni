using System;
using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class OrdersViewModel
    {
        public int Id { get; set; }

        public MealsViewModel Meal { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}