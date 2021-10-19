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

namespace Lab2_PW
{
    /// <summary>
    /// Logika interakcji dla klasy Marka.xaml
    /// </summary>
    public partial class Marka : Window
    {
        
        int cenaMarka;
        int back = 0;
        int dodatki = 0;
        MainWindow mainwindow;
        public Marka(MainWindow mainwindow)
        {
            this.mainwindow = mainwindow;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.sumaMarka =cenaMarka+back+dodatki;
            this.Close();
         }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cenaMarka = 6500 ;
            cena.Content = cenaMarka+dodatki;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            cenaMarka = 12000;
            cena.Content = cenaMarka+dodatki;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            cenaMarka = 100000 ;
            cena.Content = cenaMarka+dodatki;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ElSzyb.IsChecked == true)
            {
                dodatki += 350;
                cena.Content = cenaMarka+dodatki;
            }
            if(ElSzyb.IsChecked==false)
            {
                dodatki += -350;
                cena.Content = cenaMarka+dodatki;
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (PodSiedz.IsChecked == true)
            {
               dodatki += 550;
                cena.Content = cenaMarka+dodatki;
            }
            if (PodSiedz.IsChecked == false)
            {
                dodatki += -550;
                cena.Content = cenaMarka+dodatki;
            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            if (Klima.IsChecked == true)
            {
                dodatki += 1350;
                cena.Content = cenaMarka+dodatki;
            }
            if (Klima.IsChecked == false)
            {
                dodatki+= -1350;
                cena.Content = cenaMarka+dodatki;
            }
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            if (ElLust.IsChecked == true)
            {
                dodatki += 1950;
                cena.Content = cenaMarka+dodatki;
            }
            if (ElLust.IsChecked == false)
            {
                dodatki += -1950;
                cena.Content = cenaMarka+dodatki;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (back == 0)
            {
                back = Int32.Parse(polisaCena.Text);
                cena.Content = cenaMarka + dodatki + back;
            }
        }

        private void cofnij_Click(object sender, RoutedEventArgs e)
        {
            if (back != 0)
            {
                cena.Content = cenaMarka+dodatki;   
                back = 0;
            }
        }
    }
}
