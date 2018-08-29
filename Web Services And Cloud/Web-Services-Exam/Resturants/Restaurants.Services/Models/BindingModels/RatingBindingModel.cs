using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.BindingModels
{
    public class RatingBindingModel
    {
         [Required]
         public int Stars { get; set; }
    }
}