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
    /// 3. 
    /// 4. 
    /// <summary>
    public partial class MainWindow : Window
    {
        List<RestaurantItem> orders = new List<RestaurantItem>();
        double subTotal = 0;
        double hst = 0;
        double total = 0;

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
                else
                {
                    comboBoxBeverage.Items.Add(item);
                    comboBoxAppetizer.Items.Add(item);
                    comboBoxMainCourse.Items.Add(item);
                    comboBoxDessert.Items.Add(item);
                }
            }

            this.dataGrid.CanUserAddRows = false;
            ReCalculate_total();
        }

        private void ReCalculate_total()
        {
            subTotal = 0;
            hst = 0;
            total = 0;
            foreach (RestaurantItem item in orders)
                subTotal += item.price;
            hst = subTotal * 0.13;
            total = subTotal + hst;

            SubTotalText.Content = subTotal;
            HSTText.Content = hst;
            TotalText.Content = total;
        }

        private void ComboBoxBeverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RestaurantItem value = comboBoxBeverage.SelectedItem as RestaurantItem;

            if (value.Name != null)
            {
                int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));

                if (index == -1) // if not in the list
                {
                    orders.Add(value);
                }
                else
                {
                    RestaurantItem restaurantItem = orders[index];
                    restaurantItem.Qty++;
                }
                dataGrid.ItemsSource = orders;
                dataGrid.Items.Refresh();

                ReCalculate_total();
            }

            this.comboBoxBeverage.SelectedIndex = 0;
        }

        private void ComboBoxMainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RestaurantItem value = comboBoxMainCourse.SelectedItem as RestaurantItem;

            if (value.Name != null)
            {
                int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));

                if (index == -1) // if not in the list
                {
                    orders.Add(value);
                }
                else
                {
                    RestaurantItem restaurantItem = orders[index];
                    restaurantItem.Qty++;
                }

                dataGrid.ItemsSource = orders;
                dataGrid.Items.Refresh();

                ReCalculate_total();
            }

            this.comboBoxMainCourse.SelectedIndex = 0;
        }

        private void ComboBoxDessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RestaurantItem value = comboBoxDessert.SelectedItem as RestaurantItem;

            if (value.Name != null)
            {
                int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));

                if (index == -1) // if not in the list
                {
                    orders.Add(value);
                }
                else
                {
                    RestaurantItem restaurantItem = orders[index];
                    restaurantItem.Qty++;
                }

                dataGrid.ItemsSource = orders;
                dataGrid.Items.Refresh();

                ReCalculate_total();
            }

            this.comboBoxDessert.SelectedIndex = 0;
        }

        private void ComboBoxAppetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RestaurantItem value = comboBoxAppetizer.SelectedItem as RestaurantItem;

            if (value.Name != null)
            {
                int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value.Name)));

                if (index == -1) // if not in the list
                {
                    orders.Add(value);
                }
                else
                {
                    RestaurantItem restaurantItem = orders[index];
                    restaurantItem.Qty++;
                }

                dataGrid.ItemsSource = orders;
                dataGrid.Items.Refresh();

                ReCalculate_total();
            }

            this.comboBoxAppetizer.SelectedIndex = 0;
        }

        private void printBilBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder bill = new StringBuilder();
            Random rnd = new Random();
            int orderNumber = rnd.Next(10000, 50000);
            bill.AppendLine("Restaurant AWS - Bill Payment");
            bill.Append("-----------------------------------------------------");
            bill.AppendLine("-----------------------------------------------------");
            bill.AppendLine($"Order# {orderNumber}\n");

            string format = "{0,-35} {1,-10} {2,18} {3, 28}" + Environment.NewLine;
            bill.AppendFormat(format, "Item Name", "Category", "QTY", "Price");
            foreach (RestaurantItem item in this.orders)
            {
                bill.AppendLine(item.ToString());
            }

            bill.Append("-----------------------------------------------------");
            bill.AppendLine("-----------------------------------------------------");
            
            bill.AppendLine($"Subtotal {subTotal.ToString("C"),30}");
            bill.AppendLine($"H.S.T  {hst.ToString("C"),32}");
            bill.AppendLine($"Total   {total.ToString("C"),33}");
            bill.AppendLine($"\n{"",-35}{"AWS restaurant is happy to serve you.!"}");


            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Order-{orderNumber}.pdf");
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();
            Paragraph paragraph = new Paragraph(bill.ToString());
            doc.Add(paragraph);

            doc.Close();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            orders.Clear();
            dataGrid.ItemsSource = orders;
            dataGrid.Items.Refresh();
            ReCalculate_total();
        }
    }
}
