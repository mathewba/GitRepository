using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;



namespace IconiumUtils
{

    public class Utils
    {
        public static string GTabName = ""; // Tab Name
        public static string GPanelName = ""; // Panel Name
        public static int RowIndex = 2; // To update the nummber of rows
        public static string GButtonName = "";
        public static string GButtonDescription = "";
        public static string GIconName = "";
        public static string GTabID = "";


        public static Microsoft.Office.Interop.Excel._Application app;
        public static Microsoft.Office.Interop.Excel._Workbook workbook;
        public static Microsoft.Office.Interop.Excel._Worksheet worksheet;

        const string inputXML = @"C:\\RibbonRoot.xml"; // RibbinRoot.cui
        const string MenuXML = @"C:\\MenuGroup.xml"; // MenuGroup.cui combined for ACA and MEP
        const string ResourceXML = @"C:\\Resources.xml"; // Resource XML file with Resource.h entries mapped to Resource IDs
        const string WorkspaceXML = @"C:\\WorkspaceRoot.xml";


        public static void LoadCUI(string inputFile)

        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(inputFile);
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;

            // creating Excel Application
            int i = 1, j = 1;

            app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application 

            workbook = app.Workbooks.Add(Type.Missing);


            // creating new Excelsheet in workbook 

            worksheet = null;

            // see the excel sheet behind the program 

            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1. 

            // store its reference to worksheet 

            worksheet = workbook.Sheets["sheet1"];

            worksheet = workbook.ActiveSheet;

            // changing the column name of active sheet 

            worksheet.Name = "MEP Icons Data";
            worksheet.Cells[1, 1] = "Tab Name";
            worksheet.Cells[1, 2] = "Tab ID";
            worksheet.Cells[1, 3] = "Panel Name";
            worksheet.Cells[1, 4] = "Button Name";
            worksheet.Cells[1, 5] = "Button Description";
            worksheet.Cells[1, 6] = "Icon Name";
            worksheet.Cells[1, 7] = "Icon Type";

            // AddMenuBorder(1, 7);


            XmlNodeList nodes = xmlDoc.GetElementsByTagName("RibbonTabSource");

            foreach (XmlNode node in nodes)

            {
                XmlNode tempNode = null;
                tempNode = node.SelectSingleNode("Name");

                try
                {
                    string Text = node.Attributes.GetNamedItem("Text").Value;
                    string TABID = node.Attributes.GetNamedItem("UID").Value;
                    // Console.WriteLine("TabName = " + Text);
                    // WriteLog("Name = " + Text);
                    GTabName = Text;
                    GTabID = TABID;


                    string Innertext = tempNode.InnerText;
                    // Console.WriteLine("Innertext = " + Innertext);
                    // WriteLog("Innertext = " + Innertext);


                    XmlNodeList Panelnodes = node.ChildNodes;


                    foreach (XmlNode PanelNode in Panelnodes)
                    {

                        string PanelNodename = PanelNode.Name;

                        if (PanelNodename == "RibbonPanelSourceReference")
                        {
                            string PanelId = PanelNode.Attributes.GetNamedItem("PanelId").Value;
                            if (!string.IsNullOrEmpty(PanelId))
                            {
                                // Console.WriteLine("PanelId = " + PanelId);
                                // WriteLog("PanelId = " + PanelId);
                                string PanelName = FindPanelName(PanelId);

                                // Console.WriteLine("PanelName = " + PanelName);
                                // WriteLog("PanelName = " + PanelName);
                                GPanelName = PanelName;
                                string commandButton = FindFindButton(PanelId);



                            }

                        }

                        // string PanelId = PanelNode.Attributes.GetNamedItem("PanelId").Value;
                        // if (!string.IsNullOrEmpty(PanelId))                         
                        //   Console.WriteLine("PanelId = " + PanelId);
                    }


                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    WriteLog(ex.Message);
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
            xmlDoc.Load(inputXML);
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
            xmlDoc.Load(inputXML);
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
                        string MenuMacroID = FindRibbonRow(childnode);

                        // Find the Resource ID based on the Menu Macro ID
                        // LoadMenuXML(MenuMacroID);
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
            xmlDoc.Load(inputXML);
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

                // Console.WriteLine("MenuMacroID = " + MenuMacroID);
                // WriteLog("MenuMacroID = " + MenuMacroID);
                // ExportToExcel(MyText, 3);

                if (MyText != "" || MyText != string.Empty)
                    GButtonName = MyText;

                LoadMenuXML(MenuMacroID);
                // string PanelName = FindPanelName(PanelId);
                // Console.WriteLine("Button Name = " + MyText);
                // WriteLog("Button Name = " + MyText);
                //ExportToExcel(MyText, 3);                
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
        }

        public static void LoadMenuXML(string MenuMacroID)

        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(MenuXML);
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("MenuMacro");

            foreach (XmlNode node in nodes)

            {
                string UID = node.Attributes.GetNamedItem("UID").Value;

                if (UID == MenuMacroID)
                {
                    // We have found the Menu Macro ID
                    XmlNode macroNode = node.ChildNodes.Item(0);

                    XmlNode ResourceNode = macroNode.ChildNodes.Item(6);

                    string ResourceID = ResourceNode.Attributes.GetNamedItem("Name").Value;

                    XmlNode HelpStringNode = macroNode.ChildNodes.Item(4);
                    string HelpString = HelpStringNode.InnerText;

                    // WriteLog("ResourceID = " + ResourceID);
                    // WriteLog("HelpString = " + HelpString);


                    // Console.WriteLine("ResourceID = " + ResourceID);
                    // Console.WriteLine("HelpString = " + HelpString);
                    // ExportToExcel(HelpString, 4);
                    GButtonDescription = HelpString;

                    LoadResourceXML(ResourceID);

                }
                else
                {
                    // We have not found the Menu Macro ID


                    //WriteLog("ResourceID = " + ResourceID);
                    //WriteLog("HelpString = " + HelpString);
                    string ResourceID = "NA";
                    string HelpString = "NA";

                    // Console.WriteLine("ResourceID = " + ResourceID);
                    //ExportToExcel(HelpString, 5);
                    // Console.WriteLine("HelpString = " + HelpString);

                    // ExportToExcel(HelpString, 4);
                    GButtonDescription = HelpString;
                    LoadResourceXML(ResourceID);

                }
            }

        }


        public static void LoadResourceXML(string ResourceID)
        {
            // Open the resource XML and get the Menu details

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ResourceXML);
            string fileSource = string.Empty;
            string directory = string.Empty;
            string fileName = string.Empty;

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("resource");

            foreach (XmlNode node in nodes)
            {
                XmlNode ResourceIDNode = node.ChildNodes.Item(0);

                string ResourceIDTemp = ResourceIDNode.InnerText;

                if (ResourceIDTemp == ResourceID)
                {
                    XmlNode IconNode = node.ChildNodes.Item(1);
                    string iconName = IconNode.InnerText;

                    XmlNode IconType = node.ChildNodes.Item(2);
                    string iconType = IconType.InnerText;

                    // WriteLog("IconName = " + iconName);
                    // WriteLog("IconType = " + iconType);                  

                    // Console.WriteLine("IconName = " + iconName);
                    // ExportToExcel(iconName, 5);

                    GIconName = iconName;
                    ExportToExcel(iconType, 7);
                    break;

                }
                //else if (ResourceID == "NA")
                //{
                //    string iconName = "NA";
                //    string iconType = "NA";
                //    ExportToExcel(iconName, 5);
                //    ExportToExcel(iconType, 6);
                //    //break;

                //}
            }

        }


        public static void WriteLog(string LogMessage)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "C:\\Logs\\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(LogMessage);
            log.Close();
        }


        public static void ExportToExcel(string inputValue, int columnIndex)
        {

            worksheet.Cells[RowIndex, 1] = GTabName;
            AddBorder(RowIndex, 1);
            worksheet.Cells[RowIndex, 2] = GTabID;
            AddBorder(RowIndex, 2);
            worksheet.Cells[RowIndex, 3] = GPanelName;
            AddBorder(RowIndex, 3);
            worksheet.Cells[RowIndex, 4] = GButtonName;
            AddBorder(RowIndex, 4);
            worksheet.Cells[RowIndex, 5] = GButtonDescription;
            AddBorder(RowIndex, 5);
            worksheet.Cells[RowIndex, 6] = GIconName;
            AddBorder(RowIndex, 6);
            worksheet.Cells[RowIndex, columnIndex] = inputValue;
            AddBorder(RowIndex, columnIndex);
            if (columnIndex == 7) //6 is the index for last column that is Icon Type
            {
                RowIndex++;

            }


        }

        public static void AddBorder(int Row, int Column)
        {
            Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;
            Microsoft.Office.Interop.Excel.Range cell = range.Cells[Row, Column];
            Microsoft.Office.Interop.Excel.Borders border = cell.Borders;

            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

        }

        public static void AddMenuBorder(int Row, int Column)
        {
            Microsoft.Office.Interop.Excel.Range range = worksheet.Cells[Row, Column];
            Microsoft.Office.Interop.Excel.Range cell = range.Cells[Row, Column];
            Microsoft.Office.Interop.Excel.Borders border = cell.Borders;

            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 5d;


        }
    }



}

