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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Marka_Click(object sender, RoutedEventArgs e)
        {
            
                Marka marka= new Marka();
                marka.Show();
                
            }

        private void Silnik_Click(object sender, RoutedEventArgs e)
        {
            Silnik silnik = new Silnik();
            silnik.Show();
           
        }
    }

       
 }

