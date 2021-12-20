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
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Diagnostics;

namespace PW_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OpenFileDialog openFileDialog = new OpenFileDialog();
        public string filePath, directoryPath;
        public ListBoxItem selectedSong;
        public MainWindow()
        {
            InitializeComponent();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileNames[0];
                int index = filePath.LastIndexOf('\\');
                directoryPath = filePath.Substring(0, index) + '\\';
                addItems(openFileDialog.FileNames);
                selectedSong = lista.Items[0] as ListBoxItem;
                selectedSong.IsSelected = true;
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                status.Content = $"{mediaPlayer.Position.ToString(@"mm\:ss")} / {mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss")}";
            else
                status.Content = "No file selected...";
        }

        private MediaPlayer mediaPlayer = new MediaPlayer();

        private void addItems(string[] songs)
        {
            foreach (var song in songs)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = song.Split('\\').Last();
                lista.Items.Add(item);
            }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri($"{directoryPath}{selectedSong.Content.ToString()}"));
            mediaPlayer.Play();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedSong = lista.SelectedItems[0] as ListBoxItem;
        }
    }
}