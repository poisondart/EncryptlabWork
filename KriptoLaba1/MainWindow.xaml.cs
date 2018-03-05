using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KriptoLaba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (skital.IsChecked == true)
            {
                if (String.IsNullOrEmpty(diametr.Text))
                {
                    MessageBox.Show("Введите диаметр \"палочки\"", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                int diameter_word_length = 0, lines = 0;
                string original_text = origtext.Text;
                diameter_word_length = Convert.ToInt32(diametr.Text);
                lines = (original_text.Length - 1) / diameter_word_length + 1;
                int spaces = lines * diameter_word_length - original_text.Length;
                for (int l = 0; l < spaces; l++)
                    original_text += " ";
                string[,] buffer_array = new string[diameter_word_length, lines];
                string result_text = "";
                int k = 0;
                for (int i = 0; i < diameter_word_length; i++)
                {
                    for (int j = 0; j < lines; j++)
                    {
                        buffer_array[i, j] = original_text.Substring(k, 1);
                        k += 1;
                    }
                }
                for (int j1 = 0; j1 < lines; j1++)
                {
                    for (int i1 = 0; i1 < diameter_word_length; i1++)
                        result_text += buffer_array[i1, j1];
                }
                kripttext.Text = result_text;

            }

            if (tablekript.IsChecked == true & key1.Text != "")
            {

                if (String.IsNullOrEmpty(key1.Text))
                {
                    MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                TableTrans tableTrans = new TableTrans();
                tableTrans.SetKey(key1.Text);
                string original_text = origtext.Text;
                string result_text = tableTrans.Encrypt(original_text);
                kripttext.Text = result_text;

            }

            if (doubleswitch.IsChecked == true && key1.Text != "" && key2.Text != "")
            {

                if (String.IsNullOrEmpty(key1.Text))
                {
                    MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                string originaText = origtext.Text;
                string cryptKeyOne = key1.Text;
                string cryptKeyTwo = key2.Text;
                try
                {
                    DoubleTrans doubleTrans = new DoubleTrans(originaText, cryptKeyOne, cryptKeyTwo);

                    string encryptString = doubleTrans.EncryptDecrypt();

                    kripttext.Text = encryptString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (skital.IsChecked == true)
            {
                if (String.IsNullOrEmpty(diametr.Text))
                {
                    MessageBox.Show("Введите диаметр \"палочки\"", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                int diameter_word_length = 0, lines = 0;
                string original_text = origtext.Text;
                diameter_word_length = Convert.ToInt32(diametr.Text);
                lines = (original_text.Length - 1) / diameter_word_length + 1;
                int spaces = lines * diameter_word_length - original_text.Length;
                for (int l = 0; l < spaces; l++)
                    original_text += " ";
                string[,] buffer_array = new string[diameter_word_length, lines];
                string result_text = "";
                int k = 0;
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < diameter_word_length; j++)
                    {
                        buffer_array[j, i] = original_text.Substring(k, 1);
                        k += 1;
                    }
                }
                for (int j1 = 0; j1 < diameter_word_length; j1++)
                {
                    for (int i1 = 0; i1 < lines; i1++)
                        result_text += buffer_array[j1, i1];
                }
                kripttext.Text = result_text;
            }

            if (tablekript.IsChecked == true & key1.Text != "")
            {

                if (String.IsNullOrEmpty(key1.Text))
                {
                    MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                TableTrans tableTrans = new TableTrans();
                tableTrans.SetKey(key1.Text);
                string original_text = origtext.Text;
                string result_text = tableTrans.Decrypt(original_text);
                kripttext.Text = result_text;

            }

            if (doubleswitch.IsChecked == true && key1.Text != "" && key2.Text != "")
            {

                if (String.IsNullOrEmpty(key1.Text))
                {
                    MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                string originaText = origtext.Text;
                string cryptKeyOne = key1.Text;
                string cryptKeyTwo = key2.Text;

                try
                {

                    DoubleTrans doubleTrans = new DoubleTrans(originaText, cryptKeyOne, cryptKeyTwo);

                    string decryptString = doubleTrans.EncryptDecrypt();

                    kripttext.Text = decryptString;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
