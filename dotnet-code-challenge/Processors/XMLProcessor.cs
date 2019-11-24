using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using dotnet_code_challenge.Model;
using System.Web;
//using System.Xml;
using System.Reflection;
//using System.Xml.Linq;
using System.Xml.XPath;

namespace dotnet_code_challenge.Processors
{
    public class XMLProcessor
    {
        XPathDocument xmlDoc;
        XPathNavigator navigator;
        XPathNodeIterator xnlHNames;
        XPathNodeIterator xnlHPrices;
        //XmlNodeList xnlHNames;
        //XmlNodeList xnlHPrices;
        public XMLProcessor(string filename)
        {
            try
            {
                xmlDoc = new XPathDocument(Path.Combine(@"C:\Users\Manes\Desktop\BetEasy-Coding-Challenge\code-challenge\dotnet-code-challenge\FeedData", filename));
                navigator = xmlDoc.CreateNavigator();
                    //xmlDoc = XDocument.Load(
                //    Path.Combine(@"C:\Users\Manes\Desktop\BetEasy-Coding-Challenge\code-challenge\dotnet-code-challenge\FeedData", filename)
                //    );
            }
            catch(Exception ex)
            {
                throw new Exception("XML file not found");
            }
        }

        public List<Horse> Process()
        {
            List<Horse> horses = new List<Horse>();
            try
            {
                xnlHNames = navigator.Select("/meeting/races/race/horses");
                xnlHPrices = navigator.Select("/meeting/races/race/prices/price/horses");

                //horses = (from HNames in xnlHNames.Cast<XmlNode>()
                //                      join HPrices in xnlHPrices.Cast<XmlNode>()
                //                      on HNames.Attributes["number"].InnerText equals
                //                      HPrices.Attributes["number"].InnerText
                //                      select new Horse
                //                      {
                //                          Name = HNames.Attributes["name"].InnerText,
                //                          Price = HPrices.Attributes["Price"].InnerText
                //                      }).ToList();

                while (xnlHNames.MoveNext())
                {
                    horses.Add(new Horse { Name = xnlHNames.Current.GetAttribute("name", string.Empty) });
                }
                while (xnlHPrices.MoveNext())
                {
                    
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Unexpected XML format");
            }
            return horses;
        }
    }
}
