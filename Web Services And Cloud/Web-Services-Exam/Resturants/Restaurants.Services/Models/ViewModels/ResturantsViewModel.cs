using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class ResturantsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public TownViewModel Town { get; set; }
        //[{"id":1,"name":"Sushi Heaven",
        //"rating":7,"town":
        //{"id":2,"name":"Sofia"}},...]

    }
}