using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class UserProfileBindingModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}