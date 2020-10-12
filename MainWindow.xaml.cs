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

        public MainWindow()
        {
            InitializeComponent();

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
            //var selectedValue = comboBoxBeverage.SelectedValuePath;  //((ComboBoxItem)comboBoxBeverage.SelectedItem).Content.ToString();
            //list.Add(selectedValue);
            //dataGrid.ItemsSource = selectedValue;
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

    }
}
