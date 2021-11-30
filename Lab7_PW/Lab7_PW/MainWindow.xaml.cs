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
            //load readers
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                items.Clear();
           
                XmlSerializer xs = new XmlSerializer(typeof(List<Row>));
                Stream s = File.OpenRead(openFile.FileName);
                items = (List<Row>)xs.Deserialize(s);
                User.ItemsSource = items;

            }

            //Load books
            OpenFileDialog openFile2 = new OpenFileDialog();
            if (openFile2.ShowDialog() == true)
            {
                booksList.Clear();
                XmlSerializer bs = new XmlSerializer(typeof(List<Books>));
                Stream s2 = File.OpenRead(openFile2.FileName);
                booksList = (List<Books>)bs.Deserialize(s2);
                Book.ItemsSource = booksList;
            }
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
        private void Dialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want save changes?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = false;
            }
            else if (result == MessageBoxResult.Yes)
            {
               //save readers
                XmlSerializer xs = new XmlSerializer(typeof(List<Row>));
                SaveFileDialog sFile = new SaveFileDialog();
                if (sFile.ShowDialog() == true)
                {
                    TextWriter txtWriter = new StreamWriter(sFile.FileName + ".xml");
                    xs.Serialize(txtWriter, items);
                    txtWriter.Close();
                }
                //save books
                XmlSerializer bs = new XmlSerializer(typeof(List<Books>));
                SaveFileDialog sFile2 = new SaveFileDialog();
                if (sFile2.ShowDialog() == true)
                {
                    TextWriter txtWriter2 = new StreamWriter(sFile2.FileName + ".xml");
                    bs.Serialize(txtWriter2, booksList);
                    txtWriter2.Close();
                }
            }
        }
    }
}
