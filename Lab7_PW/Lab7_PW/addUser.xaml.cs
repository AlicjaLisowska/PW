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

namespace Lab7_PW
{
    /// <summary>
    /// Logika interakcji dla klasy addUser.xaml
    /// </summary>
    public partial class addUser : Window
    {
        MainWindow mainwindow;

        public addUser(MainWindow mainwindow)
        {            
            this.mainwindow = mainwindow;
            InitializeComponent();
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.addRow(textboxName.Text, textboxSurname.Text);
            this.Close();
        }
    }
} 
