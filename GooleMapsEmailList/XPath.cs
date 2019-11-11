using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GooleMapsEmailList
{
    static class XPath
    {
        public static string ListItem = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[4]/div[1]/div[41]";
        public static string ListItemCrop = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[4]/div[1]/div[";
        public static string Name = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[2]/div[1]/div[1]/h1";
        public static string Adress = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[8]/div/div[1]";
        public static string Coordinates = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[9]/div/div[1]";
        public static string WebPage = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[10]/div/div[1]";
        public static string PhoneNumber = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[11]/div/div[1]";
        public static string Misc = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[12]/div[1]";
        public static string BasicElementStart = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/div[";
        public static string BasicElementEnd = "]/div[1]";
        public static string BackButton = "/html/body/jsl/div[3]/div[9]/div[9]/div/div[1]/div/div/button";

    }
}
