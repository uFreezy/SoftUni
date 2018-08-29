using System;
using System.Collections.Generic;
using System.Xml;


namespace _05_XpathArtistsAndNumberOfAlbums
{
    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            var artistList = doc.SelectNodes("/albums/album/artist/@name");
            var albumsList = doc.SelectNodes("/albums/album");


            Dictionary<string, int> albumsPerArtist = new Dictionary<string, int>();

            foreach (XmlNode element in artistList)
            {
                albumsPerArtist.Add(element.Value, 0);

                foreach (XmlNode album in albumsList)
                {
                    if (album["artist"].Attributes["name"].Value == element.Value)
                    {
                        albumsPerArtist[element.Value]++;
                    }
                }
            }

            foreach (var entry in albumsPerArtist)
            {
                Console.WriteLine("Artist: {0}\nNumber Of Albums: {1}\n", entry.Key, entry.Value);
            }

        }
    }
}
