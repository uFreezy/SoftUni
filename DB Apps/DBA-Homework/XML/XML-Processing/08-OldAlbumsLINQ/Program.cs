using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _08_OldAlbumsLINQ
{
    class Program
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            var oldAlbums =
                from album in doc.Descendants("album") select new
            {
                Title = album.FirstAttribute.Value,
                Price = album.Descendants("price").Attributes().First().Value
            };

            foreach (var album in oldAlbums)
            {
                Console.WriteLine("Title: {0}\nPrice: {1}\n", album.Title, album.Price);    
            }

        }
    }
}
