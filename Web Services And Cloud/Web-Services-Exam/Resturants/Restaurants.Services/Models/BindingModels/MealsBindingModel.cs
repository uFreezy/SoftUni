using System.ComponentModel.DataAnnotations;
using Restauranteur.Models;

namespace Restaurants.Services.Models.BindingModels
{
    public class MealsBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int RestaurantId{ get; set; }

        [Required]
        public int TypeId { get; set; }


        [Required]
        public decimal Price { get; set; }
    }
}