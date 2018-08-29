using System.Collections.Generic;
using System.IO;
using System.Linq;
using Orders.Models;

namespace Orders
{
    public class DataMapper
    {
        private readonly string _categoriesFileName;
        private readonly string _ordersFileName;
        private readonly string _productsFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            _categoriesFileName = categoriesFileName;
            _productsFileName = productsFileName;
            _ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this("../../Data/categories.txt", "../../Data/products.txt", "../../Data/orders.txt")
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = ReadFileLines(_categoriesFileName, true)
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });

            return categories;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = ReadFileLines(_productsFileName, true)
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4])
                });

            return products;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = ReadFileLines(_ordersFileName, true)
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3])
                });

            return orders;
        }

        private List<string> ReadFileLines(string fileName, bool hasHeader)
        {
            var allLines = new List<string>();

            using (var reader = new StreamReader(fileName))
            {
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}