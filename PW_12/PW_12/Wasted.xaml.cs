using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PW_12
{
    /// <summary>
    /// Logika interakcji dla klasy Wasted.xaml
    /// </summary>
    public partial class Wasted : Window
    {
        MainWindow mainWindow = new MainWindow();
        public Wasted()
        {
            InitializeComponent();
        }

        

        private void trAgain_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
      
    }
}
