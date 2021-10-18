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
        double cenaMarka = 0;
        public Marka()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena.Content = 6500 + "zł";
        }
    }
}
