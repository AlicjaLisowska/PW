
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
using Microsoft.Win32;
//using System.Drawing;


namespace lab_8._11
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int mirror = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void plik_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                img.Source = new BitmapImage(fileUri);
            }
        }

        private void lustrzane_Click(object sender, RoutedEventArgs e)
        {
            img.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform flipTrans = new ScaleTransform();

            if (mirror == 1)
            {
                flipTrans.ScaleX = -1;
                mirror = -1;

            }
            else if (mirror==-1)
            {
                flipTrans.ScaleX = 1;
                mirror = 1;

            }
            img.RenderTransform = flipTrans;
            



        }

        private void obrót_Click(object sender, RoutedEventArgs e)
        {
            // Create a BitmapImage

            BitmapImage bmpImage = new BitmapImage();

            bmpImage.BeginInit();

            bmpImage.UriSource = new Uri(i);

            bmpImage.EndInit();



            // Properties must be set between BeginInit and EndInit

            transformBmp.BeginInit();

            transformBmp.Source = bmpImage;

            RotateTransform transform = new RotateTransform(90);

            transformBmp.Transform = transform;

            transformBmp.EndInit()
        }
    }
}
