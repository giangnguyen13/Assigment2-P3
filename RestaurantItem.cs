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
        public double Price { get; }
        public int qty { get; set; } = 1;


        public RestaurantItem(){}

        public RestaurantItem(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        public static List<RestaurantItem> GetItems()
        {
            List<RestaurantItem> items = new List<RestaurantItem>();

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




            items.Add(new RestaurantItem("Turkey Club", "Main Course", 11.95));




            items.Add(new RestaurantItem("Apple Pie", "Dessert", 5.95));





            return items;

        }

        public override string ToString()
        {
            return $"{Name,-35} {Category,-10} {qty,20} {Price.ToString("C"),30}";
        }

        public string comboItemsNameAndPrice()
        {
            return $"{Name} - Price";
        }
    }
}
