using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This is group 10 assignment 2
    /// Member name:
    /// 1. Truong Giang Nguyen
    /// 2. Ibrahim Ali
    /// 2. Ibrahim Ali
    /// 3. 
    /// 4. 
    /// <summary>
    public partial class MainWindow : Window
    {
        List<RestaurantItem> orders = new List<RestaurantItem>();

        public MainWindow()
        {
            InitializeComponent();

            foreach (RestaurantItem item in RestaurantItem.GetItems())
            {
                if (item.Category == "Beverage")
                {
                    comboBoxBeverage.Items.Add(item);
                }
                else if (item.Category == "Appetizer")
                {
                    comboBoxAppetizer.Items.Add(item);
                }
                else if (item.Category == "Main Course")
                {
                    comboBoxMainCourse.Items.Add(item);
                }
                else if (item.Category == "Dessert")
                {
                    comboBoxDessert.Items.Add(item);
                }
            }
        }

        private void ComboBoxBeverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxBeverage.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxBeverage.SelectedItem as RestaurantItem;

            int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));
            if (index == -1) // if not in the list
            {
                orders.Add(value);
            }
            else
            {
                RestaurantItem restaurantItem = orders[index];
                restaurantItem.qty++;
            }

            dataGrid.ItemsSource = orders;
            dataGrid.Items.Refresh();
        }

        private void ComboBoxMainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxMainCourse.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxMainCourse.SelectedItem as RestaurantItem;

            int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));
            if (index == -1) // if not in the list
            {
                orders.Add(value);
            }
            else
            {
                RestaurantItem restaurantItem = orders[index];
                restaurantItem.qty++;
            }

            dataGrid.ItemsSource = orders;
            dataGrid.Items.Refresh();
        }

        private void ComboBoxDessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxDessert.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxDessert.SelectedItem as RestaurantItem;

            int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));
            if (index == -1) // if not in the list
            {
                orders.Add(value);
            }
            else
            {
                RestaurantItem restaurantItem = orders[index];
                restaurantItem.qty++;
            }

            dataGrid.ItemsSource = orders;
            dataGrid.Items.Refresh();
        }

        private void ComboBoxAppetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxDessert.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxAppetizer.SelectedItem as RestaurantItem;

            int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));
            if (index == -1) // if not in the list
            {
                orders.Add(value);
            }
            else
            {
                RestaurantItem restaurantItem = orders[index];
                restaurantItem.qty++;
            }

            dataGrid.ItemsSource = orders;
            dataGrid.Items.Refresh();
        }

        /*private void updateList(List<RestaurantItem> orders, string item) 
        {
            int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(item)));
            if (index == -1) // if not in the list
            {
                RestaurantItem newItem = getItem(item);
                orders.Add(newItem);
            }
            else
            {
                RestaurantItem restaurantItem = orders[index];
                restaurantItem.qty++;
            }

            dataGrid.ItemsSource = orders;
            dataGrid.Items.Refresh();
        }

        private static RestaurantItem getItem(string name)
        {
            RestaurantItem restaurantItem = new RestaurantItem();

            foreach (RestaurantItem item in RestaurantItem.GetItems())
            {
                if (item.Name == name) {
                    restaurantItem = item;
                    break;
                }
                
            }
            return restaurantItem;
        }*/

        private void printBilBtn_Click(object sender, RoutedEventArgs e)
        {
            orders = RestaurantItem.GetItems();
            StringBuilder bill = new StringBuilder();
            Random rnd = new Random();
            int orderNumber = rnd.Next(10000, 50000);
            bill.AppendLine("Restaurant AWS - Bill Payment");
            bill.Append("-----------------------------------------------------");
            bill.AppendLine("-----------------------------------------------------");
            bill.AppendLine($"Order# {orderNumber}\n");

            string format = "{0,-35} {1,-10} {2,18} {3, 28}" + Environment.NewLine;
            bill.AppendFormat(format, "Item Name", "Category", "QTY", "Price");
            foreach (RestaurantItem item in orders)
            {
                bill.AppendLine(item.ToString());
            }

            bill.Append("-----------------------------------------------------");
            bill.AppendLine("-----------------------------------------------------");
            double subTotal = 120.99;
            double hst = subTotal * 0.13;
            double total = subTotal + hst;
            bill.AppendLine($"Subtotal {subTotal.ToString("C"),30}");
            bill.AppendLine($"H.S.T  {hst.ToString("C"),32}");
            bill.AppendLine($"Total   {total.ToString("C"),33}");
            bill.AppendLine($"\n{"",-35}{"AWS restaurant is happy to serve you.!"}");


            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream($"Order-{orderNumber}.pdf", FileMode.Create));
            doc.Open();
            Paragraph paragraph = new Paragraph(bill.ToString());
            doc.Add(paragraph);

            doc.Close();
        }
    }
}
