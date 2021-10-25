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

        private void saveSCV_Click(object sender, RoutedEventArgs e)
        {
            string save = "";
            foreach (Row el in items)
            {
                save += $"{el.Name},{el.ID},{el.Count}\n";
            }
            SaveFileDialog saveFile;

            SaveFileDialog saveFileCSV= new SaveFileDialog();
            if (saveFileCSV.ShowDialog()==true)
            {                
                File.WriteAllText(saveFileCSV.FileName+".csv", save);
            }
        }


        private void open_Click(object sender, RoutedEventArgs e)
        {            
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()== true)
            {
                items.Clear();
               foreach(string line in File.ReadLines(openFile.FileName))
                {
                    string[] args = line.Split(',');
                    addRow(args[0], args[2]);
                }
            }
           
        }
    }
}
