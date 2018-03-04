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
            if (skital.IsChecked==true) {
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

            if (tablekript.IsChecked==true & key1.Text!="") {

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

            if (doubleswitch.IsChecked==true && key1.Text!="" && key2.Text!="") {

                Dictionary<char, short> alfavit = new Dictionary<char, short>
                {
                    { 'А', 1 },
                    { 'Б', 2 },
                    { 'В', 3 },
                    { 'Г', 4 },
                    { 'Д', 5 },
                    { 'Е', 6 },
                    { 'Ё', 7 },
                    { 'Ж', 8 },
                    { 'З', 9 },
                    { 'И', 10 },
                    { 'Й', 11 },
                    { 'К', 12 },
                    { 'Л', 13 },
                    { 'М', 14 },
                    { 'Н', 15 },
                    { 'О', 16 },
                    { 'П', 17 },
                    { 'Р', 18 },
                    { 'С', 19 },
                    { 'Т', 20 },
                    { 'У', 21 },
                    { 'Ф', 22 },
                    { 'Х', 23 },
                    { 'Ц', 24 },
                    { 'Ч', 25 },
                    { 'Ш', 26 },
                    { 'Щ', 27 },
                    { 'Ъ', 28 },
                    { 'Ы', 29 },
                    { 'Ь', 30 },
                    { 'Э', 31 },
                    { 'Ю', 32 },
                    { 'Я', 33 }
                };

                string original1 = key1.Text;
                string original2 = key2.Text;

                
                int count = 0;
                foreach (char later in original1)
                {
                    count = original1.Where(x => x == later).Count();
                    if (count > 1) { kripttext.Text = "Ты що ебанутый???"; return; }
                }

                
                count = 0;
                foreach (char later in original2)
                {
                    count = original2.Where(x => x == later).Count();
                    if (count > 1) { kripttext.Text = "Ты що ебанутый???"; return; }
                }

                int[] array1 = new int[original1.Length];
                int[] array2 = new int[original2.Length];
                int[] array3 = new int[original1.Length];
                int[] array4 = new int[original2.Length];

                count = 0;
                foreach (char later in original1.ToUpper())
                {
                    array1[count++] = alfavit[later];
                }

                count = 0;
                foreach (char later in original2.ToUpper())
                {
                    array2[count++] = alfavit[later];
                }

                array3 = array1.OrderBy(x => x).ToArray();
                array4 = array2.OrderBy(x => x).ToArray();

                char[,] kryptingstr = new char[array3.Length,array4.Length];

                string orginaltext = origtext.Text;
                count = 0;
                for (int i=0; i<array3.Length ;i++)
                {
                    for (int j = 0; i < array4.Length; j++)
                    {
                        kryptingstr[i, j] = orginaltext.ToString().Length <= count ? ' ' : orginaltext[count];
                        count++;
                    }
                }

                char[,] kryptstr = new char[array3.Length, array4.Length];

                for (int i=0; i<array3.Length; i++)
                {
                    for (int j=0; j<array4.Length; j++)
                    {
                        kryptstr[i, j] = kryptingstr[array1[array3[i]], array2[array4[j]]];
                    }
                }

                kripttext.Text = "Fuck you~!";
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

        }
    }
}
