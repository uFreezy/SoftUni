using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.Models.BindingModels
{
    public class ChannelsBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}