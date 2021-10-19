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
    /// Logika interakcji dla klasy Silnik.xaml
    /// </summary>
    public partial class Silnik : Window
    {
        int cenaSilnik;
        int aktualny = 0;
        MainWindow mainwindow;
        public Silnik(MainWindow mainwindow)
        {
            this.mainwindow = mainwindow;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.sumaSilnik = cenaSilnik;
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cenaSilnik = 10000;
            cena.Content = cenaSilnik;
            aktualny = 0;
            moc.SelectedIndex = -1;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            cenaSilnik = 6000;
            cena.Content = cenaSilnik;
            aktualny = 0;
            moc.SelectedIndex = -1;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            cenaSilnik = 17000;
            cena.Content = cenaSilnik;
            aktualny = 0;
            moc.SelectedIndex = -1;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            cenaSilnik = 34000;
            cena.Content = cenaSilnik;
            aktualny = 0;
            moc.SelectedIndex = -1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            if (moc.SelectedIndex == 0)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 2000;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 2000;
                }
                aktualny = 2000;
                cena.Content = cenaSilnik;  
            }
            if (moc.SelectedIndex == 1)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 3500;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 3500;
                }
                aktualny = 3500;
                cena.Content = cenaSilnik;
            }
            if (moc.SelectedIndex ==2)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 4500;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 4500;
                }
                aktualny = 4500;
                cena.Content = cenaSilnik;
            }
            if (moc.SelectedIndex == 3)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 6500;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 6500;
                }
                aktualny = 6500;
                cena.Content = cenaSilnik;
            }
            if (moc.SelectedIndex == 3)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 8000;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 8000;
                }
                aktualny = 8000;
                cena.Content = cenaSilnik;
            }
            if (moc.SelectedIndex == 4)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 11000;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 11000;
                }
                aktualny = 11000;
                cena.Content = cenaSilnik;
            }
            if (moc.SelectedIndex == 5)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 13500;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 13500;
                }
                aktualny =13500;
                cena.Content = cenaSilnik;
            }
            if (moc.SelectedIndex == 6)
            {
                if (aktualny == 0)
                {
                    cenaSilnik += 15000;
                }
                else
                {
                    cenaSilnik -= aktualny;
                    cenaSilnik += 15000;
                }
                aktualny = 15000;
                cena.Content = cenaSilnik;
            }

        }
    }
}
