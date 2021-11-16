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
using System.Text.RegularExpressions;

namespace Lab5
{   
//___________________________________________MainWindow_________________________________________
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string length="";
        string[] patternSeq;
        Algorithm al = new Algorithm();
        List<Pattern> completedPatternSeq = new List<Pattern>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            wholeSeq.Selection.Text = "";
            choose.Items.Clear();
            patterns.Text = "";

            if (openFileDialog.ShowDialog() == true)
                wholeSeq.Selection.Text = File.ReadAllText(openFileDialog.FileName);

            length =  wholeSeq.Selection.Text = wholeSeq.Selection.Text.Replace("\n", "").Replace("\r", "");
            patternSeq = new string[length.Length - 3];
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {  
            al.find_Patterns(length, patternSeq);
            al.count_Patterns(patternSeq, completedPatternSeq,length);
            if (length.Length != 0)
            {
                patterns.Text = completedPatternSeq[0].pattern + " - " + completedPatternSeq[0].count;
                choose.Items.Add(completedPatternSeq[0].pattern);

                for (int i = 1; i < completedPatternSeq.Count; i++)
                {
                    patterns.Text += "\n" + completedPatternSeq[i].pattern + " - " + completedPatternSeq[i].count;
                    choose.Items.Add(completedPatternSeq[i].pattern);
                }
            }
        }


        private void choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pattern = e.AddedItems[0].ToString();
            TextPointer seqStart = wholeSeq.Document.ContentStart;
            TextPointer seqEnd = wholeSeq.Document.ContentEnd;
            TextRange textRange = new TextRange(seqStart, seqEnd);

            textRange.ClearAllProperties();

            if (textRange.Text != "")
            {
                string searchText = pattern;

                for (TextPointer startPointer = wholeSeq.Document.ContentStart;
                    startPointer.CompareTo(wholeSeq.Document.ContentEnd) <= 0;
                        startPointer = startPointer.GetNextContextPosition(LogicalDirection.Forward))
                {
                    if (startPointer.CompareTo(seqEnd) == 0) 
                        break;

                    string parsedString = startPointer.GetTextInRun(LogicalDirection.Forward);
                    int i = parsedString.IndexOf(searchText);

                    if (i >= 0)
                    {
                        startPointer = startPointer.GetPositionAtOffset(i);
                        if (startPointer != null)
                        {
                            TextPointer nextPointer = startPointer.GetPositionAtOffset(searchText.Length);
                            TextRange searchRange = new TextRange(startPointer, nextPointer);
                            searchRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.GreenYellow));
                        }
                    }
                }
            }
        }
        private void wholeSeq_TextChanged(object sender, TextChangedEventArgs e)
        {}
    }


    //_______________________________Algorithm class____________________________
    public partial class Algorithm
    {
        char[] nukl = new char[4];
        int i;

        public Algorithm()//Constructor
        {}

        //____________________________Create patterns (4-mers)____________________________________
        public void find_Patterns(string length, string[]  patternSeq)
        {
            string frag;

            if (length.Length != null)
            {

                for (i = 0; i < (length.Length) - 3; i++)
                {
                    int j = 0;

                    for (j = 0; j < 4; j++)
                    {
                        nukl[j] = length[i + j];
                    }

                    frag = new string(nukl);
                    patternSeq[i] = frag;
                }
            }
            else
            {
            }
        }
        //___________________Count speeches of pattern__________________________
        public void count_Patterns(string[] patternSeq, List<Pattern> completedPatternSeq,string length)
        {
         if(length.Length!=0)   
            for(int i = 0; i<patternSeq.Length; i++)
            {
                int counter = 1;
                for (int j = 1; j < patternSeq.Length; j++)
                {
                    if (patternSeq[i] == patternSeq[j])
                        counter++;
                }
                Pattern patt = new Pattern(counter, patternSeq[i]);
                bool addOrNot = false;
                
                foreach (Pattern pat in completedPatternSeq)
                {
                    if (pat.pattern == patternSeq[i])
                        addOrNot = true;
                }

                if(addOrNot==false)
                completedPatternSeq.Add(patt);
              
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