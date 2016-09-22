using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleSheep.Configuration
{
    public class Paths
    {
        public static string PathToProductsXml()
        {
            return @"H:\Nackademin\C#\v38\LittleSheep\LittleSheep\Database\products.xml";
        }

        public static string PathToUsersXml()
        {
            return @"H:\Nackademin\C#\v38\LittleSheep\LittleSheep\Database\users.xml";
        }

        public static string PathToOrdersXml()
        {
            return @"H:\Nackademin\C#\v38\LittleSheep\LittleSheep\Database\orders.xml";
        }

        public static string PathToExceptionLog()
        {
            return @"H:\Nackademin\C#\v38\LittleSheep\LittleSheep\Logs\exceptions.txt";
        }
    }
}