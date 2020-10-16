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
                else
                {
                    comboBoxBeverage.Items.Add(item);
                    comboBoxAppetizer.Items.Add(item);
                    comboBoxMainCourse.Items.Add(item);
                    comboBoxDessert.Items.Add(item);
                }
            }

            this.dataGrid.CanUserAddRows = false;
        }

        private void ComboBoxBeverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxBeverage.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxBeverage.SelectedItem as RestaurantItem;

            if (comboBoxBeverage.SelectedIndex != 0)
            {
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

            this.comboBoxBeverage.SelectedIndex = 0;
        }

        private void ComboBoxMainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxMainCourse.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxMainCourse.SelectedItem as RestaurantItem;

            if (comboBoxMainCourse.SelectedIndex != 0)
            {
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

            this.comboBoxMainCourse.SelectedIndex = 0;
        }

        private void ComboBoxDessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxDessert.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxDessert.SelectedItem as RestaurantItem;

            if (comboBoxDessert.SelectedIndex != 0)
            {
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

            this.comboBoxDessert.SelectedIndex = 0;
        }

        private void ComboBoxAppetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = comboBoxAppetizer.SelectedItem as string;
            //updateList(this.orders, value);
            //MessageBox.Show("event trigger");

            RestaurantItem value = comboBoxAppetizer.SelectedItem as RestaurantItem;

            if (comboBoxAppetizer.SelectedIndex != 0)
            {
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

            this.comboBoxAppetizer.SelectedIndex = 0;
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

    }
}
