using System;
using System.Xml;

namespace _06_DeleteAlbums
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlDocument outputDoc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            Console.WriteLine("Loaded XML document:");

            XmlNode Root = doc.DocumentElement;

            XmlDeclaration xmlDeclaration = outputDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = outputDoc.DocumentElement;
            outputDoc.InsertBefore(xmlDeclaration, root);

            XmlElement element1 = outputDoc.CreateElement(string.Empty, "albums", string.Empty);
            outputDoc.AppendChild(element1);

            foreach (XmlNode album in Root.ChildNodes)
            {
                if (int.Parse(album.ChildNodes[3].Attributes["value"].Value) > 20)
                {
                    XmlNode oNode = outputDoc.ImportNode(album, true);
                    outputDoc.DocumentElement.AppendChild(oNode);

                }
            }
            outputDoc.Save("../../../document.xml");

        }
    }
}
