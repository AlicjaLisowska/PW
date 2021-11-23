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



namespace LAB03_WF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public int id;
        List<Row> items = new List<Row>();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void addNew_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1(this);
            newWindow.Show();
        }

        public void addRow(string n, string c)
        {
            id = items.Count + 1;
            items.Add(new Row() { Name = n, ID = id, Count = int.Parse(c) });
            Items.ItemsSource = items;
            Items.Items.Refresh();

        }


        public class Row
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Count { get; set; }
        }

        public bool IsNonCloseButtonClicked;
        private void buttonCloseTheApp_Click(object sender, RoutedEventArgs e)
        {
            IsNonCloseButtonClicked = true;
            this.Close(); // this will trigger the Closing () event method
        }






        private void saveSCV_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Row>));
            SaveFileDialog saveFile;

            SaveFileDialog sFile = new SaveFileDialog();
            if (sFile.ShowDialog() == true)
            {

                TextWriter txtWriter = new StreamWriter(sFile.FileName + ".xml");

                xs.Serialize(txtWriter, items);

                txtWriter.Close();
            }
        }


        private void open_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                items.Clear();
                XmlSerializer xs = new XmlSerializer(typeof(List<Row>));
                Stream s = File.OpenRead(openFile.FileName);
                items = (List<Row>)xs.Deserialize(s);
                Items.ItemsSource = items;
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            items.Clear();
            Items.ItemsSource = items;
            Items.Items.Refresh();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {

            string messageBoxText = "Do you want to save changes?";
            string caption = "Save File";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                saveSCV_Click(sender, e);
                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                this.Close();

            }


        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            int tmpInt;
            List<Row> tmp = new List<Row>();
            string text = textSearch.Text;
            bool check = Int32.TryParse(text, out tmpInt);

            foreach (Row line in items)
            {
                if (check)
                {
                    if (line.Count == Int32.Parse(text))
                    {
                        tmp.Add(line);
                        Items.ItemsSource = tmp;
                        Items.Items.Refresh();

                    }
                }
                else
                {
                    if (line.Name == text)
                    {
                        tmp.Add(line);
                        textSearch.Text = Int32.Parse(text).ToString();
                        Items.ItemsSource = tmp;
                        Items.Items.Refresh();
                    }
                }


            }

        }
        private void Dialog_Closing(object sender,
    System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want save changes?",
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else if (result == MessageBoxResult.Yes)
            {
                savecsv.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    

    }

}
