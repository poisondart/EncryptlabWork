using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KriptoLaba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    /*Нужно сделать скитала, табличная, двойная перестановка, магический квадрат,
     * полибианский квадрат, шифр цезаря, гронсфельда, виженера, уитстона*/

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
                Skital skital = new Skital();
                skital.SetLength(diametr.Text);
                string original_text = origtext.Text;
                string result_text = skital.EncryptText(original_text);
                kripttext.Text = result_text;

            }


            if (tablekript.IsChecked==true) {

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


            if (doubleswitch.IsChecked == true)
            {

                if (String.IsNullOrEmpty(key1.Text))
                {
                    MessageBox.Show("Введите первый ключ", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                
                if (String.IsNullOrEmpty(key2.Text))
                {
                    MessageBox.Show("Введите второй ключ", "Ошибка", MessageBoxButton.OK);
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

            if (polib.IsChecked == true)
            {
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                string orig_text = origtext.Text;
                PolibSquare polib = new PolibSquare();
                string result_text = polib.Encrypt(orig_text);
                kripttext.Text = result_text;
            }

            if (caesar.IsChecked == true)
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

                string orig_text = origtext.Text;
                int ces_key = Int32.Parse(key1.Text);
                Ceasar ceasar = new Ceasar(orig_text, ces_key);
                ceasar.Encode();
                string res_text = ceasar.GetText;
                kripttext.Text = res_text;
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
                Skital skital = new Skital();
                skital.SetLength(diametr.Text);
                string original_text = origtext.Text;
                string result_text = skital.DecryptText(original_text);
                kripttext.Text = result_text;
            }

            if (tablekript.IsChecked == true)
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

            if (doubleswitch.IsChecked == true)
            {

                if (String.IsNullOrEmpty(key1.Text))
                {
                    MessageBox.Show("Введите первый ключ", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                
                if (String.IsNullOrEmpty(key2.Text))
                {
                    MessageBox.Show("Введите второй ключ", "Ошибка", MessageBoxButton.OK);
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

                try{

                    DoubleTrans doubleTrans = new DoubleTrans(originaText, cryptKeyOne, cryptKeyTwo);

                    string decryptString = doubleTrans.EncryptDecrypt();

                    kripttext.Text = decryptString;
                }
                catch (Exception ex){

                    MessageBox.Show(ex.ToString());
                }
            }

            if (polib.IsChecked == true)
            {
                if (String.IsNullOrEmpty(origtext.Text))
                {
                    MessageBox.Show("Введите текст для шифровки/расшифровки", "Ошибка", MessageBoxButton.OK);
                    return;
                }

                string orig_text = origtext.Text;
                PolibSquare polib = new PolibSquare();
                string result_text = polib.Decrypt(orig_text);
                kripttext.Text = result_text;
            }

            if (caesar.IsChecked == true)
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

                string orig_text = origtext.Text;
                int ces_key = Int32.Parse(key1.Text);
                Ceasar ceasar = new Ceasar(orig_text, ces_key);
                ceasar.Decode();
                string res_text = ceasar.GetText;
                kripttext.Text = res_text;
            }
        }
    }
}
