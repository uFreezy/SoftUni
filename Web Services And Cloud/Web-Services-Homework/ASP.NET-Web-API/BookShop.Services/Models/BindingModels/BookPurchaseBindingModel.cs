namespace BookShop.Services.Models.BindingModels
{
    using System;

    public class BookPurchaseBindingModel
    {
        public string User { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public bool IsRecalled { get; set; }
    }
}