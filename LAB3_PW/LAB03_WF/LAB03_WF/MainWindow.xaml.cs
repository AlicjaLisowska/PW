using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
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
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;           
            string lOpen = sAll.Get("LastOpen");
            if (lOpen!= "")
            {
                Stream str = File.OpenRead(lOpen);
                XmlSerializer xs = new XmlSerializer(typeof(List<Row>));
                items = (List<Row>)xs.Deserialize(str);
                Items.ItemsSource = items;
            }
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

                Stream s= File.OpenRead(openFile.FileName);
                items = (List<Row>)xs.Deserialize(s);
                Items.ItemsSource = items;
                
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                configuration.AppSettings.Settings["LastOpen"].Value = openFile.FileName;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            items.Clear();
            Items.ItemsSource = items;
            Items.Items.Refresh();
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
                        Items.ItemsSource = tmp;
                        Items.Items.Refresh();
                    }
                }
            }
        }

        //Save before close
        private void Dialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want save changes?","Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = false; 
            }
            else if (result == MessageBoxResult.Yes)
            {
                savecsv.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
