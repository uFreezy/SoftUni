﻿using System;

namespace Messages.RestServices.Models.ViewModels
{
    public class UserMessagesViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string Sender { get; set; }
    }
}