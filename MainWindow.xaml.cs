using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This is group 10 assignment 2
    /// Member name:
    /// 1. Truong Giang Nguyen
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> list = new ObservableCollection<string>();
        List<RestaurantItem> orders = new List<RestaurantItem>();

        public MainWindow()
        {
            InitializeComponent();

            //dataGrid.SetBinding(orders);
            //orders = RestaurantItem.GetItems();
            //dataGrid.ItemsSource = orders;


            foreach (RestaurantItem item in RestaurantItem.GetItems())
            {
                if (item.Category == "Beverage")
                {
                    comboBoxBeverage.Items.Add(item.Name);
                }
                else if (item.Category == "Appetizer")
                {
                    comboBoxAppetizer.Items.Add(item.Name);
                }
                else if (item.Category == "Main Course")
                {
                    comboBoxMainCourse.Items.Add(item.Name);
                }
                else if (item.Category == "Dessert")
                {
                    comboBoxDessert.Items.Add(item.Name);
                }
            }

            //comboBoxBeverage.SelectedIndex = 0;
            //comboBoxAppetizer.SelectedIndex = 0;
            //comboBoxMainCourse.SelectedIndex = 0;
            //comboBoxDessert.SelectedIndex = 0;

        }

        private void ComboBoxBeverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox typeItem = (ComboBox)comboBoxBeverage.SelectedItem;
            //ComboBoxItem typeItem = ((ComboBoxItem)comboBoxBeverage.SelectedItem).Content.ToString();
            //string value = (comboBoxBeverage.SelectedItem).ToString();//comboBoxBeverage.Text;//typeItem.Text;
            string value = comboBoxBeverage.SelectedItem as string;

            updateList(this.orders, value);
            //RestaurantItem restaurantItem = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value)));
            //int index = orders.IndexOf(orders.Find(orderItem => orderItem.Name.Contains(value)));

            //RestaurantItem restaurantItem = orders[index];
            //restaurantItem.qty++;

            //dataGrid.Items.Refresh();
            MessageBox.Show("event trigger");
            //MessageBox.Show($"{value}, index {index}, quantity {orders[index].qty}");
        }

        private void ComboBoxMainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedValue = ((ComboBoxItem)comboBoxMainCourse.SelectedItem).Content.ToString();
            //list.Add(selectedValue);
            //dataGrid.ItemsSource = list;
        }

        private void ComboBoxDessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //var selectedValue = ((ComboBoxItem)comboBoxDessert.SelectedItem).Content.ToString();
            //list.Add(selectedValue);
            //dataGrid.ItemsSource = list;
        }

        private void ComboBoxAppetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedValue = ((ComboBoxItem)comboBoxAppetizer.SelectedItem).Content.ToString();
            //list.Add(selectedValue);
            //dataGrid.ItemsSource = list;
        }

        private void updateList(List<RestaurantItem> orders, string item) 
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
            //MessageBox.
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


            /*switch (name)
            {
                case "Soda":
                    restaurantItem = new RestaurantItem("Soda", "Beverage", 1.95);
                    return restaurantItem;
                case "Tea":
                    restaurantItem = new RestaurantItem("Tea", "Beverage", 1.50);
                    return restaurantItem;
                case "Coffee":
                    restaurantItem = new RestaurantItem("Coffee", "Beverage", 1.25);
                    return restaurantItem;
                default:
                    return null;
            }*/

            

        }

    }
}
