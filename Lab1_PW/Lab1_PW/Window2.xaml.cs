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
using System.Diagnostics;
using System.Threading;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Lab1_PW
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Stopwatch StopWatch = new Stopwatch();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string currentTime = string.Empty;
        public Window2()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }
        void dt_Tick(object sender, EventArgs e)
        {
            if (StopWatch.IsRunning)
            {
                TimeSpan TimeS = StopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                TimeS.Minutes, TimeS.Seconds, TimeS.Milliseconds / 10);
                Czas_stoper.Content= currentTime;
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StopWatch.Start();
            dispatcherTimer.Start();

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (StopWatch.IsRunning)
            {
                StopWatch.Stop();
            }
            
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            StopWatch.Reset();
            Czas_stoper.Content = "00:00:00";
        }
    }
}
