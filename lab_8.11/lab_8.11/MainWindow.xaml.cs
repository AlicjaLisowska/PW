
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
using System.Drawing;
using System.IO;
using System.Windows.Interop;
using System.Drawing.Imaging;

namespace lab_8._11
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int mirror = 1;
        OpenFileDialog openFileDialog;
        BitmapImage bmiPicture, orginalFile,beforeNegative,beforeColor;
        Bitmap bmPicture;
        bool onlyGreen = false;
        bool negative = false;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void plik_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                bmiPicture = new BitmapImage(fileUri);
                RotateTransform rotateTransform = img.LayoutTransform as RotateTransform;
                rotateTransform = new RotateTransform(0, 0, 0);
                img.LayoutTransform = rotateTransform;
                img.Source = bmiPicture;
                orginalFile = bmiPicture;
                
            }
        }
        //_________Mirror___Effect______
        private void lustrzane_Click(object sender, RoutedEventArgs e)
        {
            if (bmiPicture != null)
            {
                img.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();

                if (mirror == 1)
                {
                    flipTrans.ScaleX = -1;
                    mirror = -1;
                }
                else if (mirror == -1)
                {
                    flipTrans.ScaleX = 1;
                    mirror = 1;
                }
                img.RenderTransform = flipTrans;
            }
        }
        //___________________Rotate__________________
        private void obrót_Click(object sender, RoutedEventArgs e)
        {
            if (bmiPicture != null)
            {
                RotateTransform rotateTransform = img.LayoutTransform as RotateTransform;

                if (rotateTransform == null)
                {
                    if (mirror == -1)
                    {
                        rotateTransform = new RotateTransform(90, 0, 0);
                        img.LayoutTransform = rotateTransform;
                    }
                    else if (mirror == 1)
                    {
                        rotateTransform = new RotateTransform(0, 90, 0);
                        img.LayoutTransform = rotateTransform;
                    }
                }
                else if (mirror == -1)
                {
                    rotateTransform.Angle += 90;
                }
                else if (mirror == 1)
                {
                    rotateTransform.Angle += -90;
                }
                img.VerticalAlignment = VerticalAlignment.Top;
                img.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }

      
        //_________________________Negative____________________
        private void negatyw_Click(object sender, RoutedEventArgs e)
        {
             
            //new Bitmap
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                if (bmiPicture != null)
                {
                    enc.Frames.Add(BitmapFrame.Create(bmiPicture));
                    enc.Save(outStream);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                    bmPicture = new Bitmap(bitmap);
                }
            }

            if (bmPicture != null)
            {
               
                if (negative == false)
                {
                    beforeNegative = bmiPicture;
                    for (int y = 0; y < bmPicture.Height; y++)
                    {
                        for (int x = 0; x < bmPicture.Width; x++)
                        {
                            //get pixel value
                            System.Drawing.Color p = bmPicture.GetPixel(x, y);

                            //extract ARGB value from p
                            int a = p.A;
                            int r = p.R;
                            int g = p.G;
                            int b = p.B;

                            //find negative value
                            r = 255 - r;
                            g = 255 - g;
                            b = 255 - b;

                            //set new ARGB value in pixel
                            bmPicture.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b));
                        }
                    }
                    img.Source=bmiPicture= BitmapToBitmapImage();
                    negative = true;

                }
                else if (negative == true)
                {
                    img.Source =bmiPicture= beforeNegative;
                    negative= false;

                }
            }
        }




        //___________________Only__Green_____________
        private void zielony_Click(object sender, RoutedEventArgs e)
        {
            
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                if (bmiPicture != null)
                {
                    enc.Frames.Add(BitmapFrame.Create(bmiPicture));
                    enc.Save(outStream);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                    bmPicture = new Bitmap(bitmap);
                }
            }

            if (bmPicture != null)
            {        
                if (onlyGreen == false)
                {
                    beforeColor = bmiPicture;
                    for (int y = 0; y < bmPicture.Height; y++)
                    {
                        for (int x = 0; x < bmPicture.Width; x++)
                        {
                            //get pixel value
                            System.Drawing.Color p = bmPicture.GetPixel(x, y);

                            //extract ARGB value from p
                            int a = p.A;
                            int r = p.R;
                            int g = p.G;
                            int b = p.B;

                            //find negative value
                            if ((r < 50 && g < 150 && b < 50) || (r > 210 || b > 210))
                            {
                                r = 255;
                                g = 255;
                                b = 255;
                            }

                            //set new ARGB value in pixel
                            bmPicture.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b));
                        }
                    }

                    img.Source =bmiPicture= BitmapToBitmapImage();
                    onlyGreen = true;

                }
                else if (onlyGreen == true)
                {

                    img.Source = bmiPicture = beforeColor;
                    onlyGreen = false;
                }
            }

        }
        
      //_______Convert_Bitmap_to_BitmapImage_________
        private BitmapImage BitmapToBitmapImage()
        {
                BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream memory = new MemoryStream())
                {
                    bmPicture.Save(memory, ImageFormat.Png);
                    memory.Position = 0;
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
                return bitmapImage;            

        }
    }
}
