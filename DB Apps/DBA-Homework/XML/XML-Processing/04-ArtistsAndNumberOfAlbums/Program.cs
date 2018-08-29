using System;
using System.Collections.Generic;
using System.Xml;

namespace _04_ArtistsAndNumberOfAlbums
{
    internal class Program
    {
        private static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            XmlNode Root = doc.DocumentElement;

            var artists = new HashSet<string>();

            foreach (XmlNode album in Root.ChildNodes)
            {
                artists.Add(album["artist"].Attributes["name"].Value);
            }

            var albumsPerArtist = new Dictionary<string, int>();

            foreach (var artist in artists)
            {
                albumsPerArtist.Add(artist, 0);
                foreach (XmlNode album in Root.ChildNodes)
                {
                    if (album["artist"].Attributes["name"].Value == artist)
                    {
                        albumsPerArtist[artist]++;
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