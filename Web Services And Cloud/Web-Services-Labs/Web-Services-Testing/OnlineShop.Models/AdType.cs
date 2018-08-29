using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class AdType
    {
        private ICollection<Ad> ads;

        public AdType()
        {
            ads = new HashSet<Ad>();
        }

        public int Id { get; set; }
        public int Index { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public virtual ICollection<Ad> Ads
        {
            get { return ads; }
            set { ads = value; }
        }
    }
}