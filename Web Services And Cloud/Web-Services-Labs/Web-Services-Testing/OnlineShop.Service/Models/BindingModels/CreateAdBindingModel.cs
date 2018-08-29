using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace OnlineShop.Service.Models.BindingModels
{
    public class CreateAdBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [Range(1.0, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public IEnumerable<int> Categories { get; set; } 
    }
}