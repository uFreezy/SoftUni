using System;

namespace Twitter.MVC.Models
{
    public class NotificationsViewModel
    {
        public string Receiver { get; set; }

        public string Sender { get; set; }

        public DateTime PostedOn { get; set; }

        public string Content { get; set; }
    }
}