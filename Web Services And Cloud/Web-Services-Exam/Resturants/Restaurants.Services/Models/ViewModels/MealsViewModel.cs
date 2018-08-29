using Restauranteur.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class MealsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        //[{"id":3,"name":"Musaka","price":4.5,"type":"Main"}, 
    }
}