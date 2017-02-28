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

    }
}
