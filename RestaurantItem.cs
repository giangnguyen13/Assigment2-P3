using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class RestaurantItem
    {
        public string Name { get; }
        public string Category { get; }

        protected double? _price;
        public int qty { get; set; } = 1;

        public string Price
        {
            get
            {
                return string.Format("{0:C}", _price.Value);
            }
        }

        public RestaurantItem(){}

        public RestaurantItem(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this._price = price;
        }

        public static List<RestaurantItem> GetItems()
        {
            List<RestaurantItem> items = new List<RestaurantItem>();
            items.Add(new RestaurantItem(null, null, 0));
       
            items.Add(new RestaurantItem("Soda", "Beverage", 1.95));
            items.Add(new RestaurantItem("Tea", "Beverage", 1.50));
            items.Add(new RestaurantItem("Coffee", "Beverage", 1.25));
            items.Add(new RestaurantItem("Mineral Water", "Beverage", 2.95));
            items.Add(new RestaurantItem("Juice", "Beverage", 2.50));
            items.Add(new RestaurantItem("Milk", "Beverage", 50));
            items.Add(new RestaurantItem("Buffalo Wings", "Appetizer", 5.95));
            items.Add(new RestaurantItem("Buffalo Fingers", "Appetizer", 6.95));
            items.Add(new RestaurantItem("Potato Skins", "Appetizer", 8.95));
            items.Add(new RestaurantItem("Nachos", "Appetizer", 6.95));
            items.Add(new RestaurantItem("Mushroom Caps", "Appetizer", 10.95));
            items.Add(new RestaurantItem("Shrimp Cocktail", "Appetizer", 12.95));
            items.Add(new RestaurantItem("Chips and Salsa", "Appetizer", 8.95));
            items.Add(new RestaurantItem("Seafodd Alfredo", "Main Course", 15.95));
            items.Add(new RestaurantItem("Chicken Alfredo", "Main Course", 13.95));
            items.Add(new RestaurantItem("Chicken Picatta", "Main Course", 13.95));
            items.Add(new RestaurantItem("Turkey Club", "Main Course", 11.95));
            items.Add(new RestaurantItem("Lobster Pie", "Main Course", 19.95));
            items.Add(new RestaurantItem("Prime Rib", "Main Course", 20.95));
            items.Add(new RestaurantItem("Shrimp Scampi", "Main Course", 18.95));
            items.Add(new RestaurantItem("Turkey Dinner", "Main Course", 13.95));
            items.Add(new RestaurantItem("Stuffed Chicken Picatta", "Main Course", 14.95));
            items.Add(new RestaurantItem("Chicken Picatta", "Main Course", 13.95));
            items.Add(new RestaurantItem("Apple Pie", "Dessert", 5.95));
            items.Add(new RestaurantItem("Sundae", "Dessert", 3.95));
            items.Add(new RestaurantItem("Carrot Cake", "Dessert", 5.95));
            items.Add(new RestaurantItem("Mud Pie", "Dessert", 4.95));
            items.Add(new RestaurantItem("Apple Crisp", "Dessert", 5.95));

            return items;
        }

        public string toString()
        {
            return $"Name: {Name} | Category: {Category} | Price: {_price} | Quantity: {qty}";
        }

        public string comboItemsNameAndPrice()
        {
            return $"{Name} - Price";
        }
    }
}
