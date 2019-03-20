using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Project2
{
    class Program
    {
        const string QUERY = "//Reference[@RefCode = '{0}']";
        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode root,child, refNode;
            string[] codes = { "MWB", "CAR", "TRV" };

            xmlDocument.Load("..\\..\\InputDocument.xml");
            root = xmlDocument.DocumentElement;
            foreach (string code in codes)
            {
                refNode = root.SelectSingleNode(string.Format(QUERY, code));
                child = refNode.FirstChild;
                Console.WriteLine(child.InnerText);
            }
        }
    }
}
