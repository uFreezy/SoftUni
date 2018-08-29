using System;

namespace News.Services.Models.BindingModels
{
    public class NewsBindingModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; } 
    }
}