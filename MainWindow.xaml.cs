using System;
using System.Collections.Generic;
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
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createBillBtn_Click(object sender, RoutedEventArgs e)
        {
            //testInput.Text = "";
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream($"{testInput.Text}.pdf",FileMode.Create));
            doc.Open();
            Paragraph paragraph = new Paragraph("This is a paragraph.\nNew Line");
            doc.Add(paragraph);
            doc.Close();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            drinkCbx.SelectedItem = null;
            testInput.Text = "";
        }
    }
}
