using System;
using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.Models.BindingModels
{
    public class ChannelMessagesBindingModel
    {
        [Required]
        public string Text { get; set; }
    }
}