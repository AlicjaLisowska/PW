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

namespace Lab2_PW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public int sumaMarka ;
       public int sumaSilnik;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Marka_Click(object sender, RoutedEventArgs e)
        {
                Marka marka= new Marka(this);
                marka.Show();
        }

        private void Silnik_Click(object sender, RoutedEventArgs e)
        {
            Silnik silnik = new Silnik(this);
            silnik.Show();   
        }

        private void oblicz_Click(object sender, RoutedEventArgs e)
        {
            sumaCen.Content = sumaMarka + sumaSilnik;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sumaMarka = 0;
            sumaSilnik = 0;
            sumaCen.Content = 0;
        }
    }       
 }

