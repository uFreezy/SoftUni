using System;
using System.Runtime.Remoting.Channels;
using Messages.Data.Models;

namespace Messages.RestServices.Models.ViewModels
{
    public class ChannelMessagesViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime? DateSent { get; set; }

        public string Sender { get; set; }
        
    }
}