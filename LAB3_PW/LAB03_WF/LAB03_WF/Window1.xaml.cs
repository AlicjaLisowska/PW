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
using System.Windows.Shapes;

namespace LAB03_WF
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainwindow;

      
        public Window1(MainWindow mainwindow)
        {
            
            this.mainwindow = mainwindow;
            InitializeComponent();
      
     
            
        }
       
         
        private void add_Click(object sender, RoutedEventArgs e)
        {
         mainwindow.id += 1;
            List<Row> items = new List<Row>();
            items.Add(new Row() { Name = nameTextbox.Text, ID =mainwindow.id, Count = int.Parse(countTextbox.Text) });
        
            mainwindow.Items.ItemsSource = items;
        
            this.Close();
        }
      
    }
}
