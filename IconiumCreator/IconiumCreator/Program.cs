using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using IconiumUtils;

namespace IconiumCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputXML = @"C:\\RibbonRoot.xml";

            try
            {
                IconiumUtils.Utils.LoadCUI(inputXML);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            

        }

 /*       public static void LoadCUI(string inputFile)

        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(inputFile);
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("RibbonTabSource");

            foreach (XmlNode node in nodes)

            {
                XmlNode tempNode = null;
                tempNode = node.SelectSingleNode("Name");

                try
                {
                    string Text = node.Attributes.GetNamedItem("Text").Value;
                    Console.WriteLine("Name = " + Text);

                    string Innertext = tempNode.InnerText;
                    Console.WriteLine("Innertext = " + Innertext);


                    int count = node.ChildNodes.Count;

                    XmlNodeList Panelnodes = node.ChildNodes;


                    foreach (XmlNode PanelNode in Panelnodes)
                    {

                        string PanelNodename = PanelNode.Name;

                        if (PanelNodename == "RibbonPanelSourceReference")
                        {
                            string PanelId = PanelNode.Attributes.GetNamedItem("PanelId").Value;
                            if (!string.IsNullOrEmpty(PanelId))
                            {
                                Console.WriteLine("PanelId = " + PanelId);
                                //string PanelName = FindPanelName(PanelId);
                                string text1=FindFindButton(PanelId);
                                //Console.WriteLine("PanelName = " + PanelName);


                            }

                        }

                        // string PanelId = PanelNode.Attributes.GetNamedItem("PanelId").Value;
                        // if (!string.IsNullOrEmpty(PanelId))                         
                        //   Console.WriteLine("PanelId = " + PanelId);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (tempNode != null)
                {


                }
            }

        }

        public static string FindPanelName(string PanelId)
        {

            // get the panel name from RibbonPanelSourceCollection
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\\RibbonRoot.xml");
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("RibbonPanelSource");
            string PanelName = null;

            foreach (XmlNode PanelSourceNode in nodes)
            {
                string UID = PanelSourceNode.Attributes.GetNamedItem("UID").Value;
                if (UID == PanelId)
                {
                    PanelName = PanelSourceNode.Attributes.GetNamedItem("Text").Value;
                    break;
                }
            }

            return PanelName;

        }

        public static string FindFindButton(string PanelId)
        {

            // get the panel name from RibbonPanelSourceCollection
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\\RibbonRoot.xml");
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("RibbonPanelSource");
            string PanelName = null;

            foreach (XmlNode PanelSourceNode in nodes)
            {
                string UID = PanelSourceNode.Attributes.GetNamedItem("UID").Value;
                if (UID == PanelId)
                {
                    foreach (XmlNode childnode in PanelSourceNode.ChildNodes)
                    {
                        FindRibbonRow(childnode);
                    }

                    //PanelName = PanelSourceNode.Attributes.GetNamedItem("Text").Value;
                    break;
                }
            }

            return PanelName;

        }
        public static string FindRibbonRow(XmlNode parentnode)
        {
            // get the panel name from RibbonPanelSourceCollection
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\\RibbonRoot.xml");
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;



            //XmlNodeList nodes = xmlDoc.GetElementsByTagName(parentnode);
            if (parentnode.ChildNodes.Count == 0)
            {
                return null;
            }

            if (parentnode.Name == "RibbonCommandButton")
            {
                string MenuMacroID = parentnode.Attributes.GetNamedItem("MenuMacroID").Value;
                string MyText = parentnode.Attributes.GetNamedItem("Text").Value;

                Console.WriteLine("MenuMacroID = " + MenuMacroID);
                // string PanelName = FindPanelName(PanelId);
                Console.WriteLine("MyText = " + MyText);
                return MenuMacroID;

            }

            if (parentnode.ChildNodes.Count != 0)
            {
                XmlNodeList MoreChild = parentnode.ChildNodes;


                foreach (XmlNode clist in MoreChild)
                {

                    FindRibbonRow(clist);

                }
            }

            return null;
        }*/

    }


}
