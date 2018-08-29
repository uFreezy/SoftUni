﻿namespace BookShop.Services.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using BookShop.Models;

    public class AuthorBooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public decimal Price { get; set; }
        public int Copies { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual IEnumerable<string> Categories { get; set; }
    }
}