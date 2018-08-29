using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Category
    {
        private ICollection<Ad> ads;

        public Category()
        {
            ads = new HashSet<Ad>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads
        {
            get { return ads; }
            set { ads = value; }
        }
    }
}