using System;
using System.Collections.Generic;
using System.Xml;

namespace _03_ExtractAllArtists
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            XmlNode Root = doc.DocumentElement;

            SortedSet<string> Authors = new SortedSet<string>();

            foreach (XmlNode albums in Root.ChildNodes)
            {
                Authors.Add(albums["artist"].Attributes["name"].Value);
            }

            foreach (var author in Authors)
            {
                Console.WriteLine(author);
            } 
           
        }
    }
}
