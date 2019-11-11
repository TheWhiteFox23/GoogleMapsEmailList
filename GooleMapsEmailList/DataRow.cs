using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleMapsEmailList
{
    public class DataRow
    {
        int id;
        string name;
        string adress;
        string webPage;
        string phoneNumber;
        string misc;
        string coordinates;

        public DataRow(int id, string name, string adress, string webPage, string phoneNumber, string misc, string coordinates)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
            this.webPage = webPage;
            this.misc = misc;
            this.coordinates = coordinates;

        }

        public DataRow()
        {
            this.id = -1;
            this.name = "null";
            this.adress = "null";
            this.phoneNumber = "null";
            this.webPage = "null";
            this.misc = "null";
            this.coordinates = "null";

        }

        public int getId()
        {
            return id;
        }

        public void setId(int i)
        {
            this.id = i;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string s)
        {
            this.name = s;
        }

        public string getAdress()
        {
            return adress;
        }

        public void setAdress(string s)
        {
            this.adress = s;
        }

        public string getWebPage()
        {
            return webPage;
        }

        public void setWebPage(string s)
        {
            this.webPage = s;
        }

        public string getPhone()
        {
            return phoneNumber;
        }

        public void setPhoneNumber(string s)
        {
            this.phoneNumber = s;
        }

        public string getMisc()
        {
            return misc;
        }

        public void setMisc(string s)
        {
            this.misc = s;
        }

        public string getCoordinates()
        {
            return coordinates;
        }

        public void setCoordinates(string s)
        {
            this.coordinates = s;
        }

        public void WriteData()
        {
            Console.WriteLine("Record with ID: " + id + " contain");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Coordinates: " + coordinates);
            Console.WriteLine("Adress: " + adress);
            Console.WriteLine("WebPage: " + webPage);
            Console.WriteLine("Phone: " + phoneNumber);
            Console.WriteLine("Misc: " + misc);

        }

        public bool ValidCheck()
        {
            if ((name != "null") || (adress != "null") || (webPage != "null") || (phoneNumber != "null"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
