using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex01_EDA.OrderObject;


namespace Ex01_EDA
{
    internal class ItemCatalog
    {
        public static List<OrderObject.Item> ItemCatalogList = new List<OrderObject.Item>
        {       
            new OrderObject.Item { ItemId = "ABCD", Quantity = 1, Price = 24},
            new OrderObject.Item { ItemId = "AEFG", Quantity = 1, Price = 1},
            new OrderObject.Item { ItemId = "AHIJ", Quantity = 1, Price = 5},
            new OrderObject.Item { ItemId = "AKLM", Quantity = 1, Price = 10},
            new OrderObject.Item { ItemId = "ANOP", Quantity = 1, Price = 14}
        };





    }
}
