using System;
using System.Xml;

namespace _07_OldAlbums
{
    class Program
    {
        static void Main()
        {
             var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            var albumsList = doc.SelectNodes("/albums/album");

            foreach (XmlNode album in albumsList)
            {
                if (album.SelectNodes("year[@value <= " + (DateTime.Now.Year - 5) +"]").Count > 0)
                {
                    Console.WriteLine("Title: {0}\nPrice: {1}",
                        album.Attributes["name"].Value,
                        album.SelectSingleNode("price").Attributes["value"].Value);
                } 
            }
        }
    }
}
