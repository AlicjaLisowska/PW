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
using System.IO;
using System.Windows;
using Microsoft.Win32;


namespace PW8
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Airport> airportList = new List<Airport>();
        public string file;
        string[] tab;
        string[] table;
        string[] table_2;
        public MainWindow()
        {

            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                file = File.ReadAllText(openFileDialog.FileName);
            tab = file.Split(',');
            string.Join(' ', file);
            table = file.Split('\n');
           
            
            loadArrey();

        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            
            Details detailsWindow = new Details();
            detailsWindow.Show();
        }

        public class Airport
        {
            public  string city { get; set; }
            public  string voivov { get; set; }
            public string icao { get; set; }
            public  string iata { get; set; }
            public  string portName { get; set; }
            public  string passengerNumber { get; set; }
            public  string change { get; set; }

        }
        void loadArrey()
        {
            int first_time = 0;
            int counter=0;
            Airport airport = new Airport();
            foreach (string i in table)
            {
                table_2 = table[counter].Split(',');
                if (counter!=0)
                    
                foreach(string j in table_2) {

                        if (counter == 1)
                        {
                            airport.city= j;
                            //test.Text += airport.icao;
                        }
                        if (counter == 1)
                {
                    airport.voivov = j;
                    //test.Text += airport.icao;
                }
                if (counter == 2)
                {
                    airport.icao = j;
                    //test.Text += airport.icao;
                }
                if (counter == 3)
                {
                    airport.iata = j;
                    //  test.Text += airport.iata;
                }
                if (counter == 4)
                {

                    airport.portName = j;
                    //test.Text += airport.portName;
                }
                if (counter == 5)
                {
                    airport.passengerNumber = j;

                    //test.Text += airport.passengerNumber;
                }
                if (counter == 6)
                {
                    airport.change = j;
                    // test.Text += airport.change;
                   

                        airportList.Add(new Airport() { city = airport.city, voivov = airport.voivov, icao = airport.icao, iata = airport.iata, portName = airport.portName, passengerNumber = airport.passengerNumber, change = airport.change });
                        airportsList.ItemsSource = airportList;
                        airportsList.Items.Refresh();
                        test.Text = "";
                        test.Text = "x";
                    
                    
                }
                        counter += 1;
                        if (counter == 7)
                            counter = 0;
                    }
                
                



            }
            //test.Text = table[1];//airportList[1].portName;


        }
    }
   
}
