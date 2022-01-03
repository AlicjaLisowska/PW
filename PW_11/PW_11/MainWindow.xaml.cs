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
using System.Security.Cryptography;


namespace PW_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void hide_Click(object sender, RoutedEventArgs e)
        {
            if (key.Text != "" && stringInput.Text != "")
            {
                if (System.Text.ASCIIEncoding.Unicode.GetByteCount(key.Text)==32 || System.Text.ASCIIEncoding.Unicode.GetByteCount(key.Text) == 64 || System.Text.ASCIIEncoding.Unicode.GetByteCount(key.Text) == 48)
                    hash.Text = EncryptString(key.Text, stringInput.Text);

                else
                {
                    MessageBoxResult result2 = MessageBox.Show("Prosze podać klucz o odpowiednim rozmiarze", "Zły rozmiar klucza", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Należy uzupełnić pole klucza/tekstu", "Brak klucza/tekstu", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, hash.Text);
        }


        //Encryption
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
                
        }      
    }
}