using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Xml;


namespace Lab7_PW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int id;
        List<Row> items = new List<Row>();
        List<Books> booksList = new List<Books>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aUser_Click(object sender, RoutedEventArgs e)
        {
            addUser newWindow = new addUser(this);
            newWindow.Show();
        }

        //Readers
        public class Row
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int ID { get; set; }
        }
        //Books
        public class Books
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int ID { get; set; }
            public string Status { get; set; }
        }
        public void addRow(string n, string s)
        {
            id = items.Count + 1;
            items.Add(new Row() { Name = n, Surname = s,ID = id });
            User.ItemsSource = items;
            User.Items.Refresh();

        }

        private void aBook_Click(object sender, RoutedEventArgs e)
        {
            addBook newWindowBook = new addBook(this);
            newWindowBook.Show();
        }
        
        public void addBook (string t, string a)
        {
            id = booksList.Count + 1;
            booksList.Add(new Books() { Title = t, Author=a, ID = id, Status="rental" });
            Book.ItemsSource = booksList;
            Book.Items.Refresh();
        }

        private void borrow_Click(object sender, RoutedEventArgs e)
        {
            int seleUser = User.SelectedIndex;
            int seleItem = Book.SelectedIndex;
            booksList[seleItem].Status = "Reader id: " + items[seleUser].ID.ToString();
            Book.ItemsSource = booksList;
            Book.Items.Refresh();
            Book.UnselectAll();
            User.UnselectAll();
        }

        private void gBack_Click(object sender, RoutedEventArgs e)
        {
            int seleItem = Book.SelectedIndex;
            booksList[seleItem].Status = "rental";
            Book.ItemsSource = booksList;
            Book.Items.Refresh();
            Book.UnselectAll();
            User.UnselectAll();
        }
    }
}
