using System;
using System.Xml;

namespace _02_ExtractAlbumNames
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            XmlNode Root = doc.DocumentElement;

            foreach (XmlNode node in Root.ChildNodes)
            {      
               Console.WriteLine("Album title = {0}", node.Attributes["name"].Value);   
            }
        }
    }
}
