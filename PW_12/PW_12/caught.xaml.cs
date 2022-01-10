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
using System.Threading;
namespace PW_12
{
    /// <summary>
    /// Logika interakcji dla klasy caught.xaml
    /// </summary>
    public partial class caught : Window
    {
        MainWindow mainWindow = new MainWindow();
        public caught()
        {
            
            InitializeComponent();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
            mainWindow.Close();
        }
    }
}
