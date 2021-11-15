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
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Baseline.ImTools;
using ImTools;

namespace Lab5
{   
//___________________________________________MainWindow_________________________________________
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string length;
        string[] patternSeq;
        Algorithm al = new Algorithm();
       /* Pattern patt = new Pattern();*/
        List<Pattern> completedPatternSeq = new List<Pattern>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                wholeSeq.Text = File.ReadAllText(openFileDialog.FileName);
             length =  wholeSeq.Text = wholeSeq.Text.Replace("\n", "").Replace("\r", "");
            patternSeq = new string[length.Length - 3];
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            
            al.find_Patterns(length, patternSeq);
            al.count_Patterns(patternSeq, completedPatternSeq);
            patterns.Text = completedPatternSeq[0].pattern + " - " + completedPatternSeq[0].count;

            for (int i = 1; i < completedPatternSeq.Count; i++)
            {
                patterns.Text += "\n" + completedPatternSeq[i].pattern + " - " + completedPatternSeq[i].count;
                choose.Items.Add(completedPatternSeq[i].pattern);
                choose.Items.Refresh();
            }
        }

        private void choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            char[] tmpArray = new char[length.Length - 3];
            string tmp;
            wholeSeq.Text = "";
            for (int i = 0; i < completedPatternSeq.Count; i++)
            {

                int j;
                for (j = 0; j < patternSeq.Length; j++)
                {/*
                    for(int k = 0;k<4; k++)
                    {
                        tmpArray[k] = length[j];
                    }
                    tmp = new string(tmpArray);
*/

                    if (patternSeq[j]=="CCCA")
                    {
                        patternSeq[j].
                        wholeSeq.Text += "A";
                        
                    }
                    else
                    wholeSeq.Text += patternSeq[j];
                   
                }
            }
        }

        private void wholeSeq_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    //_______________________________Algorithm class____________________________
    public partial class Algorithm
    {

        
        char[] nukl = new char[4];
        int i;


        public Algorithm()
        {

        }
        //____________________________Create patterns (4-mers)____________________________________
        public void find_Patterns(string length, string[]  patternSeq)
        {
            string frag;
            for ( i = 0; i < (length.Length)-3; i++)
            {
                int j = 0;
                for (j = 0; j < 4; j++)
                {
                    nukl[j] = length[i+j];
                }
                frag= new string(nukl);
                patternSeq[i] = frag ;
            }
        }
        //___________________Count speeches of pattern__________________________
        public void count_Patterns(string[] patternSeq, List<Pattern> completedPatternSeq)
        {
            
            for(int i = 0; i<patternSeq.Length; i++)
            {
                int counter = 1;
                
                for (int j = i+1; j < patternSeq.Length; j++)
                {
                    if (patternSeq[i] == patternSeq[j])
                    {
                        counter++;
                        Array.Clear(patternSeq, 0, 1);
                    }
                }
                if (patternSeq[i] != null && counter>1)
                {
                    Pattern patt = new Pattern(counter, patternSeq[i]);
                    completedPatternSeq.Add(patt);
                }
            }
        }
    }

 // Pattern as object 
    public partial class Pattern
    {
        public int count;
        public string pattern;

        public Pattern(int c, string p)
        {
            count = c;
            pattern = p;
        }
    }

}