using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static Ex01_EDA.OrderObject;

namespace Ex01_EDA
{
    internal class OrderObject
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string OrderDate { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public int TotalAmount { get; set; }

        public int NumOfItems { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }

        private static readonly Random rnd = new Random();

        public List<string> CurrencyTypes = new List<string> { "Dollar", "NIS", "Pound", "JPN YEN", "YUAN" };
        public List<string> StatusTypes = new List<string> { "In cart", "Proceed Payment", "Shipped", "Error" };

        public OrderObject(string orderId,int numOfItems)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("OrderId cannot be empty");
            if (numOfItems <= 0)
                throw new ArgumentException("NumOfItems must be greater than 0");

            OrderId = orderId;
            NumOfItems = numOfItems;
            InitializeOrderData();
        }


        public void AddItem(OrderObject order, string itemId, int quantity, double price)
        {
            Item ItemToAdd = new Item{ ItemId = itemId,Quantity = quantity, Price = price };
            order.Items.Add(ItemToAdd);

        }

        public void ModifyItemQuantity(OrderObject order, string itemId, int quantity)
        {
            int index = Items.FindIndex(i => i.ItemId == itemId);
            if (index == -1) return;

            Item itemToModify = Items[index];
            itemToModify.Quantity = quantity;

            if (itemToModify.Quantity <= 0)
            {
                Items.RemoveAt(index);
            }
            else
            {
                Items[index] = itemToModify;
            }

            TotalAmount = Items.Sum(i => (int)(i.Quantity * i.Price));
        }

        private void InitializeOrderData()
        {
            CustomerId = "ABCD" + OrderId.ToString();
            OrderDate = DateTime.UtcNow.ToString("o");
            int Currencyindex = rnd.Next(0, CurrencyTypes.Count);
            Currency = CurrencyTypes[Currencyindex];

            for (int i = 0; i < NumOfItems; i++)
            {

                int ItemIndex = rnd.Next(0, ItemCatalog.ItemCatalogList.Count);
                var selectedItem = ItemCatalog.ItemCatalogList[ItemIndex];
                var existingItem = Items.FirstOrDefault(it => it.ItemId == selectedItem.ItemId);

                if (existingItem != null)
                {

                    existingItem.Quantity += 1;

                }
                else
                {
                    Items.Add(new OrderObject.Item
                    {
                        ItemId = selectedItem.ItemId,
                        Price = selectedItem.Price,
                        Quantity = 1
                    });

                }

            }

            TotalAmount = Items.Sum(i => (int)(i.Quantity * i.Price));
            Status = StatusTypes[0];
        }
  



        public class Item
        {
            public string ItemId { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}
