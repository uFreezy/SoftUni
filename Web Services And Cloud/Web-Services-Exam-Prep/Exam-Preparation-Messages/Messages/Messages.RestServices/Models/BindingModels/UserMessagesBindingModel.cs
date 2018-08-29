using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.Models.BindingModels
{
    public class UserMessagesBindingModel
    {
        [Required]
        public string Recipient { get; set; }
        
        [Required]
        public string Text { get; set; } 
    }
}