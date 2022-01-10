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

namespace PW_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public int selectedAnimal;
        public string animalName="";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            selectedAnimal = animalCombo.SelectedIndex;
            if (level.SelectedIndex == 0)
            {
                Easy easy = new Easy(this);
                easy.Show();
                
            }
            if (level.SelectedIndex == 1)
            {
                Medium medium = new Medium(this);
                medium.Show();
               
            }
            if (level.SelectedIndex == 2)
            {
                Hard hard = new Hard(this);
                hard.Show();
                
            }
        }
    }
}
