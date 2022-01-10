using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Diagnostics;


namespace PW_12
{
    /// <summary>
    /// Logika interakcji dla klasy Medium.xaml
    /// </summary>
    public partial class Medium : Window
    {

        List<Animal> animals = new List<Animal>();
        MainWindow mainWindow;
        caught caughtMedium = new caught();
        Die died = new Die();
        Wasted wasted = new Wasted();

        Stopwatch StopWatch = new Stopwatch();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        string currentTime = string.Empty;
        int clickNumber = 0;
        int animalIndex;

        public Medium(MainWindow mainwindow)
        {
            //Time
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            StopWatch.Start();
            dispatcherTimer.Start();
            //mainwindow
            this.mainWindow = mainwindow;
            animalIndex = mainwindow.selectedAnimal;

            InitializeComponent();

            animals.Add(new Animal() { name = "Kot", link = "https://ocdn.eu/pulscms-transforms/1/j-Gk9kqTURBXy84NWRjZTYzNzBiNTViZjcwYzA4YmNkMTk0OWFmODNkYi5qcGVnkZMFzQMgzQH0gaEwAQ", counter = 0 });
            animals.Add(new Animal() { name = "Ryba", link = "https://atlasryb.online/zdjecia/530_800.jpg", counter = 0 });
            animals.Add(new Animal() { name = "Mysz", link = "https://ocdn.eu/pulscms-transforms/1/cnSk9kpTURBXy8yNmNmNjUzNTAwYjU2MmVlZTUwMzViYjdjNDYxM2RiNS5qcGeTlQMAI80D6M0CMpMFzQMUzQG8kwmmZWM5YzcxBoGhMAE/mysz.jpg", counter = 0 });
            animals.Add(new Animal() { name = "Krokodyl", link = "https://image.ceneostatic.pl/data/products/97027801/i-fisher-price-muzyczny-krokodyl-ksylofon-cymbalki-22282.jpg", counter = 0 });
            mainwindow.animalName = animals[animalIndex].name;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button1);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button2);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button3);
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button5);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button6);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button7);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button8);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button9);
        }
        private void button10_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button10);
        }
        private void button11_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button11);
        }
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button12);
        }
        private void button13_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button13);
        }
        private void button14_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button14);
        }
        private void button15_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button15);
        }
        private void button16_Click(object sender, RoutedEventArgs e)
        {
            randomAnimal(button16);
        }

        void randomAnimal(Button but)
        {
            Random rnd = new Random();
            int randomNuber = rnd.Next(1, 6);

            if (animals[animalIndex].counter == 1 || randomNuber != 1)
            {
                but.Background = Brushes.White;
            }
            else if (randomNuber == 1 || (clickNumber == 15 && animals[animalIndex].counter == 0))
            {
                StopWatch.Stop();

                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(animals[animalIndex].link));
                but.Background = brush;

                animals[animalIndex].counter += 1;
                clickNumber += 1;

                if (animalIndex != 3)
                {
                    caughtMedium.Show();
                    caughtMedium.caughtText.Text = "You caught " + mainWindow.animalName;
                }
                else
                {
                    int winOrLose = rnd.Next(0, 2);

                    if (winOrLose == 1)
                    {
                        caughtMedium.Show();
                        caughtMedium.caughtText.Text = "You caught " + mainWindow.animalName;
                    }
                    else
                        died.Show();
                }
            }
        }
        public class Animal
        {
            public string name;
            public string link;
            public int counter;
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (StopWatch.IsRunning)
            {
                TimeSpan TimeS = StopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                TimeS.Minutes, TimeS.Seconds, TimeS.Milliseconds / 10);
                timerM.Text = currentTime;

                TimeSpan maxTime = new TimeSpan(0, 0, 3);
                if (String.Compare(currentTime, "00:03:00") == 1)
                {
                    StopWatch.Stop();
                    wasted.Show();
                    this.Close();
                }
            }
        }
    }
}



