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

using Microsoft.Win32;

using System.Xml.Serialization;


namespace PW_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFile = new OpenFileDialog();
        toFile objectFile = new toFile();

        public MainWindow()
        {
            InitializeComponent();
            MessageBoxResult result = MessageBox.Show("Załadować plik?", "Otwarcie pliku", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
            }
            else if (result == MessageBoxResult.Yes)
            {
                openF();
            }
        }

        public class toFile
        {
            public int id { get; set; }
            public string nazwaUczelni { get; set; }
            public string kierunek { get; set; }
            public string studiawZakresie { get; set; }
            public string profilStudiów { get; set; }
            public string formaStudiów { get; set; }
            public string poziomStudiów { get; set; }
            public string imienazwiskoStudent1 { get; set; }
            public string nrAlbumuStudent1 { get; set; }
            public string podpisStudent1 { get; set; }
            public string imienazwiskoStudent2 { get; set; }
            public string nrAlbumuStudent2 { get; set; }
            public string podpisStudent2 { get; set; }
            public string imienazwiskoStudent3 { get; set; }
            public string nrAlbumuStudent3 { get; set; }
            public string podpisStudent3 { get; set; }
            public string imienazwiskoStudent4 { get; set; }
            public string nrAlbumuStudent4 { get; set; }
            public string podpisStudent4 { get; set; }
            public string imienazwiskoStudent5 { get; set; } 
            public string nrAlbumuStudent5 { get; set; }
            public string podpisStudent5 { get; set; }
            public string tytuł { get; set; }
            public string tytulAngl { get; set; }
            public string daneWejściowe { get; set; }
            public string zakresPracy { get; set; }
            public string termin { get; set; }
            public string promotor{ get; set; }
            public string jednostkaPromotora { get; set; }
            public string podpisDyrektora { get; set; }
            public string podpisDziekana { get; set; }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Dialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want save changes?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = false;
            }
            else if (result == MessageBoxResult.Yes)
            {
                
                toFile objectFile = new toFile();
                XmlSerializer xs = new XmlSerializer(typeof(toFile));

                objectFile.id = comboBox.SelectedIndex;
                objectFile.nazwaUczelni = nazwaUczelni.Text;
                objectFile.kierunek = kierunek.Text;
                objectFile.studiawZakresie = studiaWZakresie.Text;
                objectFile.profilStudiów = profilStudiów.Text;
                objectFile.formaStudiów = formaStudiów.Text;
                objectFile.poziomStudiów = poziomStudiów.Text;
                objectFile.imienazwiskoStudent1 = imieiNazwisko_1.Text;
                objectFile.nrAlbumuStudent1 = nrAlbumu_1.Text;
                objectFile.podpisStudent1 = dataiPodpis_1.Text;
                objectFile.imienazwiskoStudent2 = imieiNazwisko_2.Text;
                objectFile.nrAlbumuStudent2 = nrAlbumu_2.Text;
                objectFile.podpisStudent2 = dataiPodpis_2.Text;
                objectFile.imienazwiskoStudent3 = imieiNazwisko_3.Text;
                objectFile.nrAlbumuStudent3 = nrAlbumu_3.Text;
                objectFile.podpisStudent3 = dataiPodpis_3.Text;
                objectFile.imienazwiskoStudent4 = imieiNazwisko_4.Text;
                objectFile.nrAlbumuStudent4 = nrAlbumu_4.Text;
                objectFile.podpisStudent4 = dataiPodpis_4.Text;
                objectFile.imienazwiskoStudent5 = imieiNazwisko_5.Text;
                objectFile.nrAlbumuStudent5 = nrAlbumu_5.Text;
                objectFile.podpisStudent5 = dataiPodpis_5.Text;
                objectFile.tytuł = tytułPracy.Text;
                objectFile.tytulAngl = tytułpoAngl.Text;
                objectFile.daneWejściowe = daneW.Text;
                objectFile.zakresPracy = zakres.Text;
                objectFile.termin = term.Text;
                objectFile.promotor = promo.Text;
                objectFile.jednostkaPromotora = jednostka.Text;
                objectFile.podpisDyrektora = podpisDyr.Text;
                objectFile.podpisDziekana = podpisDzie.Text;


                 SaveFileDialog sFile = new SaveFileDialog();
                if (sFile.ShowDialog() == true)
                {
                    TextWriter txtWriter = new StreamWriter(sFile.FileName + ".xml");
                    xs.Serialize(txtWriter,objectFile);
                   
                    txtWriter.Close();
                }
            }
        }
       
        public void openF()
        {    
            if (openFile.ShowDialog() == true)
            {
                toFile objectFile = new toFile();

                XmlSerializer xs = new XmlSerializer(typeof(toFile));
                Stream s = File.OpenRead(openFile.FileName); 
                objectFile = (toFile)xs.Deserialize(s);
                comboBox.SelectedIndex = Convert.ToInt32(objectFile.id);
                nazwaUczelni.Text = objectFile.nazwaUczelni;
                kierunek.Text = objectFile.kierunek;
                studiaWZakresie.Text = objectFile.studiawZakresie;
                profilStudiów.Text = objectFile.profilStudiów;
                formaStudiów.Text = objectFile.formaStudiów;
                poziomStudiów.Text = objectFile.poziomStudiów;
                imieiNazwisko_1.Text = objectFile.imienazwiskoStudent1;
                nrAlbumu_1.Text = objectFile.nrAlbumuStudent1;
                dataiPodpis_1.Text = objectFile.podpisStudent1;
                imieiNazwisko_2.Text = objectFile.imienazwiskoStudent2;
                nrAlbumu_2.Text = objectFile.nrAlbumuStudent2;
                dataiPodpis_2.Text = objectFile.podpisStudent2;
                imieiNazwisko_3.Text = objectFile.imienazwiskoStudent3;
                nrAlbumu_3.Text = objectFile.nrAlbumuStudent3;
                dataiPodpis_3.Text = objectFile.podpisStudent3;
                imieiNazwisko_4.Text = objectFile.imienazwiskoStudent4;
                nrAlbumu_4.Text = objectFile.nrAlbumuStudent4;
                dataiPodpis_4.Text = objectFile.podpisStudent4;
                imieiNazwisko_5.Text = objectFile.imienazwiskoStudent5;
                nrAlbumu_5.Text = objectFile.nrAlbumuStudent5;
                dataiPodpis_5.Text = objectFile.podpisStudent5;
                tytułPracy.Text = objectFile.tytuł;
                tytułpoAngl.Text = objectFile.tytulAngl;
                daneW.Text = objectFile.daneWejściowe;
                zakres.Text = objectFile.zakresPracy;
                term.Text = objectFile.termin;
                promo.Text = objectFile.promotor;
                jednostka.Text = objectFile.jednostkaPromotora;
                podpisDyr.Text = objectFile.podpisDyrektora;
                podpisDzie.Text = objectFile.podpisDziekana;
            }
        }

    }
}
