using System;

namespace News.Services.Models.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}