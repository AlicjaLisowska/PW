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

namespace PW8
{
    /// <summary>
    /// Logika interakcji dla klasy Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        MainWindow mainwindow;
        public Details()
        {
            this.mainwindow = mainwindow;
            InitializeComponent();
            
            
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
