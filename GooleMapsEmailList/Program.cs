using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace GooleMapsEmailList
{
    class Program
    {
        private static int id = 0;
        private static List<DataRow> dataForExcel = new List<DataRow>();
        private static Excel excel = new Excel(@"C:\Users\SinglePixelCircle\source\repos\GooleMapsEmailList\EmailList3.xlsx", 1);
        private static IWebDriver chromeDriver = new ChromeDriver();
        private static string SearchTag = "Pivnice Brno";
        private static int numberOfPages = 20;

        static void Main(string[] args)
        {

            InitializeSearch(SearchTag);

            for (int i = 0; i < numberOfPages; i++)
            {
                SearchPage(chromeDriver);
                SwitchThePage();

            }
            excel.SaveAs(@"C:\Users\SinglePixelCircle\source\repos\GooleMapsEmailList\PivniceBrno6.xlsx");
            excel.Close();
        }


        private static void SwitchThePage()
        {
            try
            {
                IWebElement nextPage = chromeDriver.FindElement(By.Id("n7lv7yjyC35__section-pagination-button-next"));
                nextPage.Click();
                Thread.Sleep(3000);
            }
            catch
            {
                Console.WriteLine("Element cant be foun on the page");
            }
        }

        private static void InitializeSearch(string searchTag)
        {

            chromeDriver.Navigate().GoToUrl("https://www.google.com/maps");

            //geting searchbar element on the page and finding key string
            IWebElement searchBar = chromeDriver.FindElement(By.Id("searchboxinput"));
            searchBar.Clear();
            searchBar.SendKeys(searchTag + Keys.Return);

            Thread.Sleep(20000);
            try
            {

                IWebElement dismissButton = chromeDriver.FindElement(By.XPath("/html/body/jsl/div[2]/div/div[2]/span/button[1]"));
                dismissButton.Click();
                Console.WriteLine("Dialog dissmised");
            }
            catch
            {
                Console.WriteLine("Unable to find dialog on the screen");

            }

            Thread.Sleep(1000 * 15);
            Console.Write("End of the sleep");

            //find elements for every object

        }

        private static void SearchPage(IWebDriver chromeDriver)
        {
            for (int i = 0; i < 42; i++)
            {
                if (i % 2 != 0)
                {
                    try
                    {
                        IWebElement listItem = chromeDriver.FindElement(By.XPath(XPath.ListItemCrop + i + "]"));
                        listItem.Click();
                        Thread.Sleep(5 * 1000);
                    }
                    catch
                    {
                        Console.WriteLine("Can not finnd elementl " + id + " on the screen");
                        continue;
                    }

                    LookForElemenst(chromeDriver);


                }



            }
        }

        private static void LookForElemenst(IWebDriver chromeDriver)
        {
            DataRow dataRow = new DataRow();
            dataRow.setId(id);

            string patternWebPage = @"[--z]+\.[A-z]{1,3}";
            Regex rgxWeb = new Regex(patternWebPage);

            string patternPhone = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$";
            Regex rgxPhone = new Regex(patternPhone);

            string patternAdress = @".+[/-9]{1,10}, [0-9]{3} [0-9]{2}.+";
            Regex rgxAdress = new Regex(patternAdress);

            //Look for name
            try
            {
                IWebElement name = chromeDriver.FindElement(By.XPath(XPath.Name));
                dataRow.setName(name.Text);
                //dataTypeCheck(name.Text);

            }
            catch
            {
                Console.WriteLine("Element name not found");
            }

            for(int i = 7; i<14; i++)
            {
                try
                {
                    IWebElement basicElement = chromeDriver.FindElement(By.XPath(XPath.BasicElementStart + i + XPath.BasicElementEnd));
                    if (rgxWeb.IsMatch(basicElement.Text))
                    {
                        Console.WriteLine("String {0}  Matches Webpage Pattern", basicElement.Text);
                        dataRow.setWebPage(basicElement.Text);

                    }else if (rgxPhone.IsMatch(basicElement.Text))
                    {
                        Console.WriteLine("String {0}  Matches Phone Number Pattern", basicElement.Text);
                        dataRow.setPhoneNumber(basicElement.Text);
                    }else if (rgxAdress.IsMatch(basicElement.Text))
                    {
                        Console.WriteLine("String {0}  Matches Adress Pattern", basicElement.Text);
                        dataRow.setAdress(basicElement.Text);
                    } else if(dataRow.getCoordinates() == "null")
                    {
                        dataRow.setCoordinates(basicElement.Text);
                    }
                    else
                    {
                        dataRow.setMisc(basicElement.Text);
                    }
                }
                catch
                {
                    Console.WriteLine("Webpage don't contain given element");
                }

                

            }



            if (dataRow.ValidCheck())
            {
                excel.WriteToExcel(dataRow, id);
                dataRow.WriteData();
                id++;
            }

            try
            {

                if (chromeDriver.FindElement(By.XPath(XPath.Name)).Displayed)
                {
                    //chromeDriver.Navigate().Back();
                    IWebElement backButton = chromeDriver.FindElement(By.XPath(XPath.BackButton));
                    backButton.Click();
                    Thread.Sleep(5 * 1000);
                }

            }
            catch
            {
                Console.WriteLine("Wrong Window");
            }
        }

    }

}
