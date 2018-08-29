using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Orders
{
    internal class ProductsInfo
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var dataMapper = new DataMapper();
            var allCategories = dataMapper.GetAllCategories();
            var allProducts = dataMapper.GetAllProducts();
            var allOrders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            var mostExpensiveProducts = allProducts
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);

            Console.WriteLine(string.Join(Environment.NewLine, mostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var amountOfProductsPerCategory = allProducts
                .GroupBy(p => p.CategoryId)
                .Select(group => new
                {
                    Category = allCategories
                        .First(c => c.Id == group.Key).Name,
                    Count = group.Count()
                })
                .ToList();

            foreach (var amount in amountOfProductsPerCategory)
            {
                Console.WriteLine("{0}: {1}", amount.Category, amount.Count);
            }

            Console.WriteLine(new string('-', 10));


            // The 5 top products (by order Quantity)
            var topProducts = allOrders
                .GroupBy(o => o.ProductId)
                .Select(group => new
                {
                    Product = allProducts
                        .First(p => p.Id == group.Key).Name,
                    Quantities = group.Sum(g => g.Quantity)
                })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var product in topProducts)
            {
                Console.WriteLine("{0}: {1}", product.Product, product.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitableCategory = allOrders
                .GroupBy(o => o.ProductId)
                .Select(g => new
                {
                    allProducts
                        .First(p => p.Id == g.Key).CategoryId,
                    Price = allProducts
                        .First(p => p.Id == g.Key).UnitPrice,
                    Quantity = g.Sum(p => p.Quantity)
                })
                .GroupBy(g => g.CategoryId)
                .Select(group => new
                {
                    CategoryName = allCategories
                        .First(c => c.Id == group.Key).Name,
                    ToatalQuantity = group.Sum(g => g.Quantity*g.Price)
                })
                .OrderByDescending(g => g.ToatalQuantity)
                .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.CategoryName, mostProfitableCategory.ToatalQuantity);
        }
    }
}