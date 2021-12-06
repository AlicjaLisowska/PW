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
using Microsoft.VisualBasic.FileIO;

namespace PW8
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Details detailsWindow = new Details();
        public List<Airport> airportList = new List<Airport>();
        public string file;
        string[] tab;
        List<string> table;
        string[] table_2;
        string tmp;

        public MainWindow()
        {

            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                file = File.ReadAllText(openFileDialog.FileName);
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileContent = File.ReadAllText(path + "\\" + "Test_Data.csv",Encoding.UTF8);
            using (TextFieldParser csvParser = new TextFieldParser(path + "\\" + "Test_Data.csv"))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();
                csvParser.ReadLine();
                while (!csvParser.EndOfData)
                {
                    tab = csvParser.ReadFields();
                    loadArrey();
                }


            }

            //To działało
            /*
                        tab = file.Split('"');
                        table=tab.ToList();
                        table.RemoveRange(0, 2);
                        *//*string.Join('', table);*//*



                        tab = table.ToArray();
                        tmp = string.Join('"', tab);
                        tab = tmp.Split(',');
                        tmp=string.Join('\n', tab);
                        tab = tmp.Split('\n');
                        */
            //Do td
            //string.Join(' ', file);
            //table = file.Split('\n');




        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            /*  int sele = airportsList.SelectedIndex;
              string activeAirport = airportList[sele].portName;*/

            Checked();
            
            detailsWindow.Show();
           
        }

        public class Airport
        {
            public string city { get; set; }
            public string voivov { get; set; }
            public string icao { get; set; }
            public string iata { get; set; }
            public string portName { get; set; }
            public string passengerNumber { get; set; }
            public string change { get; set; }

        }
        void loadArrey()
        {
      airportList.Add(new Airport() { city = tab[0], voivov = tab[1], icao = tab[2], iata = tab[3], portName = tab[4], passengerNumber = tab[5], change = tab[6] });
            airportsList.ItemsSource = airportList;
            airportsList.Items.Refresh();





        }
        public void Checked()
        {
            if (icao.IsChecked == true)
               detailsWindow.text.Text += "Kod lotniska ICAO: " + airportList[airportsList.SelectedIndex].icao+'\n';
            if (iata.IsChecked == true)
                detailsWindow.text.Text += "Kod lotniska IATA: " + airportList[airportsList.SelectedIndex].iata+'\n';
            if (pass.IsChecked == true)
                detailsWindow.text.Text += "Liczba pasażerów: " + airportList[airportsList.SelectedIndex].passengerNumber+'\n';
            if (voi.IsChecked == true)
                detailsWindow.text.Text += "Województwo: " + airportList[airportsList.SelectedIndex].voivov+'\n';
            if (city.IsChecked == true)
                detailsWindow.text.Text += "Miasto: " + airportList[airportsList.SelectedIndex].city;
        }
    }
}
   

