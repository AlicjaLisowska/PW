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


namespace LAB03_WF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int id = 0;
        public MainWindow()
        {
            
            InitializeComponent();
        }

     

        private void addNew_Click(object sender, RoutedEventArgs e)
        {

             Window1 newWindow = new Window1(this);
            newWindow.Show();

        }
   
    }
    public class Row
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public int Count { get; set; }
    }
}
